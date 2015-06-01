namespace SimpleFacialAnimation
{
    class Movement
    {
        public Movement(string objectId, int start, int end, string value)
        {
            ObjectId = objectId;
            Start = start;
            End = end;
            Value = value;
        }

        public string ObjectId { get; private set; }
        public int Start { get; private set; }
        public int End { get; private set; }
        public string Value { get; private set; }
    }
}
