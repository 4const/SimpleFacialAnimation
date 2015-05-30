using System;

namespace SimpleFacialAnimation
{
    class SfaParsingException : Exception
    {
        public SfaParsingException(string text) : base(text) { }

        public SfaParsingException(string text, Exception cause) : base(text, cause) { }
    }
}
