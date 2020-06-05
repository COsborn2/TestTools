﻿using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace IntelliTect.TestTools.Data
{
    public class DatabaseFixture<T> : IDisposable where T : DbContext
    {
        private SqliteConnection SqliteConnection { get; }

        private Lazy<DbContextOptions<T>> Options { get; }

        private IServiceProvider ServiceProvider { get; set; }

        public DatabaseFixture()
        {
            SqliteConnection = new SqliteConnection("DataSource=:memory:");
            SqliteConnection.Open();

            Options = new Lazy<DbContextOptions<T>>(() => new DbContextOptionsBuilder<T>()
                .UseSqlite(SqliteConnection)
                .EnableSensitiveDataLogging()
                .UseLoggerFactory(GetLoggerFactory())
                .Options);
        }

        public event EventHandler<ILoggingBuilder> BeforeLoggingSetup;

        private void OnLoggingSetup(ILoggingBuilder builder)
        {
            BeforeLoggingSetup?.Invoke(this, builder);
        }

        private ILoggerFactory GetLoggerFactory()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging(builder =>
            {
                builder.AddInMemory();

                if (BeforeLoggingSetup is {})
                {
                    OnLoggingSetup(builder);
                }
            });

            ServiceProvider = serviceCollection.BuildServiceProvider();

            return ServiceProvider
                .GetService<ILoggerFactory>();
        }

        private T CreateNewContext()
        {
            var constructorInfo = typeof(T)
                .GetConstructors()
                .Where(x =>
                {
                    var parameters = x.GetParameters();
                    return parameters.Length == 1 && parameters[0].ParameterType == typeof(DbContextOptions);
                })
                .SingleOrDefault();

            if (constructorInfo is null)
            {
                throw new InvalidOperationException(
                    $"'{typeof(T)}' must contain a constructor that has a single parameter " +
                    $"of type '{typeof(DbContextOptions)}'");
            }

            bool alreadyCreated = Options.IsValueCreated;

            var db = (T) constructorInfo.Invoke(new object[]{ Options.Value });

            if (!alreadyCreated)
            {
                db.Database.EnsureCreated();
            }

            return db;
        }

        public async Task PerformDatabaseOperation(Func<T, Task> operation)
        {
            var db = CreateNewContext();
            await operation(db);
        }

        public ConcurrentDictionary<string,InMemoryLogger> GetInMemoryLoggers()
        {
            if (ServiceProvider is null)
            {
                throw new InvalidOperationException("ServiceCollection is not yet initialized. " +
                                                    "Perform some database operation to initialize loggers");
            }

            if (!(ServiceProvider.GetService<ILoggerProvider>() is InMemoryLoggerProvider loggerProvider))
            {
                throw new InvalidOperationException($"{typeof(ILoggerProvider)} of type " +
                                                    $"{typeof(InMemoryLoggerProvider)} could not be found.");
            }

            return loggerProvider.GetLoggers();
        }

        public void Dispose()
        {
            SqliteConnection?.Dispose();
        }
    }
}