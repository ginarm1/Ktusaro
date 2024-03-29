﻿namespace Ktusaro.Repositories.SqlCommands
{
    internal class UserRepositoryCommands
    {
        internal static string GetAll()
        {
            return @"SELECT *
	                FROM public.user";
        }

        internal static string GetById()
        {
            return @"SELECT *
	                FROM public.user
                    WHERE id=@Id";
        }

        internal static string GetByEmail()
        {
            return @"SELECT *
	                FROM public.user
                    WHERE email=@Email";
        }

        internal static string Create()
        {
            return @"INSERT INTO public.user
	                     (email,password_hash,password_salt,name,surname,role,representative)
                     VALUES 
                         (@Email,@PasswordHash,@PasswordSalt,@Name,@Surname,@Role,@Representative)
                     RETURNING id";
        }

        internal static string UpdateRoleByEmail()
        {
            return @"UPDATE public.user 
	                 SET role=@Role
                     WHERE id=@Id";
        }

        internal static string UpdateRepresentativeByEmail()
        {
            return @"UPDATE public.user 
	                 SET representative=@Representative
                     WHERE id=@Id";
        }
    }
}
