using System;
using System.Text.Json.Serialization;

namespace JobPortalService.Models
{
    public class UserModel
    {
        public int Id { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }

        [JsonIgnore]
        public string Password { get; set; }

    }
}
