using DemoblazeUiTAF.AutoTestsDemoblazePOM.Entities;

namespace DemoblazeUiTAF.AutoTestsDemoblazePOM.Storages
{
    public static class UserStorage
    {
        public static UserEntity ValidTestUser => new UserEntity("Anna14", "qwerty67");
        public static UserEntity UserWithDynamicName => new UserEntity("Anna" + DateTime.Now.Ticks, "qwerty67");
        public static UserEntity UserWithEmptyFields => new UserEntity("", "");
    }
}
