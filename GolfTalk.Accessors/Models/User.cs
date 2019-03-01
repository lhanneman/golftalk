using System;

namespace GolfTalk.Accessors.Models
{
    internal class User
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public bool EmailConfirmed { get; set; }

        public DateTime? DeletedAtUtc { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime CreatedAtUtc { get; set; }

        public string Username { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime PasswordChangedAtUtc { get; set; }
    }
}
