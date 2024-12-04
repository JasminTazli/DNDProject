# Data Access 

**ORM** 
Using an ORM changes how we can work with data by simplifying the connection between our code and the database. Instead of writing SQL queries, we can use objects and methods to interact with data. 
The ORM automatically converts objects into database records and back, making tasks like creating, reading, updating, and deleting data much easier. 
This means that we don't need to know complex SQL, and our code becomes simpler and easier to maintain. 
ORMs also handle database-specific details, making it easier to switch to a different database if neded. 

**Difference between Linq and traditional SQL** 
Using LINQ (Language Integrated Query) in C# provides a more integrated and type-safe way to query data compared to traditional SQL. 
LINQ queries are written in C# and checked at compile time, while SQL queries are strings that are checked at runtime.

LINQ Example:

In EdataService.cs:
![image](https://github.com/user-attachments/assets/9c7a273a-15d1-4bdc-a756-2c036f669967)

SQL Example:

In ESGContext.cs:
![image](https://github.com/user-attachments/assets/31858056-1e54-49f3-8388-548bbf8fc66d)

Differences: 
LINQ in C# is good because:
- It's built right into C#, so the computer can check for mistakes before running your code
- It helps prevent errors by making sure you're working with the right kind of data
- It makes code easier to read and write because it uses fewer lines
- When you need to change your code later, LINQ makes it simpler to make those changes
