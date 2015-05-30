using System.Collections.Generic;

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
