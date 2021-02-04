# refactor-this

MyComments:

1. Created ASP.NET WEBAPI project with name EF.
2. Added ADO.NET Entity DATA MODEL.Selected the server name and database name. Selected Accounts and Transaction table so it has created context file and added connection string in web.config automatically.
3. In the controllers folder, added Account and Transaction controllers.
4. In the Models folder, added a class called TransactionDTO to fetch only Amount and Date fileds in the API. If we dont have this class the GetTransaction method will pull all the fields. I have used LINQ to SQL query for this.
5. In Web.Config file, added <directoryBrowse enabled="true" /> under system.webserver inorder to overcome the forbidden error.

FutureImprovements:

1. Can use visual studio code to write service and fetch data using Angular.
2. Create components to have a UserInterface.
