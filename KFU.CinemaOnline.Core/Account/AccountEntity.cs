namespace KFU.CinemaOnline.Core.Account
{
    public class AccountEntity : BaseEntity
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Role[] Roles { get; set; }
    }
}
