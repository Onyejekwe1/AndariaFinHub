# AndariaFinHub

### Database Configuration

The project is configured to use an in-memory database by default. This made it easier for me to build and test the project given the short period of time. But it can be easily updated to an sql db

If you would like to use SQL Server, you will need to update **WebApi/appsettings.json** as follows:

```json
  "UseInMemoryDatabase": false,
```

Verify that the **DefaultConnection** connection string within **appsettings.json** points to a valid SQL Server instance. 

When you run the application the database will be automatically created (if necessary) and the latest migrations will be applied.

With the in-memory db, all you need do is fire up the application!

Test credentials:
email: andaria@test.com password: Matech_1850
