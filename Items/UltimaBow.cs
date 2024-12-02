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
    internal class UltimaBow : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 26;
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
            Item.crit = 4;
            Item.value = 10000;
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item5;
            Item.autoReuse = false;
            Item.shoot = ProjectileID.WoodenArrowFriendly;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();

            recipe.AddIngredient(ItemID.CopperBow);
            recipe.AddIngredient<EBow>();
            recipe.AddIngredient(ItemID.BeesKnees);
            recipe.AddIngredient(ItemID.DaedalusStormbow);
            recipe.AddIngredient<Orion>();
            recipe.AddIngredient<JackOBow>();
            recipe.AddIngredient(ItemID.Tsunami);
            recipe.AddIngredient(ItemID.DD2BetsyBow); // Aerial Bane
            recipe.AddIngredient(ItemID.Phantasm);
            recipe.AddIngredient(ItemID.FairyQueenRangedItem); // Eventide

            recipe.AddTile(TileID.MythrilAnvil);

            recipe.Register();
        }

        // Used to ensure bow looks natural to hold
        public override Vector2? HoldoutOffset()
        {
            // TODO : Change for non-placeholder art
            return new Vector2(-3.5f, 0);
        }
    }
}
