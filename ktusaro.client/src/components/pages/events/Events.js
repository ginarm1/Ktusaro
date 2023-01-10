import { useState, useEffect, } from 'react';
import { Link, useNavigate } from 'react-router-dom';

export const Events = () => {
    const navigate = useNavigate();
    const [events, setEvents] = useState([]);
    const [loading, setLoading] = useState(true);
    const [filterName, setFilterName] = useState('');
    const [filterEventCoordinatorName, setEventCoordinatorName] = useState('');
    const [filterEventCoordinatorSurname, setEventCoordinatorSurname] = useState('');

    const [currentPage, setCurrentPage] = useState(1);
    const [eventsPerPage] = useState(10);

    // Change page
    const paginate = pageNumber => setCurrentPage(pageNumber);

    // Get current events
    const indexOfLastEvent = currentPage * eventsPerPage;
    const indexOfFirstEvent = indexOfLastEvent - eventsPerPage;
    const currentEvents = events.slice(indexOfFirstEvent, indexOfLastEvent);

    function handleFilterNameChange(event) {
      setFilterName(event.target.value);
    }
    
    function handleFilterEventCoordinatorName(event) {
      setEventCoordinatorName(event.target.value);
    }
    
    function handleFilterEventCoordinatorSurname(event) {
      setEventCoordinatorSurname(event.target.value);
    }
    
    function handleFilterSubmit(event) {
      event.preventDefault();
    }
    
    function handlePageChange(page) {
      setCurrentPage(page);
    }

    const deleteEvent = async (eventId,e)  => {
      e.preventDefault();

      try {
        fetch(`https://localhost:7107/api/events/${eventId}`, {
          method: "DELETE",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify({
            id: eventId
          }),
        });
      } catch (error) {
        console.error("Error:", error);
      }
  
      navigate("/events");
    }
    
    // Render pagination buttons
    const pageNumbers = [];
    for (let i = 1; i <= Math.ceil(events.length / eventsPerPage); i++) {
      pageNumbers.push(i);
    }

    const renderPageNumbers = pageNumbers.map(number => {
      return (
        <button key={number} onClick={() => paginate(number)} className="mx-1 py-1 px-3 rounded-md font-medium text-sm text-white dark:bg-gray-500 hover:bg-gray-400 focus:outline-none focus:bg-indigo-500">
          {number}
        </button>
      );
    });

    const paginationDiv = (currentPage,pageNumbers) => {
      if(currentPage === 1){
          return (
              <div className="my-4 flex justify-center items-center">
                <ul className="mx-3 rounded-md bg-gray-300 dark:bg-gray-700">{renderPageNumbers}</ul>
            </div>
          )
      }
      else{
        return (
          <div className="my-4 flex justify-center items-center">
            <button
              disabled={currentPage === 10}
              onClick={() => handlePageChange(currentPage - 1)}
              className="relative inline-flex items-center px-2 py-2 rounded-l-md border border-gray-300 dark:bg-gray-100  text-sm leading-5 font-medium text-gray-500 hover:text-gray-400 focus:z-10 focus:outline-none"
            >
              Previous
            </button>
            <ul className="mx-3 rounded-md bg-gray-300 dark:bg-gray-700">{renderPageNumbers}</ul>
            <button
              disabled={currentPage === pageNumbers.length}
              onClick={() => handlePageChange(currentPage + 1)}
              className="relative inline-flex items-center px-2 py-2 rounded-r-md border border-gray-300 dark:bg-gray-100  text-sm leading-5 font-medium text-gray-500 hover:text-gray-400 focus:z-10 focus:outline-none"
            >
              Next
            </button>
        </div>
      )
      }
    }

    useEffect(() => {
      populateEventsData();
    }, []);
  
    function renderEventsTable(events) {
      return (
        <div>
          <form onSubmit={handleFilterSubmit} className="flex md:w-2/3 items-center mx-10 py-3 px-5 sm:w-full bg-gray-50 dark:bg-gray-800 rounded-md dark:rounded-none shadow-md dark:shadow-none">
            <label htmlFor="filterName" className="block font-medium  text-sm text-gray-700 dark:text-gray-50">Filter by Name:</label>
            <input
              type="text"
              id="filterName"
              value={filterName}
              onChange={handleFilterNameChange}
              className="ml-3 w-1/3 py-2 px-3 leading-tight text-gray-700 border rounded-md shadow-sm focus:outline-none focus:shadow-outline-blue focus:border-blue-300"
            />
          <label htmlFor="filterEventCoordinatorName" className="hidden md:block pl-5 font-medium  text-sm text-gray-700 dark:text-gray-50">Coordinator name:</label>
          <input
              type="text"
              id="filterEventCoordinatorName"
              value={filterEventCoordinatorName}
              onChange={handleFilterEventCoordinatorName}
              className="hidden md:block ml-3 w-1/3 py-2 px-3 leading-tight text-gray-700 border rounded-md shadow-sm focus:outline-none focus:shadow-outline-blue focus:border-blue-300"
            />
          <label htmlFor="filterEventCoordinatorSurname" className="block pl-5 font-medium  text-sm text-gray-700 dark:text-gray-50">Coordinator surname:</label>
          <input
              type="text"
              id="filterEventCoordinatorSurname"
              value={filterEventCoordinatorSurname}
              onChange={handleFilterEventCoordinatorSurname}
              className="ml-3 w-1/3 py-2 px-3 leading-tight text-gray-700 border rounded-md shadow-sm focus:outline-none focus:shadow-outline-blue focus:border-blue-300"
            />
          </form>
          <div className='m-8  relative overflow-x-auto shadow-md sm:rounded-lg bg-white'>
            <table className="w-full text-sm text-left text-gray-500 dark:text-gray-400">
              <thead className='text-xs text-gray-700 uppercase dark:text-gray-400'>
                <tr>
                  <th scope="col" className="px-6 py-3 bg-gray-50 dark:bg-gray-800">Name</th>
                  <th scope="col" className="px-6 py-3 sm:w-1/6">Date</th>
                  <th scope="col" className="px-6 py-3 bg-gray-50 dark:bg-gray-800">Location</th>
                  <th scope="col" className="px-6 py-3">Description</th>
                  <th scope="col" className="px-6 py-3 bg-gray-50 dark:bg-gray-800">Event Coordinator</th>
                  <th scope="col" className="px-6 py-3">Planned people</th>
                  <th scope="col" className="px-6 py-3 bg-gray-50 dark:bg-gray-800">Showed people</th>
                  <th scope="col" className="px-6 py-3">Type</th>
                  <th scope="col" className="px-6 py-3 bg-gray-50 dark:bg-gray-800"></th>
                </tr>
              </thead>
              <tbody>
                { events
                      .filter(event => event.name.toLowerCase().includes(filterName.toLowerCase()))
                      .filter(event => event.coordinatorName.toLowerCase().includes(filterEventCoordinatorName.toLowerCase()))
                      .filter(event => event.coordinatorSurname.toLowerCase().includes(filterEventCoordinatorSurname.toLowerCase()))
                      .sort((a,b) => b.id - a.id)
                      .slice((currentPage - 1) * eventsPerPage, currentPage * eventsPerPage)
                      .map((event) => (
                  <tr key={event.id} className="border-b border-gray-200 dark:border-gray-700">
                    <th scope="row" className="px-6 py-4 font-medium text-gray-900 whitespace-nowrap bg-gray-50 dark:text-white dark:bg-gray-800">{event.name}</th>
                    <td className="px-6 py-4">
                      {event.startDate} / {event.endDate}
                    </td>
                    <td className="px-6 py-4 bg-gray-50 dark:bg-gray-800">{event.location}</td>
                    <td className="px-6 py-4">{event.description}</td>
                    <td className="px-6 py-4 bg-gray-50 dark:bg-gray-800">
                      {event.coordinatorName} {event.coordinatorSurname}
                    </td>
                    <td className="px-6 py-4">{event.plannedPeopleCount}</td>
                    <td className="px-6 py-4 bg-gray-50 dark:bg-gray-800">{event.showedPeopleCount}</td>
                    <td className="px-6 py-4">{event.eventType}</td>
                    <td className="px-6 py-4 bg-gray-50 dark:bg-gray-800">
                      <Link key={event.id}  to={`/events/${event.id}`} className="text-white bg-gray-800 border border-gray-300 focus:outline-none 
                      hover:bg-gray-100 hover:text-black focus:ring-4 focus:ring-gray-200 font-medium rounded-lg text-sm px-5 py-2.5 mr-2 mb-2
                      dark:bg-gray-800 dark:text-white  dark:border-gray-600 dark:hover:bg-gray-700 dark:hover:border-gray-600 dark:focus:ring-gray-700"
                      >Edit</Link>
                        <Link  to={`/events`} onClick={(e) => deleteEvent(event.id,e)} className="text-white bg-red-300 border border-gray-300 focus:outline-none 
                        hover:bg-red-400 hover:text-black focus:ring-4 focus:ring-gray-200 font-medium rounded-lg text-sm px-5 py-2.5 mr-2 mb-2
                        dark:bg-red-900 dark:text-white  dark:border-gray-600 dark:hover:bg-red-700 dark:hover:border-gray-600 dark:focus:ring-gray-700"
                        >Delete</Link>                      
                    </td>
                  </tr>
                ))}
              </tbody>
            </table>
          </div>
        </div>
      );
    }
    return (
      <div>
        <p id="tabelLabel" className='my-7 ml-10 text-3xl font-bold tracking-tight text-gray-900 dark:text-white'>Events</p>
          {loading ? <p className='mt-7 ml-10'><em>Loading...</em></p> : renderEventsTable(events)}
          {paginationDiv(currentPage, pageNumbers)}
      </div>
    );
  
    async function populateEventsData() {
      const response = await fetch('https://localhost:7107/api/events');
      const data = await response.json();
      setEvents(data);
      setLoading(false);
    }
  }