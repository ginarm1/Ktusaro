namespace Ktusaro.Repositories.SqlCommands
{
    internal class SponsorshipRepositoryCommands
    {
        internal static string GetAll()
        {
            return @"SELECT *
	                FROM public.sponsorship";
        }
    }
}
