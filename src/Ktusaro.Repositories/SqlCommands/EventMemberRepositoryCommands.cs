namespace Ktusaro.Repositories.SqlCommands
{
    public class EventMemberRepositoryCommands
    {
        internal static string GetAll()
        {
            return @"SELECT *
	                FROM public.event_member";
        }

        internal static string GetById()
        {
            return @"SELECT *
	                FROM public.event_member
                    WHERE id=@Id";
        }

        internal static string GetByCoordinator()
        {
            return @"SELECT *
	                FROM public.event_member
                    WHERE is_event_coordinator=true";
        }

        internal static string Create()
        {
            return @"INSERT INTO public.event_member(is_event_coordinator,event_id,user_id)
	                 VALUES (@IsEventCoordinator,@EventId,@UserId)
                     RETURNING id";
        }
    }
}
