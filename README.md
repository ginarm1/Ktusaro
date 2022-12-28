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
