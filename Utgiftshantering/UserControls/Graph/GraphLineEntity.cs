using System;
using System.Collections.Generic;

namespace Utgiftshantering.UserControls.Graph
{
    [Serializable()]
    public class GraphLineEntity
    {
        public GraphLineEntity()
        {
        }

        public GraphLineEntity(string description, string lineColor, List<double> values)
        {
            Description = description;
            LineColor = lineColor;
            Values = values;
        }

        public string Description { get; set; }
        public string LineColor { get; set; }
        public List<double> Values { get; set; }
    }
}
