import React, { Component } from 'react';

export class Events extends Component {
    constructor(props) {
        super(props);
        this.state = { events: [], loading: true };
    }

    componentDidMount() {
        this.populateEventsData();
    }

    static renderEventsTable(events) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Date</th>
                        <th>Location</th>
                        <th>Description</th>
                        <th>Event Coordinator</th>
                        <th>Is canceled</th>
                        <th>Planned people</th>
                        <th>Showed people</th>
                        <th>Type</th>
                    </tr>
                </thead>
                <tbody>
                    {events.map(event =>
                        <tr key={event.id}>
                            <td>{event.name}</td>
                            <td>{event.startDate} - {event.endDate}</td>
                            <td>{event.location}</td>
                            <td>{event.description}</td>
                            <td>{event.coordinatorName} {event.coordinatorSurname}</td>
                            <td>{event.IsCanceled}</td>
                            <td>{event.plannedPeopleCount}</td>
                            <td>{event.showedPeopleCount}</td>
                            <td>{event.eventType}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Events.renderEventsTable(this.state.events);

        return (
            <div>
                <h1 id="tabelLabel" >Events</h1>
                {contents}
            </div>
        );
    }

    async populateEventsData() {
        const response = await fetch('https://localhost:7107/api/events');
        const data = await response.json();
        this.setState({ events: data, loading: false });
    }
}