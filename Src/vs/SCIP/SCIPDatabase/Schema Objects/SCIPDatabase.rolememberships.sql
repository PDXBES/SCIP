EXECUTE sp_addrolemember @rolename = N'DB_Owners', @membername = N'ROSE\arnelm';


GO
EXECUTE sp_addrolemember @rolename = N'DB_Owners', @membername = N'ROSE\issacg';


GO
EXECUTE sp_addrolemember @rolename = N'DB_Owners', @membername = N'ROSE\mszwaya';


GO
EXECUTE sp_addrolemember @rolename = N'DB_Editors', @membername = N'ROSE\grp117';


GO
EXECUTE sp_addrolemember @rolename = N'db_owner', @membername = N'DB_Owners';


GO
EXECUTE sp_addrolemember @rolename = N'db_datareader', @membername = N'ROSE\grp117';


GO
EXECUTE sp_addrolemember @rolename = N'db_datawriter', @membername = N'DB_Editors';

