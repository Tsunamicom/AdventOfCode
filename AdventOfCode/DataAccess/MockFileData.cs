using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode.DataAccess
{
    public class MockFileData : IDataAccess
    {
        readonly string _details;

        public MockFileData(string details)
        {
            _details = details;
        }

        public Task<List<string>> GetTestFileDetails()
        {
            return Task.Run(() => _details.Split(',').ToList());
        }
    }
}
