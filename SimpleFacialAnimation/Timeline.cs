using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFacialAnimation
{
    class Timeline
    {
        public Timeline(Dictionary<string, Expression> expressions)
        {
            Expressions = expressions;
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
