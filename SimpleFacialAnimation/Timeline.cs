using System.Collections.Generic;

namespace SimpleFacialAnimation
{
    class Timeline
    {
        public Timeline(Dictionary<string, Expression> expressions)
        {
            Expressions = expressions;
        }

        public Dictionary<string, Expression> Expressions { get; private set; }
        public IEnumerable<Movement> Movements { get; private set; }

        public void AddMovement(Movement movement)
        {

        }

        public void UseExpression(Expression expression)
        {

        }

    }
}
