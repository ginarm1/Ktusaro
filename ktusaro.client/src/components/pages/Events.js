import { useState, useEffect } from 'react';

export const Events = () => {
    const [events, setEvents] = useState([]);
    const [loading, setLoading] = useState(true);
  
    useEffect(() => {
      populateEventsData();
    }, []);
  
    function renderEventsTable(events) {
      return (
        <div className='pl-4 relative overflow-x-auto shadow-md sm:rounded-lg bg-white'>
          <table className="w-full text-sm text-left text-gray-500 dark:text-gray-400">
            <thead className='text-xs text-gray-700 uppercase dark:text-gray-400'>
              <tr>
                <th scope="col" class="px-6 py-3 bg-gray-50 dark:bg-gray-800">Name</th>
                <th scope="col" class="px-6 py-3">Date</th>
                <th scope="col" class="px-6 py-3 bg-gray-50 dark:bg-gray-800">Location</th>
                <th scope="col" class="px-6 py-3">Description</th>
                <th scope="col" class="px-6 py-3 bg-gray-50 dark:bg-gray-800">Event Coordinator</th>
                <th scope="col" class="px-6 py-3">Planned people</th>
                <th scope="col" class="px-6 py-3 bg-gray-50 dark:bg-gray-800">Showed people</th>
                <th scope="col" class="px-6 py-3">Type</th>
              </tr>
            </thead>
            <tbody>
              {events.map((event) => (
                <tr key={event.id} className="border-b border-gray-200 dark:border-gray-700">
                  <th scope="row" class="px-6 py-4 font-medium text-gray-900 whitespace-nowrap bg-gray-50 dark:text-white dark:bg-gray-800">{event.name}</th>
                  <td class="px-6 py-4">
                    {event.startDate} - {event.endDate}
                  </td>
                  <td class="px-6 py-4 bg-gray-50 dark:bg-gray-800">{event.location}</td>
                  <td class="px-6 py-4">{event.description}</td>
                  <td class="px-6 py-4 bg-gray-50 dark:bg-gray-800">
                    {event.coordinatorName} {event.coordinatorSurname}
                  </td>
                  <td class="px-6 py-4">{event.plannedPeopleCount}</td>
                  <td class="px-6 py-4 bg-gray-50 dark:bg-gray-800">{event.showedPeopleCount}</td>
                  <td class="px-6 py-4">{event.eventType}</td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      );
    }
  
    return (
      <div>
        <h1 id="tabelLabel" className='m-4 ml-9 text-3xl font-extrabold leading-none tracking-tight text-gray-900 md:text-4x'>Events</h1>
        {loading ? <p><em>Loading...</em></p> : renderEventsTable(events)}
      </div>
    );
  
    async function populateEventsData() {
      const response = await fetch('https://localhost:7107/api/events');
      const data = await response.json();
      setEvents(data);
      setLoading(false);
    }
  }