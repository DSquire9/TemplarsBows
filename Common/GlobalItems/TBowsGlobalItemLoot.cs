using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplarsBows.Items;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace TemplarsBows.Common.GlobalItems
{
    public class TBowsGlobalItemLoot : GlobalItem
    {
        public override bool InstancePerEntity => false;

        public override void ModifyItemLoot(Item item, ItemLoot loot)
        {
            switch (item.type)
            {
                case ItemID.LockBox:
                    loot.Add(new CommonDrop(ModContent.ItemType<Yumi>(), 14));
                    break;
                default:
                    break;
            }
        }
    }
}
