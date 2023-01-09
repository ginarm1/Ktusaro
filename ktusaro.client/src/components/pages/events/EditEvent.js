import { useEffect, useState } from 'react';
import { Link, useParams } from 'react-router-dom';

export const EditEvent = (props) => {
    const { id } = useParams();
    const [event, setEvent] = useState([]);
    const [loading, setLoading] = useState(true);
  
    console.log(event.startDate);
    useEffect(() => {
        populateEventData(id);
      }, []);

      function renderEventData() {
        return(
            <div>
                <form className='mx-10'>
                    <div className='grid md:grid-cols-3 md:gap-6'>
                        <div className="relative z-0 w-full pr-10 mb-6 group">
                            <input type="text" value={event.name} name="floating_event_name" id="floating_event_name" className="block py-2.5 px-0 w-full text-sm text-gray-900 bg-transparent border-0 border-b-2 border-gray-300 appearance-none dark:text-white dark:border-gray-600 dark:focus:border-blue-500 focus:outline-none focus:ring-0 focus:border-blue-600 peer" placeholder=" " required />
                            <label htmlFor="floating_event_name" className="peer-focus:font-medium absolute text-sm text-gray-500 dark:text-gray-400 duration-300 transform -translate-y-6 scale-75 top-3 -z-10 origin-[0] peer-focus:left-0 peer-focus:text-blue-600 peer-focus:dark:text-blue-500 peer-placeholder-shown:scale-100 peer-placeholder-shown:translate-y-0 peer-focus:scale-75 peer-focus:-translate-y-6">Title</label>
                        </div>
                        <div className="relative z-0 w-full pr-10 mb-6 group">
                            <input type="text" value={event.location} name="floating_location" id="floating_location" className="block py-2.5 px-0 w-full text-sm text-gray-900 bg-transparent border-0 border-b-2 border-gray-300 appearance-none dark:text-white dark:border-gray-600 dark:focus:border-blue-500 focus:outline-none focus:ring-0 focus:border-blue-600 peer" placeholder=" " required />
                            <label htmlFor="floating_location" className="peer-focus:font-medium absolute text-sm text-gray-500 dark:text-gray-400 duration-300 transform -translate-y-6 scale-75 top-3 -z-10 origin-[0] peer-focus:left-0 peer-focus:text-blue-600 peer-focus:dark:text-blue-500 peer-placeholder-shown:scale-100 peer-placeholder-shown:translate-y-0 peer-focus:scale-75 peer-focus:-translate-y-6">Location</label>
                        </div>
                    </div>
                    <div className='grid md:grid-cols-3 md:gap-6'>
                        <div className="relative z-0 w-full pr-10 mb-6 group">
                            <input type="date" value="2023-01-05" name="floating_start_date" id="floating_start_date" className="block py-2.5 px-0 w-full text-sm text-gray-900 bg-transparent border-0 border-b-2 border-gray-300 appearance-none dark:text-white dark:border-gray-600 dark:focus:border-blue-500 focus:outline-none focus:ring-0 focus:border-blue-600 peer" placeholder=" " required />
                            <label htmlFor="floating_start_date" className="peer-focus:font-medium absolute text-sm text-gray-500 dark:text-gray-400 duration-300 transform -translate-y-6 scale-75 top-3 -z-10 origin-[0] peer-focus:left-0 peer-focus:text-blue-600 peer-focus:dark:text-blue-500 peer-placeholder-shown:scale-100 peer-placeholder-shown:translate-y-0 peer-focus:scale-75 peer-focus:-translate-y-6">Start date</label>
                        </div>
                        <div className="relative z-0 w-full pr-10 mb-6 group">
                            <input type="date" value={event.endDate} name="floating_end_date" id="floating_end_date" className="block py-2.5 px-0 w-full text-sm text-gray-900 bg-transparent border-0 border-b-2 border-gray-300 appearance-none dark:text-white dark:border-gray-600 dark:focus:border-blue-500 focus:outline-none focus:ring-0 focus:border-blue-600 peer" placeholder=" " required />
                            <label htmlFor="floating_end_date" className="peer-focus:font-medium absolute text-sm text-gray-500 dark:text-gray-400 duration-300 transform -translate-y-6 scale-75 top-3 -z-10 origin-[0] peer-focus:left-0 peer-focus:text-blue-600 peer-focus:dark:text-blue-500 peer-placeholder-shown:scale-100 peer-placeholder-shown:translate-y-0 peer-focus:scale-75 peer-focus:-translate-y-6">End date</label>
                        </div>
                    </div>
                    <div className="relative z-0 w-3/5 mb-6 group">
                        <input type="text" value={event.description} name="floating_description" id="floating_description" className="block py-2.5 px-0 w-full text-sm text-gray-900 bg-transparent border-0 border-b-2 border-gray-300 appearance-none dark:text-white dark:border-gray-600 dark:focus:border-blue-500 focus:outline-none focus:ring-0 focus:border-blue-600 peer" placeholder=" " required />
                        <label htmlFor="floating_description" className="peer-focus:font-medium absolute text-sm text-gray-500 dark:text-gray-400 duration-300 transform -translate-y-6 scale-75 top-3 -z-10 origin-[0] peer-focus:left-0 peer-focus:text-blue-600 peer-focus:dark:text-blue-500 peer-placeholder-shown:scale-100 peer-placeholder-shown:translate-y-0 peer-focus:scale-75 peer-focus:-translate-y-6">Description</label>
                    </div>
                    <p className='my-7 text-2xl font-bold tracking-tight text-gray-900 dark:text-white'>Event coordinator</p>
                    <div className='grid md:grid-cols-3 md:gap-6'>
                        <div className="relative z-0 w-full pr-10 mb-6 group">
                            <input type="text" value={event.coordinatorName} name="floating_event_coordinator_name" id="floating_event_coordinator_name" className="block py-2.5 px-0 w-full text-sm text-gray-900 bg-transparent border-0 border-b-2 border-gray-300 appearance-none dark:text-white dark:border-gray-600 dark:focus:border-blue-500 focus:outline-none focus:ring-0 focus:border-blue-600 peer" placeholder=" " required />
                            <label htmlFor="floating_event_coordinator_name" className="peer-focus:font-medium absolute text-sm text-gray-500 dark:text-gray-400 duration-300 transform -translate-y-6 scale-75 top-3 -z-10 origin-[0] peer-focus:left-0 peer-focus:text-blue-600 peer-focus:dark:text-blue-500 peer-placeholder-shown:scale-100 peer-placeholder-shown:translate-y-0 peer-focus:scale-75 peer-focus:-translate-y-6">Name</label>
                        </div>
                        <div className="relative z-0 w-full pr-10 mb-6 group">
                            <input type="text" value={event.coordinatorSurname} name="floating_event_coordinator_surname" id="floating_event_coordinator_surname" className="block py-2.5 px-0 w-full text-sm text-gray-900 bg-transparent border-0 border-b-2 border-gray-300 appearance-none dark:text-white dark:border-gray-600 dark:focus:border-blue-500 focus:outline-none focus:ring-0 focus:border-blue-600 peer" placeholder=" " required />
                            <label htmlFor="floating_event_coordinator_surname" className="peer-focus:font-medium absolute text-sm text-gray-500 dark:text-gray-400 duration-300 transform -translate-y-6 scale-75 top-3 -z-10 origin-[0] peer-focus:left-0 peer-focus:text-blue-600 peer-focus:dark:text-blue-500 peer-placeholder-shown:scale-100 peer-placeholder-shown:translate-y-0 peer-focus:scale-75 peer-focus:-translate-y-6">Surname</label>
                        </div>
                    </div>
                    <div className="grid md:grid-cols-3 md:gap-6">
                        <div className="relative z-0 w-1/3 mb-6 group">
                            <input type="number" value={event.plannedPeopleCount} pattern="[0-9]*" min="1" name="floating_planned_people_count" id="floating_planned_people_count" className="block py-2.5 px-1 w-full text-sm text-gray-900 bg-transparent border-0 border-b-2 border-gray-300 appearance-none dark:text-white dark:border-gray-600 dark:focus:border-blue-500 focus:outline-none focus:ring-0 focus:border-blue-600 peer" placeholder=" " required />
                            <label htmlFor="floating_planned_people_count" className="peer-focus:font-medium absolute text-sm text-gray-500 dark:text-gray-400 duration-300 transform -translate-y-6 scale-75 top-3 -z-10 origin-[0] peer-focus:left-0 peer-focus:text-blue-600 peer-focus:dark:text-blue-500 peer-placeholder-shown:scale-100 peer-placeholder-shown:translate-y-0 peer-focus:scale-75 peer-focus:-translate-y-6">Planned people</label>
                        </div>
                        <div className="relative z-0 w-1/3 mb-6 group">
                            <input type="number" value={event.showedPeopleCount} pattern="[0-9]*" min="0" name="floating_showed_people_count" id="floating_showed_people_count" className="block py-2.5 px-1 w-full text-sm text-gray-900 bg-transparent border-0 border-b-2 border-gray-300 appearance-none dark:text-white dark:border-gray-600 dark:focus:border-blue-500 focus:outline-none focus:ring-0 focus:border-blue-600 peer" placeholder=" " required />
                            <label htmlFor="floating_showed_people_count" className="peer-focus:font-medium absolute text-sm text-gray-500 dark:text-gray-400 duration-300 transform -translate-y-6 scale-75 top-3 -z-10 origin-[0] peer-focus:left-0 peer-focus:text-blue-600 peer-focus:dark:text-blue-500 peer-placeholder-shown:scale-100 peer-placeholder-shown:translate-y-0 peer-focus:scale-75 peer-focus:-translate-y-6">Showed people</label>
                        </div>
                    </div>
                    <div className="relative z-0 w-1/3 pr-10 mb-6 group">
                        <input type="text" value={event.eventType} name="floating_event_type" id="floating_event_type" className="block py-2.5 px-0 w-full text-sm text-gray-900 bg-transparent border-0 border-b-2 border-gray-300 appearance-none dark:text-white dark:border-gray-600 dark:focus:border-blue-500 focus:outline-none focus:ring-0 focus:border-blue-600 peer" placeholder=" " required />
                        <label htmlFor="floating_event_type" className="peer-focus:font-medium absolute text-sm text-gray-500 dark:text-gray-400 duration-300 transform -translate-y-6 scale-75 top-3 -z-10 origin-[0] peer-focus:left-0 peer-focus:text-blue-600 peer-focus:dark:text-blue-500 peer-placeholder-shown:scale-100 peer-placeholder-shown:translate-y-0 peer-focus:scale-75 peer-focus:-translate-y-6">Event type</label>
                    </div>

                    <button type="submit" className=" text-white bg-gray-800 border border-gray-300 focus:outline-none 
                        hover:bg-gray-500 focus:ring-4 focus:ring-gray-200 font-medium rounded-lg text-sm px-5 py-2.5 mr-2 mb-8
                        dark:bg-gray-800 dark:text-white dark:border-gray-600 dark:hover:bg-gray-700 dark:hover:border-gray-600 dark:focus:ring-gray-700"
                        disabled>Submit</button>
                        
                    <Link to={`/events`} className=" text-gray-900 bg-white border border-gray-300 focus:outline-none 
                        hover:bg-gray-100 focus:ring-4 focus:ring-gray-200 font-medium rounded-lg text-sm px-5 py-2.5 mr-2 mb-8
                        dark:bg-gray-500 dark:text-white dark:border-gray-600 dark:hover:bg-gray-700 dark:hover:border-gray-600 dark:focus:ring-gray-700"
                        >Back</Link>
                </form>
            </div>
        )
      }

      return (
        <div>
          <p className='mt-7 mb-11 ml-10 text-3xl font-bold tracking-tight text-gray-900 dark:text-white'>Edit Event</p>
            {loading ? <p className='mt-7 ml-10'><em>Loading...</em></p> : renderEventData()}
        </div>
      );

      async function populateEventData(id) {
        const response = await fetch(`https://localhost:7107/api/events?Id=${id}`);
        const data = await response.json();
        setEvent(data[0]);
        setLoading(false);
      }
}