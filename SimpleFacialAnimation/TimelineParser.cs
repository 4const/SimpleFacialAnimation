using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Xml.Linq;

namespace SimpleFacialAnimation
{
    class TimelineParser
    {
        public static Timeline Parse(string text)
        {            
            var root = XElement.Parse(text);

            var expressionNodes = root.Elements("expr");
            var mainNode = root.Element("main");

            if (mainNode == null)
            {
                throw new SfaParsingException("Не найден тег <main>");
            }

            var expressions = ParseExpressions(expressionNodes);
            var timeline = new Timeline(expressions);

            return timeline;
        }

        private static Dictionary<string, Expression> ParseExpressions(IEnumerable<XElement> expressionNodes)
        {
            var map = new Dictionary<string, Expression>();
            
            foreach (var expression in expressionNodes.Select(ParseExpression))
            {
                if (map.ContainsKey(expression.Id))
                {
                    throw new SfaParsingException("Несколько тегов expr с id = " + expression.Id);
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
                if (HasIntersection(list, movement))
                {
                    throw new SfaParsingException("Пересечение интервалов перемещения объекта: " + movement.ObjectId);
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

            return new Movement(id, start, end, value);
        }

        private static bool HasIntersection(IEnumerable<Movement> movements, Movement movement)
        {
            Predicate<Movement> hasSame = m => m.ObjectId == movement.ObjectId &&
                (m.Start >= movement.Start && movement.Start < m.End ||
                m.Start > movement.End && movement.End <= m.End);
                
            return Contract.Exists(movements, hasSame);
        }
    }
}
