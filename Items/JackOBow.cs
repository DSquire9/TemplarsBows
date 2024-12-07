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
    internal class JackOBow : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 116;
            Item.DamageType = DamageClass.Ranged;
            Item.useAmmo = AmmoID.Arrow;
            Item.shootSpeed = 14f;
            Item.noMelee = true;
            Item.width = 40;
            Item.height = 40;
            Item.scale = .85f;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 2.5f;
            Item.crit = 4;
            Item.value = Item.buyPrice(gold: 10);
            Item.rare = ItemRarityID.Yellow;
            Item.UseSound = SoundID.Item5;
            Item.autoReuse = true;
            Item.shoot = ProjectileID.WoodenArrowFriendly;
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            if (type == ProjectileID.WoodenArrowFriendly)
            {
                type = ProjectileID.JackOLantern;
            }
        }

        // Used to ensure bow looks natural to hold
        public override Vector2? HoldoutOffset()
        {
            // TODO : Change for non-placeholder art
            return new Vector2(-3.5f, 0);
        }
    }
}
