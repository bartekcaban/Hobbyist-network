using System;
using System.Collections.Generic;
using System.Text;

namespace Hobbyist_Network.Domain.Entities
{
    public class Event : Entity
    {
        private readonly List<Activity> _activities = new List<Activity>();
        public Repair(Guid id, string description, Guid managerId, Guid vehicleId) : base(id)
        {
            Description = description;
            ManagerId = managerId;
            VehicleId = vehicleId;
            Open();
        }

        private readonly Dictionary<RepairStatus, string> statusDictionary = new Dictionary<RepairStatus, string>()
        {
            {RepairStatus.Open, "OPN" },
            {RepairStatus.Priced, "PRI" },
            {RepairStatus.InProgress, "PRO" },
            {RepairStatus.Canceled, "CAN" },
            {RepairStatus.Finished, "FIN" }
        };


        private Repair()
        {

        }
        protected override Dictionary<RepairStatus, string> StatusDictionary => statusDictionary;
        public IEnumerable<Activity> Activities => _activities.AsReadOnly();
        public Guid ManagerId { get; private set; }
        public Employee Manager { get; private set; }
        public Vehicle Vehicle { get; private set; }
        public Guid VehicleId { get; private set; }
        public Pricing Pricing { get; private set; }
        public Guid PricingId { get; private set; }
    }
}
