This application is a property management system developed using .NET. It allows users to manage properties, owners, and transactions. The main functionalities include adding, updating, deleting, and viewing records in these categories.

## Functionality

### Properties
- **Add Property**: Allows users to add new property details.
- **Update Property**: Enables users to update existing property information.
- **Delete Property**: Users can delete a property. A confirmation message will be displayed: "Are you sure you want to delete the property at [Property Address]?"

### Owners
- **Add Owner**: Allows users to add new owner details.
- **Update Owner**: Enables users to update existing owner information.
- **Delete Owner**: Users can delete an owner. A confirmation message will be displayed: "Are you sure you want to delete the owner [First Name] [Last Name]?"

### Transactions
- **Add Transaction**: Allows users to add new transaction details. Owner and Property are required to add a transaction.
- **Update Transaction**: Enables users to update existing transaction information.
- **Delete Transaction**: Users can delete a transaction. A confirmation message will be displayed: "Are you sure you want to delete the transaction with ID [Transaction ID]?"

## Database Configuration

To configure the database connection, follow these steps:

1. **Connection String**: Locate the `appsettings.json` file in the root directory of the project.
2. **Edit Connection String**: Update the `ConnectionStrings` section with your database details. For example:
    ```json
    {
      "ConnectionStrings": {
        "DefaultConnection": "Server=your_server_name;Database=your_database_name;User Id=your_username;Password=your_password;"
      }
    }
    ```

## Extra Note
There is an exe included, but it will not be able to run for you as it won't be able to connect to your database. Ensure the above configuration is properly filled out *before* building and running the program.