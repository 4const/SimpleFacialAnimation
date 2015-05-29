using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SimpleFacialAnimation
{
    class TimelineParser
    {
        public static Timeline parse(string text)
        {            
            var root = XElement.Parse(text);

            var expressionNodes = root.Elements("expr");
            var mainNode = root.Element("main");

            if (mainNode == null)
            {
                throw new SFAParsingException("Не найден тег <main>");
            }

            var expressions = parseExpressions(expressionNodes);
            var timeline = new Timeline(expressions);

            return timeline;
        }

        private static Dictionary<string, Expression> parseExpressions(IEnumerable<XElement> expressionNodes)
        {
            var map = new Dictionary<string, Expression>();
            
            foreach (var node in expressionNodes)
            {
                var expression = parseExpression(node);
                if (map.ContainsKey(expression.Id))
                {
                    throw new SFAParsingException("Несколько тегов expr с id = " + expression.Id);
                }

                map.Add(expression.Id, expression);
            }

            return map;
        }

        private static Expression parseExpression(XElement expressionNode)
        {
            var id = expressionNode.Attribute("id").Value;

            var movements = parseMovements(expressionNode.Elements("mov"));

            return null;
        }

        private static List<Movement> parseMovements(IEnumerable<XElement> movementNodes)
        {
            var list = new List<Movement>();
            
            foreach (var node in movementNodes)
            {
                var movement = parseMovement(node);
            }

            return list;
        }

        private static Movement parseMovement(XElement movementNode)
        {
            var id = movementNode.Attribute("id").Value;
            var start = int.Parse(movementNode.Attribute("start").Value);
            var end = int.Parse(movementNode.Attribute("end").Value);
            var value = float.Parse(movementNode.Attribute("value").Value);

            return new Movement(id, start, end, value);
        }
    }
}
