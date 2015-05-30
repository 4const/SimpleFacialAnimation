namespace SimpleFacialAnimation
{
    class ExpressionUsage
    {
        public ExpressionUsage(string espressionId, int start)
        {
            EspressionId = espressionId;
            Start = start;
        }

        public string EspressionId { get; private set; }
        public int Start { get; private set; }
    }
}
