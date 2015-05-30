using System;

namespace SimpleFacialAnimation
{
    class SfaException : Exception
    {
        public SfaException(string text) : base(text) { }

        public SfaException(string text, Exception cause) : base(text, cause) { }
    }
}
