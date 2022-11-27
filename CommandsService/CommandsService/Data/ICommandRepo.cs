using System.Collections.Generic;
using CommandsService.Models;

namespace CommandsService.Data
{
    public interface ICommandRepo
    {
        IEnumerable<Platform> GetAllPlatforms();
    } 
}