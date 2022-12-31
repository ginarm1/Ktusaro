# Ktusaro
New version of KTU SA event management system. Built with .NET 7

Refactoring old project to MVC with Onion architecture

Right now, coding backend


# Getting Started

Have Visual Studio, Docker, PostgreSQL, Liquibase installed.

Clone the project:

```
git clone https://github.com/ginarm1/Ktusaro.git
```

On Visual Studio terminal (or other terminal where project is linked) run command:

```
docker compose build
docker compose up -d
```

This will setup your Postgre database.

To your localhost URL add: /swagger/index.html

# If Docker did not built database

Check if you have in Microsoft Services  stopped postgresql-x64-14:

1. Search Services in Microsoft searchbar.
2. Look for postgresql-x64-14. It might have status "Running". If it is, stop the service (status should be blank)

# Authorization

if you want to see all users, you need to login as administrator. You can do that following these steps:

1. Login. Enter email - gintaras@gmail.com, password - admin
2. Copy JWT token
3. Click Authorize button and write: bearer yourJwtToken
4. Submit

Now you are authorized as an admin
