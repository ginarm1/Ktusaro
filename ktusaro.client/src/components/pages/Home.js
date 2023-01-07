import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

  render() {
    return (
      <div>
        <h1>KTU SA renginių organizavimo IS</h1>
        <hr/>
        <p>Welcome to <b>event management system <em> v2</em></b> made by <b>Gintaras Armonaitis</b></p>
        <p>This time, it's built with seperated back-end and front-end. In this version, app text is written in English for presentation purposes.</p>
        <p>Used technologies:</p>
        <ul>
          <li><a href='https://devblogs.microsoft.com/dotnet/announcing-dotnet-7/'><b>.NET 7</b></a> for server-side</li>
          <li><a href='https://reactjs.org/'><b>React</b></a> for client-side code</li>
          <li><a href='https://www.postgresql.org/'><b>PostgreSQL</b></a> for database</li>
          <li><a href='https://tailwindcss.com/'><b>Taildwind CSS</b></a> for layout and styling</li>
          <li><a href='https://www.docker.com/products/docker-desktop/'><b>Docker Desktop</b></a> for containerizing application</li>
          <li><a href='https://www.liquibase.org/'><b>Liquibase</b></a> for migrations</li>
          <li><b>Integration and Unit tests</b> for application validation</li>
          <li><a href='https://github.com/features/actions'><b>Github Actions</b></a> for continues integration</li>
          <li><a href='https://jwt.io/'><b>JWT</b></a> for authorization</li>
        </ul>
      </div>
    );
  }
}