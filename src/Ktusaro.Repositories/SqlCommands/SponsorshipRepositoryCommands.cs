namespace Ktusaro.Repositories.SqlCommands
{
    internal class SponsorshipRepositoryCommands
    {
        internal static string GetAll()
        {
            return @"SELECT *
	                FROM public.sponsorship";
        }

        internal static string GetById()
        {
            return @"SELECT *
	                FROM public.sponsorship
                    WHERE id=@Id";
        }

        internal static string Create()
        {
            return @"INSERT INTO public.sponsorship(description,quantity,cost,sponsor_id,event_id)
	                 VALUES (@Description,@Quantity,@Cost,@SponsorId,@EventId)
                     RETURNING id";
        }

        internal static string Update()
        {
            return @"UPDATE public.sponsorship 
	                 SET description=@Description,quantity=@Quantity,cost=Cost
                     WHERE id=@Id
                     RETURNING id";
        }
    }
}
