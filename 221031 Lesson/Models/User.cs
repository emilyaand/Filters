
using Microsoft.AspNetCore.Identity;

namespace _221031_Lesson.Models
{
    public class User: IdentityUser
    {
        public string Fullname { get; set; }
    }
}
