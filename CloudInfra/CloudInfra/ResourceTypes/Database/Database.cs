using System.Collections.Generic;
using System.Text;

namespace CloudInfra.ResourceTypes.Database
{
    public abstract class Database
    {
        public abstract DatabaseResource Build();
    }
}
