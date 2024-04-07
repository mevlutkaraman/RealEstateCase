using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Core.Settings
{
    public sealed class DatabaseConfigurationSettings
    {
        public string ConnectionString { get; set; } = null!;
    }
}
