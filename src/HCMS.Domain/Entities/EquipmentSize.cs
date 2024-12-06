using Ardalis.SmartEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Domain.Entities
{
    public class EquipmentSize : SmartEnum<EquipmentSize>
    {
        public static readonly EquipmentSize ExtraSmall = new EquipmentSize(nameof(ExtraSmall), 1);
        public static readonly EquipmentSize Small = new EquipmentSize(nameof(Small), 2);

        public static readonly EquipmentSize Medium = new EquipmentSize(nameof(Medium), 3);
        public static readonly EquipmentSize Large = new EquipmentSize(nameof(Large), 4);
        public static readonly EquipmentSize ExtraLarge = new EquipmentSize(nameof(ExtraLarge), 5);
        public static readonly EquipmentSize XXL = new EquipmentSize(nameof(XXL), 6);


        public EquipmentSize(string name, int value) : base(name, value)
        {
        }
    }
}
