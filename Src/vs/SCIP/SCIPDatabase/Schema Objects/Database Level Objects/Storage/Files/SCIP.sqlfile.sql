ALTER DATABASE [$(DatabaseName)]
    ADD FILE (NAME = [SCIP], FILENAME = '$(DefaultDataPath)$(DatabaseName).mdf', FILEGROWTH = 10240 KB) TO FILEGROUP [PRIMARY];

