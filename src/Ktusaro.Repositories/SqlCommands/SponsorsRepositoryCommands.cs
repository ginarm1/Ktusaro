namespace Ktusaro.Repositories.SqlCommands
{
    internal class SponsorsRepositoryCommands
    {
        internal static string Create()
        {
            return @"INSERT INTO public.sponsor(name,company_type)
	                 VALUES (@Name,@CompanyType)
                     RETURNING id";
        }

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

        internal static string Update()
        {
            return @"UPDATE public.sponsor 
	                 SET name=@Name,company_type=@CompanyType
                     WHERE id=@Id
                     RETURNING id";
        }

        internal static string Delete()
        {
            return @"DELETE
	                FROM public.sponsor
                    WHERE id=@Id
                    RETURNING id";
        }
    }
}
