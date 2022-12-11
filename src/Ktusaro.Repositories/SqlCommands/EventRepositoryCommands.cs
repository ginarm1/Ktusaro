using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ktusaro.Repositories.SqlCommands
{
    internal static class EventRepositoryCommands
    {
        internal static string GetAll()
        {
            return @"SELECT *
	                FROM public.\""event\"" ";
        }
    }
}
