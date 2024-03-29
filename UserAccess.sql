-- Create Application User
create login app_user with password = 'dbsd1234';
create user app_user for login app_user;
grant select, insert, update, delete on dbo.Client to app_user;

-- Revoke unnecessary privileges from app_user
revoke alter, references on dbo.Client from app_user;

-- Create Data Import User
CREATE LOGIN import_user WITH PASSWORD = 'import_user';
CREATE USER import_user FOR LOGIN import_user;
GRANT INSERT ON dbo.Client TO import_user;

-- Revoke unnecessary privileges from import_user
REVOKE UPDATE, DELETE, ALTER, REFERENCES ON dbo.Client FROM import_user;

-- Create Data Export User
CREATE LOGIN export_user WITH PASSWORD = 'export_user';
CREATE USER export_user FOR LOGIN export_user;
GRANT SELECT ON dbo.Client TO export_user;

-- Revoke unnecessary privileges from export_user
REVOKE INSERT, UPDATE, DELETE, ALTER, REFERENCES ON dbo.Client FROM export_user;