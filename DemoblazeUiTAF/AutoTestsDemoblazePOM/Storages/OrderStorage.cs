using DemoblazeUiTAF.AutoTestsDemoblazePOM.Builders;
using DemoblazeUiTAF.AutoTestsDemoblazePOM.Entities;

namespace DemoblazeUiTAF.AutoTestsDemoblazePOM.Storages
{
    internal class OrderStorage
    {
        public static OrderEntity ValidOrder = new OrderBuilder()
            .WithName("Anna")
            .WithCountry("USA")
            .WithCity("New York")
            .WithCreditCard("123456789")
            .WithMonth("12")
            .WithYear("2029")
            .Build();
        
        public static OrderEntity OrderWithEmptyNameField = new OrderBuilder()
            .WithName("")
            .WithCountry("USA")
            .WithCity("New York")
            .WithCreditCard("123456789")
            .WithMonth("12")
            .WithYear("2029")
            .Build();
    }
}
