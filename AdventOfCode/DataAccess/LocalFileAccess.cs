using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode.DataAccess
{
    public class LocalFileAccess : IDataAccess
    {
        readonly string _location;

        public LocalFileAccess(string location)
        {
            _location = location;
        }

        public async Task<List<string>> GetTestFileDetails()
        {
            var lines = await File.ReadAllLinesAsync(_location).ConfigureAwait(false);
            return lines.ToList();
        }
    }
}
