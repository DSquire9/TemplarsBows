using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using TemplarsBows.Items;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TemplarsBows.Projectiles
{
    class TransmuteProjectile : GlobalProjectile
    {
        Random rng = new Random();
        private int[] effects = 
            {
                20, //"Poisoned",
                24, //"On Fire!",
                39, //"Cursed Inferno"
                324, //"Frostbite"
                69, //"Ichor"
                70, //"Acid Venom"
            };
        public override bool InstancePerEntity
        {
            get
            {
                return true;
            }
        }

        public override void OnHitNPC(Projectile projectile, NPC target, NPC.HitInfo hit, int damageDone)
        {
            Player player = Main.player[projectile.owner];

            // Gives projectiles fired by the Rain of Thorns a 25% chance to poison
            if (player.inventory[player.selectedItem].type == ModContent.ItemType<Thorns>() && rng.Next(4) == 3)
            {
                target.AddBuff(BuffID.Poisoned, 240);
            }
            #region YumiProjectiles
            if (player.inventory[player.selectedItem].type == ModContent.ItemType<Yumi>())
            {
                
                if (Main.myPlayer == projectile.owner && projectile.type != ProjectileID.Muramasa)
                {
                    SpawnMuramasaBurst(projectile);
                }
                
            }
            #endregion
            #region DaybreakProjectiles
            if (player.inventory[player.selectedItem].type == ModContent.ItemType<Daybreak>())
            {
                // Status
                if(rng.Next(2) == 1)
                {
                    target.AddBuff(effects[rng.Next(6)], 600);
                }
                // Explode
                if (rng.Next(2) == 1)
                {
                    if (Main.myPlayer == projectile.owner && projectile.type != ProjectileID.Muramasa)
                    {
                        SpawnMuramasaBurst(projectile);
                    }
                }
            }
            #endregion
            #region TrueDaybreakProjectiles
            if (player.inventory[player.selectedItem].type == ModContent.ItemType<Daybreak>() || player.inventory[player.selectedItem].type == ModContent.ItemType<Orion>())
            {
                // Status
                target.AddBuff(effects[rng.Next(6)], 600);

                // Explode
                if (Main.myPlayer == projectile.owner && projectile.type != ProjectileID.Muramasa)
                {
                    SpawnMuramasaBurst(projectile);
                }
            }
            #endregion
            if (player.inventory[player.selectedItem].type == ModContent.ItemType<UltimaBow>())
            {
                // Status
                target.AddBuff(effects[rng.Next(6)], 600);
            }
        }

        public override void AI(Projectile projectile)
        {
            base.AI(projectile);
            // Ensure the player fired the projectile and that the server does not own it in multiplayer
            if(projectile.owner == Main.myPlayer && projectile.owner != 255 && IsPlayerFiredProjectile(projectile, Main.LocalPlayer))
            {
                Player player = Main.player[projectile.owner];
                #region Homing
                if (
                    (player.inventory[player.selectedItem].type == ModContent.ItemType<FailNot>() ||
                    player.inventory[player.selectedItem].type == ModContent.ItemType<TrueFailNot>() ||
                    player.inventory[player.selectedItem].type == ModContent.ItemType<Orion>()) &&
                    projectile.aiStyle == 1 // Ensures the projectile is an arrow
                    && player.active 
                   )
                {
                    projectile.maxPenetrate = 3; // 3 max hits

                    //Redo this homing code to target the closest enemy to the projectile instead of first in the list
                    for (int i = 0; i < Main.npc.Length; i++)
                    {
                        NPC target = Main.npc[i];
                        //Get the shoot trajectory from the projectile and target
                        float shootToX = target.position.X + (float)target.width * 0.5f - projectile.Center.X;
                        float shootToY = target.position.Y - projectile.Center.Y;
                        float distance = (float)Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));

                        //If the npc is hostile
                        if (!target.friendly && !target.CountsAsACritter && distance < 300f && target.active)
                        {
                            //Divide the factor, 3f, which is the desired velocity
                            distance = 3f / distance;

                            //Multiply the distance by a multiplier to increase projectile speed
                            shootToX *= distance * 3;
                            shootToY *= distance * 3;

                            //Set the velocities to the shoot values
                            projectile.velocity.X = shootToX;
                            projectile.velocity.Y = shootToY;
                            
                        }
                    }
                }
                #endregion
            }

        }

        private bool IsPlayerFiredProjectile(Projectile projectile, Player player)
        {
            // Check the player's held item and its associated projectile type
            Item heldItem = player.HeldItem;
            if (heldItem != null && heldItem.shoot == projectile.type)
            {
                return true; // The projectile matches the weapon's shot type
            }

            // Check if the projectile matches the ammo type
            if (heldItem.useAmmo > 0)
            {
                for (int i = 0; i < player.inventory.Length; i++)
                {
                    Item ammo = player.inventory[i];
                    if (ammo.ammo == heldItem.useAmmo && ammo.shoot == projectile.type)
                    {
                        return true; // The projectile matches the ammo's shot type
                    }
                }
            }

            return false; // Not a player-fired projectile
        }

        private void SpawnMuramasaBurst(Projectile projectile)
        {
            Vector2 vel1 = Vector2.Normalize(new Vector2(rng.Next(360), rng.Next(360)));
            Vector2 vel2 = new Vector2(vel1.Y * -1, vel1.X);
            Vector2 vel3 = new Vector2(vel2.Y * -1, vel2.X);
            Vector2 vel4 = new Vector2(vel3.Y * -1, vel3.X);

            int proj1 = Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center, vel1 * 2, ProjectileID.Muramasa, 6, 0, projectile.owner);
            int proj2 = Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center, vel2 * 2, ProjectileID.Muramasa, 6, 0, projectile.owner);
            int proj3 = Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center, vel3 * 2, ProjectileID.Muramasa, 6, 0, projectile.owner);
            int proj4 = Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center, vel4 * 2, ProjectileID.Muramasa, 6, 0, projectile.owner);

            Main.projectile[proj1].aiStyle = ProjectileID.Muramasa;
            Main.projectile[proj2].aiStyle = ProjectileID.Muramasa;
            Main.projectile[proj3].aiStyle = ProjectileID.Muramasa;
            Main.projectile[proj4].aiStyle = ProjectileID.Muramasa;

            Main.projectile[proj1].timeLeft = 45;
            Main.projectile[proj2].timeLeft = 45;
            Main.projectile[proj3].timeLeft = 45;
            Main.projectile[proj4].timeLeft = 45;

            Main.projectile[proj1].stopsDealingDamageAfterPenetrateHits = true;
            Main.projectile[proj2].stopsDealingDamageAfterPenetrateHits = true;
            Main.projectile[proj3].stopsDealingDamageAfterPenetrateHits = true;
            Main.projectile[proj4].stopsDealingDamageAfterPenetrateHits = true;

            Main.projectile[proj1].penetrate = -1;
            Main.projectile[proj2].penetrate = -1;
            Main.projectile[proj3].penetrate = -1;
            Main.projectile[proj4].penetrate = -1;

            Main.projectile[proj1].rotation = (float)Math.Atan2(vel1.X, vel1.Y);
            Main.projectile[proj2].rotation = (float)Math.Atan2(vel2.X, vel2.Y);
            Main.projectile[proj3].rotation = (float)Math.Atan2(vel3.X, vel3.Y);
            Main.projectile[proj4].rotation = (float)Math.Atan2(vel4.X, vel4.Y);
        }
    }
}
