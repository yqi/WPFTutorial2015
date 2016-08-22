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
* create DB is **not** easy as above
* database migration is __hard__

## Model first 
1. Using NuGet to get EntityFramework
2. Add "New Items" to project: Data -> ADO.NET Entity Data Model, select Empty EF Designer model
3. Edit Model with toolbox
4. Right click on Model and select "Generate database from Model"
5. Double click the generated *.edmx.sql and excecute it
6. After DB design finished, add data
7. Rest is same as Database first

* Advantage

    * easy DB design
    * model can be updated when database changed

* Disadvantage

    * DB data will be lost if generated database

## Code First 
- **Code First** infer the relationship between the two entities using navigation property. This navigation property can be simple reference type or collection type.
- **Code-First** includes types defined as a DbSet property in context class.
- **Code-First** includes reference types included in entity types even if they are defined in different assembly.
- *Code-First* includes derived classes even if only the base class is defined as DbSet property.
- The default convention for primary key is that Code-First would create a primary key for a property if the property name is Id or <class name>Id (NOT case sensitive). The data type of a primary key property can be anything, but if the type of the primary key property is numeric or GUID, it will be configured as an identity column.
- Fluent API
- DataAnnotation


```
Example:

[Table("StudentInfo")]
public class Student
{
    public Student() { }
        
    [Key]
    public int SID { get; set; }

    [Column("Name", TypeName="ntext")]
    [MaxLength(20)]
    public string StudentName { get; set; }

    [NotMapped]
    public int? Age { get; set; }
        
    public int StdId { get; set; }

    [ForeignKey("StdId")]
    public virtual Standard Standard { get; set; }
}
```

### Advantage
- more control of database
- database migration is easy

### Disadvantage
- hard to maintain database
