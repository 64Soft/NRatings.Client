namespace NRatings.Client.Validation
{
    public class Message
    {
        public string Text { get; set; }
        public MessageType Type { get; set; }

        public enum MessageType
        {
            Info = 1,
            Warning = 2,
            Error = 3
        };

        public Message()
        { }

        public Message(MessageType type, string text)
        {
            this.Text = text;
            this.Type = type;
        }

        public override string ToString()
        {
            return this.ToString(false);
        }

        public string ToString(bool withType)
        {
            if (withType == true)
                return Type.ToString() + " - " + Text;
            else
                return Text;
        }
    }
}
