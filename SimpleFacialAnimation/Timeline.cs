using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFacialAnimation
{
    class Timeline
    {
        Timeline()
        {
            Expressions = new Dictionary<string, Expression>();
        }

        public Dictionary<string, Expression> Expressions { get; private set; }

        public List<Movement> Movements { get; private set; }

        public void addMovement(Movement movement)
        {

        }

        public void useExpression(Expression expression)
        {

        }

    }
}
