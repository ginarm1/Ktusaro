import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";

export const EditEvent = (props) => {
  const { id } = useParams();
  const navigate = useNavigate();
  const [errors, setErrors] = useState([]);
  const [editEvent, setEditEvent] = useState([]);
  const [changed, setChanged] = useState(false);
  const [loading, setLoading] = useState(true);

  const eventTypes = [
    { value: 1, label: "Vidinis", index: 1 },
    { value: 2, label: "Masinis", index: 2 },
    { value: 3, label: "Komercinis", index: 3 },
    { value: 4, label: "Fakultetinis", index: 4 },
    { value: 5, label: "Tarpastovybinis", index: 5 },
  ];

  useEffect(() => {
    fetchEventData();
  }, [id]);

  const fetchEventData = async () => {
    const response = await fetch(`https://localhost:7107/api/events?Id=${id}`);
    const data = await response.json();
    setEditEvent(data[0]);
    setLoading(false);

    let type = eventTypes.find(
      (eventType) => eventType.label === data[0].eventType
    );
    data[0].eventType = type.value;
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    let newErrors = [];

    const pattern = /[^a-zA-Z ]/;
    
    if (pattern.test(editEvent.name)) {
        newErrors.push("Name should only contain letters and spaces");
    }

    if(editEvent.startDate > editEvent.endDate){
        newErrors.push("Stard date can't be bigger than end date");
    }

    if (pattern.test(editEvent.coordinatorName)) {
        newErrors.push("Event coordinator name should only contain letters and spaces");
    }

    if (pattern.test(editEvent.coordinatorSurname)) {
        newErrors.push("Event coordinator surname should only contain letters and spaces");
    }

    if(editEvent.plannedPeopleCount > 99999){
        newErrors.push("Planned people count can't be bigger than 99999");
    }

    if(editEvent.showedPeopleCount > 99999){
        newErrors.push("Showed people count can't be bigger than 99999");
    }

    if (newErrors.length > 0) {
        setErrors(newErrors);
        return;
    }

    updateEvent(editEvent);
  };

  const Dropdown = () => {
    return (
      <div className="relative w-full lg:max-w-sm">
        <select
          value={editEvent.eventType}
          onChange={(e) => {
            setChanged(true);
            setEditEvent({ ...editEvent, eventType: e.target.value });
          }}
          className="w-full p-2.5 dark:bg-gray-700 dark:text-white text-gray-500 bg-white border rounded-md shadow-sm outline-none appearance-none focus:border-indigo-600"
        >
          {eventTypes.map((opt, index) => (
            <option key={opt.value} value={opt.value}>
              {opt.label}
            </option>
          ))}
        </select>
      </div>
    );
  };

  const updateEvent = (tempEvent) => {
    try {
      fetch(`https://localhost:7107/api/events/${tempEvent.id}`, {
        method: "PUT",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          name: tempEvent.name,
          location: tempEvent.location,
          startDate: tempEvent.startDate,
          endDate: tempEvent.endDate,
          description: tempEvent.description,
          isCanceled: tempEvent.isCanceled,
          coordinatorName: tempEvent.coordinatorName,
          coordinatorSurname: tempEvent.coordinatorSurname,
          plannedPeopleCount: tempEvent.plannedPeopleCount,
          showedPeopleCount: tempEvent.showedPeopleCount,
          eventType: parseInt(tempEvent.eventType),
        }),
      });
    } catch (error) {
      console.error("Error:", error);
    }

    navigate("/events");
  };

  function renderEventData() {
    return (
      <div>
        <form className="mx-10" onSubmit={handleSubmit}>
          <div className="grid md:grid-cols-3 md:gap-6">
            <div className="relative z-0 w-full pr-10 mb-6 group">
              <input
                type="text"
                value={editEvent.name}
                onChange={(e) => {
                  setChanged(true);
                  setEditEvent({ ...editEvent, name: e.target.value });
                }}
                id="floating_event_name"
                className="block py-2.5 px-0 w-full text-sm text-gray-900 bg-transparent border-0 border-b-2 border-gray-300 appearance-none dark:text-white dark:border-gray-600 dark:focus:border-blue-500 focus:outline-none focus:ring-0 focus:border-blue-600 peer"
                placeholder=" "
                required
              />
              <label
                htmlFor="floating_event_name"
                className="peer-focus:font-medium absolute text-sm text-gray-500 dark:text-gray-400 duration-300 transform -translate-y-6 scale-75 top-3 -z-10 origin-[0] peer-focus:left-0 peer-focus:text-blue-600 peer-focus:dark:text-blue-500 peer-placeholder-shown:scale-100 peer-placeholder-shown:translate-y-0 peer-focus:scale-75 peer-focus:-translate-y-6"
              >
                Title
              </label>
            </div>
            <div className="relative z-0 w-full pr-10 mb-6 group">
              <input
                type="text"
                value={editEvent.location}
                onChange={(e) => {
                  setChanged(true);
                  setEditEvent({ ...editEvent, location: e.target.value });
                }}
                id="floating_location"
                className="block py-2.5 px-0 w-full text-sm text-gray-900 bg-transparent border-0 border-b-2 border-gray-300 appearance-none dark:text-white dark:border-gray-600 dark:focus:border-blue-500 focus:outline-none focus:ring-0 focus:border-blue-600 peer"
                placeholder=" "
                required
              />
              <label
                htmlFor="floating_location"
                className="peer-focus:font-medium absolute text-sm text-gray-500 dark:text-gray-400 duration-300 transform -translate-y-6 scale-75 top-3 -z-10 origin-[0] peer-focus:left-0 peer-focus:text-blue-600 peer-focus:dark:text-blue-500 peer-placeholder-shown:scale-100 peer-placeholder-shown:translate-y-0 peer-focus:scale-75 peer-focus:-translate-y-6"
              >
                Location
              </label>
            </div>
          </div>
          <div className="grid md:grid-cols-3 md:gap-6">
            <div className="relative z-0 w-full pr-10 mb-6 group">
              <input
                type="date"
                value={editEvent.startDate}
                onChange={(e) => {
                  setChanged(true);
                  setEditEvent({ ...editEvent, startDate: e.target.value });
                }}
                id="floating_start_date"
                className="block py-2.5 px-0 w-full text-sm text-gray-900 bg-transparent border-0 border-b-2 border-gray-300 appearance-none dark:text-white dark:border-gray-600 dark:focus:border-blue-500 focus:outline-none focus:ring-0 focus:border-blue-600 peer"
                placeholder=" "
                required
              />
              <label
                htmlFor="floating_start_date"
                className="peer-focus:font-medium absolute text-sm text-gray-500 dark:text-gray-400 duration-300 transform -translate-y-6 scale-75 top-3 -z-10 origin-[0] peer-focus:left-0 peer-focus:text-blue-600 peer-focus:dark:text-blue-500 peer-placeholder-shown:scale-100 peer-placeholder-shown:translate-y-0 peer-focus:scale-75 peer-focus:-translate-y-6"
              >
                Start date
              </label>
            </div>
            <div className="relative z-0 w-full pr-10 mb-6 group">
              <input
                type="date"
                value={editEvent.endDate}
                onChange={(e) => {
                  setChanged(true);
                  setEditEvent({ ...editEvent, endDate: e.target.value });
                }}
                id="floating_end_date"
                className="block py-2.5 px-0 w-full text-sm text-gray-900 bg-transparent border-0 border-b-2 border-gray-300 appearance-none dark:text-white dark:border-gray-600 dark:focus:border-blue-500 focus:outline-none focus:ring-0 focus:border-blue-600 peer"
                placeholder=" "
                required
              />
              <label
                htmlFor="floating_end_date"
                className="peer-focus:font-medium absolute text-sm text-gray-500 dark:text-gray-400 duration-300 transform -translate-y-6 scale-75 top-3 -z-10 origin-[0] peer-focus:left-0 peer-focus:text-blue-600 peer-focus:dark:text-blue-500 peer-placeholder-shown:scale-100 peer-placeholder-shown:translate-y-0 peer-focus:scale-75 peer-focus:-translate-y-6"
              >
                End date
              </label>
            </div>
          </div>
          <div className="relative z-0 w-3/5 mb-6 group">
            <input
              type="text"
              value={editEvent.description}
              onChange={(e) => {
                setChanged(true);
                setEditEvent({ ...editEvent, description: e.target.value });
              }}
              id="floating_description"
              className="block py-2.5 px-0 w-full text-sm text-gray-900 bg-transparent border-0 border-b-2 border-gray-300 appearance-none dark:text-white dark:border-gray-600 dark:focus:border-blue-500 focus:outline-none focus:ring-0 focus:border-blue-600 peer"
              placeholder=" "
              required
            />
            <label
              htmlFor="floating_description"
              className="peer-focus:font-medium absolute text-sm text-gray-500 dark:text-gray-400 duration-300 transform -translate-y-6 scale-75 top-3 -z-10 origin-[0] peer-focus:left-0 peer-focus:text-blue-600 peer-focus:dark:text-blue-500 peer-placeholder-shown:scale-100 peer-placeholder-shown:translate-y-0 peer-focus:scale-75 peer-focus:-translate-y-6"
            >
              Description
            </label>
          </div>
          <div className="grid md:grid-cols-3 md:gap-6">
            <div className="relative z-0 w-full pr-10 mb-6 group">
              <input
                type="checkbox"
                value={editEvent.isCanceled}
                onChange={(e) => {
                  setChanged(true);
                  setEditEvent({ ...editEvent, isCanceled: e.target.value });
                }}
                id="floating_is_canceled"
                className="w-4 h-4 text-blue-600 bg-gray-100 border-gray-300 rounded focus:ring-blue-500 dark:focus:ring-blue-600 dark:ring-offset-gray-800 focus:ring-2 dark:bg-gray-700 dark:border-gray-600"
              />
              <label
                htmlFor="floating_is_canceled"
                className="ml-2 text-sm font-medium text-gray-900 dark:text-gray-300"
              >
                Is canceled
              </label>
            </div>
          </div>
          <p className="my-7 text-2xl font-bold tracking-tight text-gray-900 dark:text-white">
            Event coordinator
          </p>
          <div className="grid md:grid-cols-3 md:gap-6">
            <div className="relative z-0 w-full pr-10 mb-6 group">
              <input
                type="text"
                value={editEvent.coordinatorName}
                onChange={(e) => {
                  setChanged(true);
                  setEditEvent({
                    ...editEvent,
                    coordinatorName: e.target.value,
                  });
                }}
                id="floating_event_coordinator_name"
                className="block py-2.5 px-0 w-full text-sm text-gray-900 bg-transparent border-0 border-b-2 border-gray-300 appearance-none dark:text-white dark:border-gray-600 dark:focus:border-blue-500 focus:outline-none focus:ring-0 focus:border-blue-600 peer"
                placeholder=" "
                required
              />
              <label
                htmlFor="floating_event_coordinator_name"
                className="peer-focus:font-medium absolute text-sm text-gray-500 dark:text-gray-400 duration-300 transform -translate-y-6 scale-75 top-3 -z-10 origin-[0] peer-focus:left-0 peer-focus:text-blue-600 peer-focus:dark:text-blue-500 peer-placeholder-shown:scale-100 peer-placeholder-shown:translate-y-0 peer-focus:scale-75 peer-focus:-translate-y-6"
              >
                Name
              </label>
            </div>
            <div className="relative z-0 w-full pr-10 mb-6 group">
              <input
                type="text"
                value={editEvent.coordinatorSurname}
                onChange={(e) => {
                  setChanged(true);
                  setEditEvent({
                    ...editEvent,
                    coordinatorSurname: e.target.value,
                  });
                }}
                id="floating_event_coordinator_surname"
                className="block py-2.5 px-0 w-full text-sm text-gray-900 bg-transparent border-0 border-b-2 border-gray-300 appearance-none dark:text-white dark:border-gray-600 dark:focus:border-blue-500 focus:outline-none focus:ring-0 focus:border-blue-600 peer"
                placeholder=" "
                required
              />
              <label
                htmlFor="floating_event_coordinator_surname"
                className="peer-focus:font-medium absolute text-sm text-gray-500 dark:text-gray-400 duration-300 transform -translate-y-6 scale-75 top-3 -z-10 origin-[0] peer-focus:left-0 peer-focus:text-blue-600 peer-focus:dark:text-blue-500 peer-placeholder-shown:scale-100 peer-placeholder-shown:translate-y-0 peer-focus:scale-75 peer-focus:-translate-y-6"
              >
                Surname
              </label>
            </div>
          </div>
          <div className="grid md:grid-cols-3 md:gap-6">
            <div className="relative z-0 w-1/2 mb-6 group">
              <input
                type="number"
                value={editEvent.plannedPeopleCount}
                onChange={(e) => {
                  setChanged(true);
                  setEditEvent({
                    ...editEvent,
                    plannedPeopleCount: e.target.value,
                  });
                }}
                pattern="[0-9]*"
                min="1"
                id="floating_planned_people_count"
                className="block py-2.5 px-1 w-full text-sm text-gray-900 bg-transparent border-0 border-b-2 border-gray-300 appearance-none dark:text-white dark:border-gray-600 dark:focus:border-blue-500 focus:outline-none focus:ring-0 focus:border-blue-600 peer"
                placeholder=" "
                required
              />
              <label
                htmlFor="floating_planned_people_count"
                className="peer-focus:font-medium absolute text-sm text-gray-500 dark:text-gray-400 duration-300 transform -translate-y-6 scale-75 top-3 -z-10 origin-[0] peer-focus:left-0 peer-focus:text-blue-600 peer-focus:dark:text-blue-500 peer-placeholder-shown:scale-100 peer-placeholder-shown:translate-y-0 peer-focus:scale-75 peer-focus:-translate-y-6"
              >
                Planned people
              </label>
            </div>
            <div className="relative z-0 w-1/2 mb-6 group">
              <input
                type="number"
                value={editEvent.showedPeopleCount}
                onChange={(e) => {
                  setChanged(true);
                  setEditEvent({
                    ...editEvent,
                    showedPeopleCount: e.target.value,
                  });
                }}
                pattern="[0-9]*"
                min="0"
                id="floating_showed_people_count"
                className="block py-2.5 px-1 w-full text-sm text-gray-900 bg-transparent border-0 border-b-2 border-gray-300 appearance-none dark:text-white dark:border-gray-600 dark:focus:border-blue-500 focus:outline-none focus:ring-0 focus:border-blue-600 peer"
                placeholder=" "
                required
              />
              <label
                htmlFor="floating_showed_people_count"
                className="peer-focus:font-medium absolute text-sm text-gray-500 dark:text-gray-400 duration-300 transform -translate-y-6 scale-75 top-3 -z-10 origin-[0] peer-focus:left-0 peer-focus:text-blue-600 peer-focus:dark:text-blue-500 peer-placeholder-shown:scale-100 peer-placeholder-shown:translate-y-0 peer-focus:scale-75 peer-focus:-translate-y-6"
              >
                Showed people
              </label>
            </div>
          </div>
          <p className="my-7 text-2xl font-bold tracking-tight text-gray-900 dark:text-white">
            Event type
          </p>
          <div className="relative z-0 w-1/3 pr-10 mb-6 group">
            <Dropdown />
          </div>
          {changed ? (
            <button
              className=" text-white bg-gray-800 border border-gray-300 focus:outline-none 
                        hover:bg-gray-500 focus:ring-4 focus:ring-gray-200 font-medium rounded-lg text-sm px-5 py-2.5 mr-2 mb-8
                        dark:bg-gray-800 dark:text-white dark:border-gray-600 dark:hover:bg-gray-700 dark:hover:border-gray-600 dark:focus:ring-gray-700"
            >
              Submit
            </button>
          ) : (
            <button
              disabled
              className=" text-white bg-gray-400 border border-gray-300 focus:outline-none 
                        hover:bg-gray-500 focus:ring-4 focus:ring-gray-200 font-medium rounded-lg text-sm px-5 py-2.5 mr-2 mb-8
                        dark:bg-gray-600 dark:text-white dark:border-gray-600 dark:hover:bg-gray-700 dark:hover:border-gray-600 dark:focus:ring-gray-700"
            >
              Submit
            </button>
          )}
          <button
            onClick={() => {
              navigate("/events");
            }}
            className="text-gray-900 bg-white border border-gray-300 focus:outline-none 
                        hover:bg-gray-100 focus:ring-4 focus:ring-gray-200 font-medium rounded-lg text-sm px-5 py-2.5 mr-2 mb-8
                        dark:bg-gray-500 dark:text-white dark:border-gray-600 dark:hover:bg-gray-700 dark:hover:border-gray-600 dark:focus:ring-gray-700"
          >
            Back
          </button>
        </form>
      </div>
    );
  }

  return (
    <div>
      <p className="mt-7 mb-11 ml-10 text-3xl font-bold tracking-tight text-gray-900 dark:text-white">
        Edit Event
      </p>
      {errors !== [] ? 
        errors.map((error) => (
            <div
                class="p-4 mb-8 ml-8 w-1/3 text-sm text-red-700 bg-red-100 rounded-lg dark:bg-gray-800 dark:text-red-400"
                role="alert"
            >
                <span class="font-medium">{error}.</span>
            </div>          
        ))
      :
        <></>
      }

      {loading ? (
        <p className="mt-7 ml-10">
          <em>Loading...</em>
        </p>
      ) : (
        renderEventData()
      )}
    </div>
  );
};
