using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_1
{
    class Values
    {
        public double XStart { get; set; }
        public double XStop { get; set; }
        public double Step { get; set; }
        private int n = 0;

        public int N
        {
            get
            { return n; }
            set
            {
                if (value <= 5)
                    throw new ArgumentException("Значение должно быть больше 5");
                else
                {
                    n = value;
                }
            }
        }

        public double XSTOP
        {
            get { return XStop; }
            set
            {
                if (XStop < XStart)
                throw new ArgumentException("XStop не может быть меньше XStart!");
                else
                {
                    XStop = value;
                }
            }
        }
    }
}
