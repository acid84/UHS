using System;
using System.Collections.Generic;

namespace Utgiftshantering.UserControls.Graph
{
    [Serializable()]
    public class GraphEntity
    {
        public string Name { get; set; }
        public List<string> XAxisValues { get; set; }
        public List<GraphLineEntity> GraphLines { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
