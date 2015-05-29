using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFacialAnimation
{
    class Expression
    {
        public Expression(string id, List<Movement> movements)
        {
            Id = id;
            Movements = movements;
        }

        public string Id { get; private set; }
        public List<Movement> Movements { get; private set; }
    }
}
