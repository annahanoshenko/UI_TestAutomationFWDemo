namespace DemoblazeUiTAF.AutoTestsDemoblazePOM.Entities
{
    public class UserEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public UserEntity(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }
}
