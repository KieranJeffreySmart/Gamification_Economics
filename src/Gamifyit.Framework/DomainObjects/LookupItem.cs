namespace Gamifyit.Framework.DomainObjects
{
    using System;
    public class LookupItem : ICloneable
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

    public class LookupItem<TKey> : IEquatable<TKey>, ICloneable where TKey : struct
    {
        public TKey Key { get; set; }

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

        public bool Equals(LookupItem<TKey> other)
        {
            return this.Equals(other.Key);
        }

        public bool Equals(TKey key)
        {
            return this.Key.Equals(key);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is LookupItem<TKey> && Equals((LookupItem<TKey>)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (this.Key.GetHashCode() * 397) ^ (this.Value != null ? this.Value.GetHashCode() : 0);
            }
        }
    }
}