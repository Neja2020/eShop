# eShop
.NET Core MVC Web Application

The idea of this project was to create a .NET Core web application using MVC (model controller view) architecture and Entity Framework. 
Application represents basic eShop CRUD operations.
To start it, you will need to have Visual Studio or Visual Studio Code installed on your computer with dotnet. 
Also, this application uses Microsoft SQL server as a database, so you will need it as well. To start the application after you clone it on your computer, 
you will need to run few commands in your Visual Studio CLI and setup the connection string so you can connect the application to database server.
You can find ConnectionString in EF/MyContext.cs.
 
In your Visual Studio CLI you will need to run this command:
Update-Database
If you’re using VS Code: 
dotnet ef database update
After this, Entity Framework created Shop database on your SQL Server and you can run the app.
The goal of the project was to get to know new web technology, implement CRUD operations for more complex classes and connect them to database.
