﻿namespace Ktusaro.Repositories.SqlCommands
{
    internal static class EventRepositoryCommands
    {
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
                    WHERE eventtype=@EventType";
        }
    }
}
