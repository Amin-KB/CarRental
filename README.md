# Car Rental

Ths is demo for Technical Job interview for Ferchau

## Author

- [@Amin-KB](https://github.com/Amin-KB)


## Tech Stack
**Database:** sql server express

**Backend:** Asp.net web Api, Entity framework core (ORM)

**Frontend:** Blazor WebAssembly Standalone app

### Database
I have chosen to use sql server server for two main reason.
<br>
**First:** in the task it was mentioned that i must normalize the data base so it meant i have to use a relational database
<br>
**Second:** sql server is the most popular relational database management system to use in .Net development.
<br>
<br>
Here is the Columns Diagram
![diagram](./tables.png)
<br>
<br>
<br>
### Backend (Web Api)
I used Asp.net web api because it is very popular enterprise backend solution and i am very comfortable and experienced to work with 

here are the Dependencies
<br>
Microsoft.EntityFrameworkCore: "8.0.0"
<br>
Microsoft.EntityFrameworkCore.Design: "8.0.0"
<br>
Microsoft.EntityFrameworkCore.SqlServer: "8.0.0"
<br>
Microsoft.EntityFrameworkCore.Tools: "8.0.0"
<br>
AutoMapper: "13.0.1"
<br>
<br>
<br>
**Design Pattern:**
<br>
for design pattern I implemented Unit of Work and Repository Pattern
because I believed it was the fastest pattern to implement for the time constraint of max 4 hours and I believe it is right pattern for simple Crud operations 
