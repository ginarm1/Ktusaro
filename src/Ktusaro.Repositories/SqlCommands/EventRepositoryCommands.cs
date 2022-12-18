namespace Ktusaro.Repositories.SqlCommands
{
    internal static class EventRepositoryCommands
    {
        internal static string Create()
        {
            return @"INSERT INTO public.event(name,start_date,end_date,location,description,has_coordinator,coordinator_name,coordinator_surname,is_canceled,is_live,planned_people_count,showed_people_count,event_type)
	                 VALUES (@Name,@StartDate,@EndDate,@Location,@Description,@HasCoordinator,@CoordinatorName,@CoordinatorSurname,@IsCanceled,@IsLive,@PlannedPeopleCount,@ShowedPeopleCount,@EventType)
                     RETURNING id";
        }

        internal static string GetAll()
        {
            return @"SELECT *
	                FROM public.event";
        }

        internal static string GetById()
        {
            return @"SELECT *
	                FROM public.event
                    WHERE id=@Id";
        }

        internal static string GetByEventType()
        {
            return @"SELECT *
	                FROM public.event
                    WHERE event_type=@EventType";
        }
    }
}
