namespace MatchingGame_WORDS
{
    public class WordElement
    {
        public WordElement(string id, string value)
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
