﻿using System;
using System.Data.Common;
using grate.Configuration;
using grate.Migration;
using Microsoft.Extensions.Logging;

namespace grate.unittests.TestInfrastructure
{
    public interface IGrateTestContext
    {
        string AdminPassword { get; set; }
        int? Port { get; set; }

        string DockerCommand(string serverName, string adminPassword);
        
        string AdminConnectionString { get; }
        string ConnectionString(string database);

        DbConnection GetDbConnection(string connectionString);

        DbConnection CreateAdminDbConnection() => GetDbConnection(AdminConnectionString);
        DbConnection CreateDbConnection(string database) => GetDbConnection(ConnectionString(database));
        
        Type DbExceptionType { get;  }
        ILogger Logger { get; }
        DatabaseType DatabaseType { get; }
        IDatabase DatabaseMigrator { get; }
        
        SqlStatements Sql { get; }
        string DatabaseTypeName { get; }
        string MasterDatabase { get; }
        
        string ExpectedVersionPrefix { get; }

        GrateMigrator GetMigrator(GrateConfiguration config);

        GrateMigrator GetMigrator(string databaseName, bool createDatabase, KnownFolders knownFolders, params string[] environments);
    }
}