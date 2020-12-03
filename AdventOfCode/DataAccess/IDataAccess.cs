using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventOfCode.DataAccess
{
    public interface IDataAccess
    {
        Task<List<string>> GetTestFileDetails();
    }
}
