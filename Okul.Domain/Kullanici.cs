using System;

namespace Okul.Domain
{
    public class Kullanici : BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public DateTime LoginDate { get; set; }

    }
}
