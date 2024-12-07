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
    class Daybreak : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 31;
            Item.DamageType = DamageClass.Ranged;
            Item.useAmmo = AmmoID.Arrow;
            Item.shootSpeed = 7f;
            Item.noMelee = true;
            Item.width = 40;
            Item.height = 40;
            Item.scale = .85f;
            Item.useTime = 31;
            Item.useAnimation = 31;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.knockBack = 1.5f;
            Item.crit = 4;
            Item.value = Item.buyPrice(gold: 4);
            Item.rare = ItemRarityID.Orange;
            Item.UseSound = SoundID.Item5;
            Item.autoReuse = true;
            Item.shoot = ProjectileID.WoodenArrowFriendly;
        }

        public override void AddRecipes()
        {
            Recipe recipeCrim = CreateRecipe();
            Recipe recipeShad = CreateRecipe();

            recipeCrim.AddIngredient<Thorns>();
            recipeShad.AddIngredient<Thorns>();

            recipeCrim.AddIngredient<Yumi>();
            recipeShad.AddIngredient<Yumi>();

            recipeCrim.AddIngredient(ItemID.MoltenFury);
            recipeShad.AddIngredient(ItemID.MoltenFury);

            recipeCrim.AddIngredient(ItemID.TendonBow);
            recipeShad.AddIngredient(ItemID.DemonBow);

            recipeCrim.AddTile(TileID.DemonAltar);
            recipeShad.AddTile(TileID.DemonAltar);
        }

        // Used to ensure bow looks natural to hold
        public override Vector2? HoldoutOffset()
        {
            // TODO : Change for non-placeholder art
            return new Vector2(-3.5f, 0);
        }
    }
}
