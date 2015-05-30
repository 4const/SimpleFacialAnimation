using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace SimpleFacialAnimation
{
    abstract class TimelineParser
    {
        public static Timeline Parse(string text)
        {            
            var root = XElement.Parse(text);

            var expressionNodes = root.Elements("expr");
            var mainNode = root.Element("main");

            if (mainNode == null)
            {
                throw new SfaException("Не найден тег <main>");
            }

            var expressions = ParseExpressions(expressionNodes);
            var timeline = new Timeline(expressions);

            var movements = ParseMovements(mainNode.Elements("mov"));
            var expressionUsages = ParseExpressionUsages(mainNode.Elements("use"));

            movements.ToList().ForEach(timeline.AddMovement);
            expressionUsages.ToList().ForEach(timeline.AddExpressionUsage);
            
            return timeline;
        }

        private static Dictionary<string, Expression> ParseExpressions(IEnumerable<XElement> expressionNodes)
        {
            var map = new Dictionary<string, Expression>();          
            foreach (var expression in expressionNodes.Select(ParseExpression))
            {
                if (map.ContainsKey(expression.Id))
                {
                    throw new SfaException("Несколько тегов expr с id = " + expression.Id);
                }
                map.Add(expression.Id, expression);
            }

            return map;
        }

        private static Expression ParseExpression(XElement expressionNode)
        {
            var id = expressionNode.Attribute("id").Value;
            var movements = ParseMovements(expressionNode.Elements("mov"));

            return new Expression(id, movements);
        }

        private static IEnumerable<Movement> ParseMovements(IEnumerable<XElement> movementNodes)
        {
            var list = new List<Movement>();          
            foreach (var movement in movementNodes.Select(ParseMovement))
            {
                if (TimelineUtils.HasIntersection(list, movement))
                {
                    throw new SfaException("Пересечение интервалов перемещения объекта: " + movement.ObjectId);
                }
                list.Add(movement);
            }

            return list;
        }

        private static Movement ParseMovement(XElement movementNode)
        {
            var id = movementNode.Attribute("id").Value;
            var start = int.Parse(movementNode.Attribute("start").Value);
            var end = int.Parse(movementNode.Attribute("end").Value);
            var value = float.Parse(movementNode.Attribute("value").Value);

            if (start >= end)
            {
                throw new SfaException("У перемещения: " + id + " момент начала позже чем момент окончания.");
            }

            return new Movement(id, start, end, value);
        }

        private static IEnumerable<ExpressionUsage> ParseExpressionUsages(IEnumerable<XElement> usagesNodes)
        {
            return usagesNodes.Select(n => new ExpressionUsage(
                n.Attribute("expr").Value, 
                int.Parse(n.Attribute("start").Value)));
        }
    }
}
