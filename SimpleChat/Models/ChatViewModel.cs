namespace SimpleChat.Models
{
    public class ChatViewModel
    {
        public MessageViewModel CurrentMessage { get; set; } = new();
        public List<MessageViewModel> Messages { get; set; } = new();
    }
}
