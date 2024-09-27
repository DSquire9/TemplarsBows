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
