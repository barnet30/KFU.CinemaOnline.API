using System;

namespace KFU.CinemaOnline.API.Contracts.Account
{
    public class Account
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public DateTime CreatedAt { get; set; }
        public Role[] Roles { get; set; }
    }
}