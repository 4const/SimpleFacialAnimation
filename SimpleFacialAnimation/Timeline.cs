using System.Collections.Generic;
using System.Linq;

namespace SimpleFacialAnimation
{
    class Timeline
    {
        public Timeline(Dictionary<string, Expression> expressions)
        {
            Expressions = expressions;
            Movements = new List<Movement>();
        }

        public Dictionary<string, Expression> Expressions { get; private set; }
        public List<Movement> Movements { get; private set; }

        public void AddMovement(Movement movement)
        {
            if (TimelineUtils.HasIntersection(Movements, movement))
            {
                throw new SfaException("Пересечение интервалов перемещения объекта: " + movement.ObjectId);
            }
            Movements.Add(movement);
            Movements.Sort((l, r) => l.Start.CompareTo(r.Start));
        }

        public void AddExpressionUsage(ExpressionUsage usage)
        {
            var expression = Expressions[usage.EspressionId];
            var expressionMovements =
                expression.Movements.Select(
                    m => new Movement(m.ObjectId, m.Start + usage.Start, m.End + usage.Start, m.Value));

            expressionMovements.ToList().ForEach(AddMovement);
        }

    }
}
