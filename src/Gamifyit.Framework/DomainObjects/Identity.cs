namespace Gamifyit.Framework.DomainObjects
{
    public class StateIdentity
    {
        public StateIdentity()
        {
        }

        public StateIdentity(long identityIndex, string identityReference)
        {
            this.Index = identityIndex;
            this.Reference = identityReference;
        }

        public long Index { get; set; }
        public string Reference { get; set; }
        
        public StateIdentity CloneAsSelf()
        {
            var clone = (StateIdentity)this.MemberwiseClone();
            return clone;
        }
    }
}
