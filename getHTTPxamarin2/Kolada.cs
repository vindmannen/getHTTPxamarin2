using System;
using System.Collections.Generic;
using System.Text;

namespace getHTTPxamarin2
{
    

        public class Values
        {
            public Kolada[] values { get; set; }
            public int count { get; set; }
        }

        public class Kolada
        {
            public string kpi { get; set; }
            public string municipality { get; set; }
            public string period { get; set; }
            public float value { get; set; }
            public object value_m { get; set; }
            public object value_f { get; set; }
        }

    
}
