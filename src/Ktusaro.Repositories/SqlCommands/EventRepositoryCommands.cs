namespace Ktusaro.Repositories.SqlCommands
{
    internal static class EventRepositoryCommands
    {
        internal static string Create()
        {
            return @"INSERT INTO public.event(name,start_date,end_date,location,description,
                        coordinator_name,coordinator_surname,is_canceled,is_live,
                        planned_people_count,showed_people_count,event_type)
	                 VALUES (@Name,@StartDate,@EndDate,@Location,@Description,
                        @CoordinatorName,@CoordinatorSurname,@IsCanceled,@IsLive,
                        @PlannedPeopleCount,@ShowedPeopleCount,@EventType)
                     RETURNING id";
        }

        internal static string Update()
        {
            return @"UPDATE public.event 
	                 SET name=@Name,start_date=@StartDate,end_date=@EndDate,
                        location=@Location,description=@Description,
                        coordinator_name=@CoordinatorName,coordinator_surname=@CoordinatorSurname,
                        is_canceled=@IsCanceled,is_live=@IsLive,planned_people_count=@PlannedPeopleCount,
                        showed_people_count=@ShowedPeopleCount,event_type=@EventType
                     WHERE id=@Id
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

        internal static string Delete()
        {
            return @"DELETE
	                FROM public.event
                    WHERE id=@Id
                    RETURNING id";
        }
    }
}
