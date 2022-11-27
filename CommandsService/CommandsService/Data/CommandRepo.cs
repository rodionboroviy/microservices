using System.Collections.Generic;
using CommandsService.Models;

namespace CommandsService.Data
{
    public class CommandRepo : ICommandRepo
    {
        public IEnumerable<Platform> GetAllPlatforms()
        {
            throw new System.NotImplementedException();
        }
    }
}