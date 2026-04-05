using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TemplarsBows.Items
{
	public class EBow : ModItem
	{
		public override void SetDefaults(){
			Item.damage = 8;
			Item.DamageType = DamageClass.Ranged;
			Item.useAmmo = AmmoID.Arrow;
			Item.shootSpeed = 4f;
			Item.noMelee = true;
			Item.width = 40;
			Item.height = 40;
			Item.scale = .85f;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 1;
			Item.crit = 5;
			Item.value = 10000;
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item5;
			Item.autoReuse = true;
			Item.shoot = ProjectileID.WoodenArrowFriendly;
		}

		public override void AddRecipes(){
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.ManaCrystal, 8);
			recipe.AddIngredient(ItemID.IronBow, 1);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

            Recipe recipeAlt = CreateRecipe();
            recipeAlt.AddIngredient(ItemID.ManaCrystal, 8);
            recipeAlt.AddIngredient(ItemID.LeadBow, 1);
            recipeAlt.AddTile(TileID.Anvils);
            recipeAlt.Register();
        }

        // Used to turn wooden arrows int jesters arrows
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback) {
			if (type == ProjectileID.WoodenArrowFriendly){
				type = ProjectileID.JestersArrow;
			}
		}

        // Used to ensure bow looks natural to hold
        public override Vector2? HoldoutOffset(){
			return new Vector2(0.5f, 0.5f);
		}
	}
}
