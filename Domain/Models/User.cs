using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ValidatePasswordAPI.Domain.Models
{
    public class User
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }

        public ICollection<string> ValidatePassword(INotificationUtil _notificationUtil)
        {
            int MIN_LENGTH_PASSWORD = 9;
            string SPECIAL_CARACTERS_PASS = @"!@#$%^&*()-+";

            if (PassWord.Length < MIN_LENGTH_PASSWORD)
                _notificationUtil.AddNotification($"A senha deve conter {MIN_LENGTH_PASSWORD} ou mais caracteres!");

            if (!PassWord.ToCharArray().Any(x => char.IsDigit(x)))
                _notificationUtil.AddNotification("A senha deve conter ao menos um dígito!");

            if (!PassWord.ToCharArray().Any(x => char.IsLower(x)))
                _notificationUtil.AddNotification("A senha deve conter ao menos uma letra minúscula!");

            if (!PassWord.ToCharArray().Any(x => char.IsUpper(x)))
                _notificationUtil.AddNotification("A senha deve conter ao menos uma letra maiúscula!");

            var regex = new Regex("[" + SPECIAL_CARACTERS_PASS + "]");
            if (!regex.Matches(PassWord).Any(x => x.Success))
                _notificationUtil.AddNotification($"A senha deve conter ao menos um caracter especial. Ex.: {SPECIAL_CARACTERS_PASS}");

            if (PassWord.ToCharArray().Any(x => PassWord.ToCharArray().Where(y => y == x).Count() > 1))
                _notificationUtil.AddNotification($"A senha não deve conter caracteres repetidos!");

            return _notificationUtil.GetMessages();
        }

    }
}
