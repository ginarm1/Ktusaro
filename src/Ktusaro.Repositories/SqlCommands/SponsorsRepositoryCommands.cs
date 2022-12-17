namespace Ktusaro.Repositories.SqlCommands
{
    internal class SponsorsRepositoryCommands
    {
        internal static string GetAll()
        {
            return @"SELECT *
	                FROM public.sponsor";
        }

        internal static string GetById()
        {
            return @"SELECT *
	                FROM public.sponsor
                    WHERE id=@Id";
        }
    }
}
