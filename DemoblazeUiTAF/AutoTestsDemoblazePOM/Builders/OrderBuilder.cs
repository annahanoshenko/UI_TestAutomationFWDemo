using DemoblazeUiTAF.AutoTestsDemoblazePOM.Entities;

namespace DemoblazeUiTAF.AutoTestsDemoblazePOM.Builders
{
    internal class OrderBuilder
    {
        private string _name = "DefaultName";
        private string _country = "DefaultCountry";
        private string _city = "DefaultCity";
        private string _creditCard = "0123456789";
        private string _month = "12";
        private string _year = "2029";

        public OrderBuilder WithName(string name)
        {
            _name = name;
            return this;
        }
        public OrderBuilder WithCountry(string country)
        {
            _country = country;
            return this;
        }
        public OrderBuilder WithCity(string city)
        {
            _city = city;
            return this;
        }
        public OrderBuilder WithCreditCard(string creditCard)
        {
            _creditCard = creditCard;
            return this;
        }
        public OrderBuilder WithMonth(string month)
        {
            _month = month;
            return this;
        }
        public OrderBuilder WithYear(string year)
        {
            _year = year;
            return this;
        }
        public OrderEntity Build()
        {
            return new OrderEntity(_name, _country, _city, _creditCard, _month, _year);
        }

    }
}
