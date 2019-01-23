using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GKProjekt2
{
    public class AETPointer : IComparable<AETPointer>
    {
        public double a;
        public double x;
        public int vertex1, vertex2;
        public AETPointer(double a, double x, int vertex1, int vertex2)
        {
            this.a = a;
            this.x = x;
            this.vertex1 = vertex1;
            this.vertex2 = vertex2;
        }


        public int CompareTo(AETPointer other)
        {
            return x > other.x ? 1 : -1;
        }
    }
}
