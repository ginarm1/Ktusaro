export const Home = () => {
    return (
      <div className="py-6 flex justify-center">
        <div className='max-w-lg p-6 bg-white border border-gray-200 rounded-lg shadow-md hover:bg-gray-100 dark:bg-gray-800 dark:border-gray-700 dark:hover:bg-gray-700'>
          <h1 className="mb-2 text-2xl font-bold tracking-tight text-gray-900 dark:text-white">KTU SA renginių organizavimo IS</h1>
          <hr className="py-3"/>
          <p className="font-normal text-gray-700 dark:text-gray-400">Welcome to <b>event management system <em> v2</em></b> made by</p>
          <p className={"pb-4 font-normal text-gray-700 dark:text-gray-400"}><b>Gintaras Armonaitis</b></p>
          <p className={"dark:text-white"}>This time, it's built with seperated back-end and front-end. In this version, app text is written in English for presentation purposes.</p>
          <p className={" py-3 dark:text-white"}>Used technologies:</p>
          <ul>
            <li className={"dark:text-white"}><a href='https://devblogs.microsoft.com/dotnet/announcing-dotnet-7/'><b>.NET 7</b></a> for server-side</li>
            <li className={"dark:text-white"}><a href='https://reactjs.org/'><b>React</b></a> for client-side code</li>
            <li className={"dark:text-white"}><a href='https://www.postgresql.org/'><b>PostgreSQL</b></a> for database</li>
            <li className={"dark:text-white"}><a href='https://tailwindcss.com/'><b>Taildwind CSS</b></a> for layout and styling</li>
            <li className={"dark:text-white"}><a href='https://www.docker.com/products/docker-desktop/'><b>Docker Desktop</b></a> for containerizing application</li>
            <li className={"dark:text-white"}><a href='https://www.liquibase.org/'><b>Liquibase</b></a> for migrations</li>
            <li className={"dark:text-white"}><b>Integration and Unit tests</b> for application validation</li>
            <li className={"dark:text-white"}><a href='https://github.com/features/actions'><b>Github Actions</b></a> for continues integration</li>
            <li className={"dark:text-white"}><a href='https://jwt.io/'><b>JWT</b></a> for authorization</li>
          </ul>
        </div>

      </div>
    );
}