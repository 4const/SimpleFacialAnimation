using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace SimpleFacialAnimation
{
    abstract class TimelineUtils
    {
        public static bool HasIntersection(IEnumerable<Movement> movements, Movement movement)
        {
            Predicate<Movement> hasSame = m => m.ObjectId == movement.ObjectId &&
                (m.Start >= movement.Start && movement.Start < m.End ||
                m.Start > movement.End && movement.End <= m.End);

            return Contract.Exists(movements, hasSame);
        }
    }
}
