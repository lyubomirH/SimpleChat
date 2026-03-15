using Microsoft.AspNetCore.Mvc;
using SimpleChat.Models;

namespace SimpleChat.Controllers
{
    public class ChatController : Controller
    {
        private static List<KeyValuePair<string, string>> messages = new();
        public IActionResult Show()
        {
            if (messages.Count() < 1)
            {
                return View(new ChatViewModel());
            }
            var chatModel = new ChatViewModel()
            {
                Messages = messages
                .Select(m => new MessageViewModel()
                {
                    Sender = m.Key,
                    MessageText = m.Value
                }).ToList()
            };
            return View(chatModel);
        }
        [HttpPost]
        public IActionResult Send(ChatViewModel chat)
        {
            var newMessage = chat.CurrentMessage;
            if(newMessage != null && newMessage.Sender != null && newMessage.MessageText != null)
            {
                messages.Add(new KeyValuePair<string, string>
                    (newMessage.Sender, newMessage.MessageText));
            }
            return RedirectToAction("Show");
        }
    }
}
