namespace Gamifyit.Framework.DomainObjects
{
    using System;
    public struct LookupItem : ICloneable
    {
        public int Key { get; set; }

        public string Value { get; set; }

        public object Clone()
        {
            return this.CloneAsSelf();
        }

        public LookupItem CloneAsSelf()
        {
            var clone = (LookupItem)this.MemberwiseClone();
            return clone;
        }
    }
}