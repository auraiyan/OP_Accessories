using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace OP_Accessories.Sprites

{
    public class rageEmblem : ModItem
    {
        public float dmgIncreament = 2;
        public bool active = false;
        public bool ifActive;
        public float multiplier;
        public int stack;
        public float value;

        public static bool equipped = false;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rage Emblem");
            Tooltip.SetDefault("Grants 30% lifesteal \n" +
                "Increases weapons dmg by 2.5% \n" +
                "stacks armor penetraton by 2.5% and magic resist by 4.5%\n" +
                "Stacks upto 6 times grants a stack each second while attcking");
        }
        public override void SetDefaults()
        {
            item.Size = new Vector2(34);
            item.value = 10006624;
            item.rare = 9;
            item.accessory = true;

        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            equipped = true;
            dmgIncreament = lifesteal.x;
            player.meleeDamage += (player.meleeDamage * dmgIncreament)/100;
            player.rangedDamage += (player.rangedDamage * dmgIncreament)/100;
            player.magicDamage += (player.magicDamage * dmgIncreament + lifesteal.z)/100;
            player.thrownDamage += (player.thrownDamage * dmgIncreament)/100;
            player.bulletDamage += (player.bulletDamage * dmgIncreament)/100;
            player.arrowDamage += (player.arrowDamage * dmgIncreament)/100;
            player.rocketDamage += (player.rocketDamage * dmgIncreament)/100;
            player.armorPenetration += lifesteal.y;



        }

    }

    public class lifesteal : ModPlayer
    { 
               
        public bool use;
        public int i = 0;
        public int i2 = 0;
        public int i3 = 0;
        public static int x = 3;
        public static int y = 5;
        public static int z = 5;
        public bool controller;
        public bool hurt = false;


        public virtual void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            if (rageEmblem.equipped)
            {
                player.lifeSteal = 25;
                int lifeSteal = damage / 3;
                player.statLife += lifeSteal;
                player.HealEffect(lifeSteal);
                use = true;
                controller = true;
                i2 = 0;
            }
        }

        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
            if (rageEmblem.equipped)
            {

                player.lifeSteal = 25;
                int lifeSteal = damage / 3;
                player.statLife += lifeSteal;
                player.HealEffect(lifeSteal);
                use = true;
                controller = true;
                i2 = 0;
            }
        }


        public override void PostUpdate()
        {
            if (rageEmblem.equipped)
            {
                if (use)
                {
                    i++;
                    {
                        if (i >= 0 && i < 60)
                        {
                            x = 5;//dmg multiplier 2.5% * 2
                            y = 5;//defense reduction 3.5% * 2
                            z = 9;//magic resist reduction/magic dmg multiplier 4.5% * 2

                            player.AddBuff(mod.BuffType("Stack"), 120, false);
                        }
                        else if (i >= 60 && i < 120)
                        {
                            x = 7;
                            y = 7;
                            z = 14;

                            player.AddBuff(mod.BuffType("Stack"), 180, false);
                        }
                        else if (i >= 120 && i < 180)
                        {
                            x = 13;
                            y = 10;
                            z = 18;

                            player.AddBuff(mod.BuffType("Stack"), 240, false);
                        }
                        else if (i >= 180 && i < 240)
                        {
                            x = 15;
                            y = 12;
                            z = 23;

                            player.AddBuff(mod.BuffType("Stack"), 300, false);
                        }
                        else if (i >= 240)
                        {
                            x = 17;
                            y = 15;
                            z = 27;

                            player.AddBuff(mod.BuffType("Stack"), 360, false);
                        }
                        else if (i > 5000000) { i = 300; }

                    }
                    if (controller)
                    {
                        i2++;
                        {
                            if (i2 >= 20)
                            {
                                controller = false;
                                i3 = 0;
                                i2 = 0;
                            }
                        }
                    }
                    else
                    {
                        i3++;
                        if (i3 >= 120)
                        {
                            i3 = 60;
                            i = 0;
                            use = false;
                            player.ClearBuff(mod.BuffType("Stack"));

                        }
                    }

                }
                else
                {
                    i = 0;
                    x = 3;
                    y = 4;
                    z = 5;
                }
            }
        }
        public override void ResetEffects()
        {
            ResetVariables();
        }

        public override void UpdateDead()
        {
            ResetVariables();
        }

        private void ResetVariables()
        {
            rageEmblem.equipped = false;
        }
    }
    


    public class Stack : ModBuff
    {
        
           
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Stacking fury");
            Description.SetDefault("Each stack grants your weapon 2.5% dmg, 3.5% defense shread, 4.5% magic resist shread");
            Main.buffNoSave[Type] = true;
            Main.debuff[Type] = false;
            canBeCleared = false;
        }
    }
    


}

