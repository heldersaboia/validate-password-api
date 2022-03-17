using System.Collections.Generic;
using System.Linq;

namespace ValidatePasswordAPI.Domain.Utils
{
    public class NotificationUtil : INotificationUtil
    {
        private IList<string> _messages { get; } = new List<string>();
        public void AddNotification(string message) => _messages.Add(message);
        public ICollection<string> GetMessages() => _messages.ToList();
    }
}