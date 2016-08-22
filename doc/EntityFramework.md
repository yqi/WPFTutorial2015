# This project shows how to use EntityFramework to Connect to SQLExpress

## Database first 
* Using NuGet to get EntityFramework
* In Visual Studio, in Server Explorer, Data Connections -> Add Connection ->Select Server in server name, and select database.
* Add "New Items" to project: Data -> ADO.NET Entity Data Model, select EF Designer from database -> select all tables
* Use "Update" after design changes in Visual Studio.
* Management Studio has more control on DB design.

### Advantage
* data will not be lost

### Disadvantage
* create DB is not easy as above
* sdatabase migration is hard

## Model first 
* Using NuGet to get EntityFramework
* Add "New Items" to project: Data -> ADO.NET Entity Data Model, select Empty EF Designer model
* Edit Model with toolbox
* Right click on Model and select "Generate database from Model"
* Double click the generated *.edmx.sql and excecute it.
* After DB design finished, add data.
* Rest is same as Database first

### Advantage
* easy DB design
* model can be updated when database changed

### Disadvantage
* DB data will be lost if generated database

## Code First 
* database migration is easy
* Step-2:
* Step-3:

### Advantage
* more control of database
* database migration is easy

### Disadvantage
* hard to maintain database