namespace Gamifyit.Game.Model
{
    public class EmailAddress
    {
        public EmailAddress(string fullAddress)
        {
            this.FullAddress = fullAddress;
        }

        public string FullAddress { get; }
    }
}