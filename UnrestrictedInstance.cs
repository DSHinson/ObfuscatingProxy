using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testingTest
{
    public class UnrestrictedInstance : IUnrestrictedInterface
    {
        public required string Name { get; set; }

        public required string Version { get; set; }

        public string SensitiveData { get; set; }
    }
}
