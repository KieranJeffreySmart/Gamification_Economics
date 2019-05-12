namespace Gamifyit.Framework.DomainObjects
{
    using System;
    using System.Net.NetworkInformation;
    using System.Threading.Tasks;
    using System.Transactions;

    using Gamifyit.Framework.Patterns;

    public abstract class EntityState : ICloneable
    {
        public StateIdentity Identity { get; set; } = new StateIdentity(0, null);

        public abstract object Clone();
    }
}
