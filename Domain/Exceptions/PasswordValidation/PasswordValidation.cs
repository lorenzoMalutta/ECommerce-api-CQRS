using System.Text.RegularExpressions;

namespace agrolugue_api.Domain.Exceptions.PasswordValidation
{
    public class PasswordValidation
    {
        public Boolean IsValid(string password)
        {
            var validadition = new Regex(@"^(?=.*[a-zA-Z0-9])");
            
            if(!validadition.IsMatch(password))
                return false;
            else 
                return true;    
        }
    }
}
