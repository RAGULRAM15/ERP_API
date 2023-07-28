using System.ComponentModel.DataAnnotations;

namespace IMS_API.Model
{
    public class Login
    {

        
       
       
        [Required]
        public string USER_NAME { get; set; }

        [Required]
        public string PASSWORD { get; set; }
    }
}
