using GHouseMobile.Core.Abstraction;
using System;

namespace GHouseMobile.Core.Models.User
{
    public class UserInfo : BaseObservable
    {
        public string? Id { get; set; }

        public string? Token { get; set; }

        public string? AvatarUrl { get; set; }

        public Field Email { get; set; } = new Field();

        public Field MobileNumber { get; set; } = new Field();

        public string? Gender { get; set; }

        public DateTime? DateofBirth { get; set; }

        public string? Password { get; set; }
    }
}
