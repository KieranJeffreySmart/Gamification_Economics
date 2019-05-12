namespace Gamifyit.Finance.Events
{
    using Gamifyit.Finance.ModelState;
    using Gamifyit.Framework.Events;

    public class NewCurrencyEvent : Event
    {
        private readonly Currency currency;

        public NewCurrencyEvent(Currency currency)
        {
            this.currency = currency;
        }

        public Currency Currency => this.currency;
    }
}