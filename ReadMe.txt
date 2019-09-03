Read Me for Phone Trade In Project ASP.NET MVC
================================================================================================================================================================================
Open the Project “PhoneTradeInFinal.sln”

Open “Web.config” change Line 15, the connection string “connectionString="Data Source=(LocalDb)\MSSQLLocalDB;” ; change the Data Source to your local database connection.

Open Package Manager Console and run the following commands:

Enable-Migrations -ContextTypeName ProductDBContext -MigrationsDirectory Migrations\ProductDBContext

Add-Migration -ConfigurationTypeName PhoneTradeInFinal.Migrations.ProductDBContext.Configuration "InitialDatabaseCreation"

Update-Database -ConfigurationTypeName PhoneTradeInFinal.Migrations.ProductDBContext.Configuration

This will utilize the Seed() method within the Configuration for initialization the Product database.

================================================================================================================================================================================
Admin Login Details:

Email: admin@swingit.com
Password: Admin123!

In Startup.cs we have createRolesandUsers() which is creating the admin credentials during the time of Project Startup by using Identity.

Logging in as an Admin will bring you to the Admin main page where access to admin tools for modifying products and users.

================================================================================================================================================================================
User Login Details:

Register an Account; if using a real email the quote request function will send the appropriate email to your inbox.

================================================================================================================================================================================
