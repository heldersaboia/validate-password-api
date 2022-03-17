using System.Collections.Generic;

namespace ValidatePasswordAPI.Domain
{
    public interface INotificationUtil
    {
        void AddNotification(string message);
        ICollection<string> GetMessages();
    }
}
