ALTER DATABASE [EmployeeManagerDb] SET EMERGENCY;
GO

ALTER DATABASE [EmployeeManagerDb] set single_user
GO

DBCC CHECKDB ([EmployeeManagerDb], REPAIR_ALLOW_DATA_LOSS) WITH ALL_ERRORMSGS;
GO 

ALTER DATABASE [EmployeeManagerDb] set multi_user
GO