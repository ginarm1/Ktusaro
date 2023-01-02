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

        internal static string Create()
        {
            return @"INSERT INTO public.event_member(is_event_coordinator,event_id,user_id)
	                 VALUES (@IsEventCoordinator,@EventId,@UserId)
                     RETURNING id";
        }

        internal static string Update()
        {
            return @"UPDATE public.event_member 
	                 SET is_event_coordinator=@IsEventCoordinator
                     WHERE event_id=@EventId AND user_id=@UserId
                     RETURNING id";
        }

        internal static string Delete()
        {
            return @"DELETE
	                FROM public.event_member
                    WHERE id=@Id
                    RETURNING id";
        }
    }
}
