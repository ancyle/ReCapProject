namespace Core.Entities.Concrete
{
    /// <summary>
    ///Can be used from Entities layer...If this is main usage then Discard all using for Entities User.
    /// </summary>
    public class User:IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}