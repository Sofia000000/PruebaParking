## La base de datos esta hecha 

### Servidor: Localhost
### Nombre: ParkingDB

```SQL
CREATE TABLE [dbo].[tbl_users]
(
	  [Id] INT IDENTITY(1,1) PRIMARY KEY, 
    [name] VARCHAR(100) NULL, 
    [email] VARCHAR(100) NULL, 
    [password] VARCHAR(100) NULL
)

CREATE TABLE [dbo].[tbl_reservations]
(
	  [Id] INT IDENTITY(1,1) PRIMARY KEY, 
    [user_id] INT FOREIGN KEY REFERENCES tbl_users(id), 
    [entry_hour] TIME NULL, 
    [left_hour] TIME NULL, 
    [parking_id] INT NULL
)
```
