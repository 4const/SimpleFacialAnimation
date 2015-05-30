using System.Collections.Generic;
using System.Linq;

namespace SimpleFacialAnimation
{
    class Expression
    {
        public Expression(string id, IEnumerable<Movement> movements)
        {
            Id = id;
            Movements = movements;
        }

        public string Id { get; private set; }

        public IEnumerable<Movement> Movements { get; private set; }
    }
}
