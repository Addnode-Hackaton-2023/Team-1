## To set up a database connection.
Add the ado.net connection string as a secret variable "DefaultConnection".
Manage user secrets if your are running locally and some other environment variable handling for test/qa/prod.

## To run a database migration
- Install EF Core Tools Nuget package
- Run "Add-Migration {Your Migration}" in Nuget Package Console (you might have to start VS as Admin)
- Debug or run app