using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace task_2
{

    [Serializable]

    class Staff
    {
        public string fName { get; set; }
        public string lName { get; set; }
        public int sallary { get; set; }
        public string city { get; set; }
        public string street { get; set; }
        public string position { get; set; }
        public string home { get; set; }

        public void WriteToFile(string path)
        {
            string resultStaff = fName.ToString() + " " + lName + " " + city + " " + street + " " + home + " " + position + " " + sallary.ToString(); ;
            using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
            {
                sw.WriteLine(resultStaff);
            }
        }

    }
}
