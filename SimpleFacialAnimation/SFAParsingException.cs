using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFacialAnimation
{
    class SFAParsingException : Exception
    {
        public SFAParsingException(string text) : base(text) { }

        public SFAParsingException(string text, Exception cause) : base(text, cause) { }
    }
}
