using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TemplarsBows.Items
{
    class Yumi : ModItem
    {
        /// <summary>
		/// This bow is made to be an equivilent to Muramasa. It's name comes from the asymmetrical model of bows used during the same era.
		/// </summary>
        /// 

        public override void SetDefaults() {
            Item.damage = 19;
            Item.DamageType = DamageClass.Ranged;
            Item.useAmmo = AmmoID.Arrow;
            Item.shootSpeed = 7f;
            Item.noMelee = true;
            Item.width = 40;
            Item.height = 40;
            Item.scale = .85f;
            Item.useTime = 22;
            Item.useAnimation = 22;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 1;
            Item.crit = 5;
            Item.value = Item.buyPrice(gold: 1, silver: 75);
            Item.rare = ItemRarityID.Green;
            Item.UseSound = SoundID.Item5;
            Item.autoReuse = true;
            Item.shoot = ProjectileID.WoodenArrowFriendly;
            Item.material = true;
        }

        public override Vector2? HoldoutOffset()
        {
            // TODO : Change for non-placeholder art
            return new Vector2(-3.5f, 0);
        }
    }
}
