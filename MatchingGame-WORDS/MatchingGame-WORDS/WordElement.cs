namespace MatchingGame_WORDS
{
    internal class WordElement
    {
        internal WordElement(string id, string value)
        {
            HiddenValue = "X";
            Id = id;
            Value = value;
        }
        public string HiddenValue { get; set; }
        public string Id { get; set; }
        public string Value { get; set; }
    }
}
