namespace SimpleFacialAnimation
{
    class Movement
    {
        public Movement(string objectId, int start, int end, float value)
        {
            ObjectId = objectId;
            Start = start;
            End = end;
            Value = value;
        }

        public string ObjectId { get; private set; }
        public int Start { get; private set; }
        public int End { get; private set; }
        public float Value { get; private set; }
    }
}
