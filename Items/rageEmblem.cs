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
        public int dmgIncreament = 2;
        public bool active = false;
        public bool ifActive;
        public float multiplier;
        public int stack;
        public float value;
        public static bool equipped;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rage Emblem");
            Tooltip.SetDefault("First hit does 300% damage\n" +
                "Increases weapons speed and dmg by 5% \n" +
                "stacks armor penetraton by 6% and magic resist by 9%\n" +
                "Stacks upto 6 times");
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
            dmgIncreament = Rage.x;
            player.meleeDamage += (player.meleeDamage * dmgIncreament)/100;
            player.meleeSpeed += (player.meleeDamage * dmgIncreament)/100;
            player.itemTime -= (player.itemTime * Rage.y)/100;
            player.rangedDamage += (player.rangedDamage * dmgIncreament)/100;
            player.magicDamage += (player.magicDamage *  (dmgIncreament + Rage.z))/100;
            player.thrownDamage += (player.thrownDamage * dmgIncreament)/100;
            player.bulletDamage += (player.bulletDamage * dmgIncreament)/100;
            player.arrowDamage += (player.arrowDamage * dmgIncreament)/100;
            player.rocketDamage += (player.rocketDamage * dmgIncreament)/100;



        }

    }

    public class Rage : ModPlayer
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
        public NPC target1;


        public virtual void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            if (rageEmblem.equipped) {
                use = true;
                controller = true;
                i2 = 0;
                if (target1 == null || target1 == target)
                {
                    target1 = target;
                    target.defense -= target.defDefense * y;
                }
                Stack();
            }
            
        }

        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
            
            if (rageEmblem.equipped)
            {
                Stack();
                use = true;
                controller = true;
                i2 = 0;
                if (target1 == null || target1 == target)
                {
                    target1 = target;
                    target.defense -= target.defDefense * y;
                }
            }
            
            
        }
        public void Stack()
        {
            if (use)
            {
                i++;
                if (i >= 1 && i < 3)
                {
                    x = 300;
                    y = 20;
                    z = 50;

                    player.AddBuff(mod.BuffType("Stack"), 120, false);
                    return;
                }
                else if (i >= 3 && i < 6)
                {
                    x = 10;
                    y = 12;
                    z = 18;

                    player.AddBuff(mod.BuffType("Stack"), 180, false);
                    return;
                }
                else if (i >= 6 && i < 9)
                {
                    x = 15;
                    y = 18;
                    z = 27;

                    player.AddBuff(mod.BuffType("Stack"), 240, false);
                    return;
                }
                else if (i >= 9 && i < 12)
                {
                    x = 20;
                    y = 24;
                    z = 36;

                    player.AddBuff(mod.BuffType("Stack"), 300, false);
                    return;
                }
                else if (i >= 12 && i < 15)
                {
                    x = 25;
                    y = 30;
                    z = 45;

                    player.AddBuff(mod.BuffType("Stack"), 360, false);
                    return;
                }
                else if (i >= 15)
                {
                    x = 30;
                    y = 36;
                    z = 54;

                    player.AddBuff(mod.BuffType("Stack"), 420, false);

                        return;

                }
                


            }
        }

        public override void PostUpdate()
        {
            if (rageEmblem.equipped)
            {
                if (use)
                {
                    if (controller)
                    {
                        i2++;
                        {
                            if (i2 >= 60)
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
                        if (i3 >= 100)
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
                    x = 1;
                    y = 1;
                    z = 1;

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
            target1 = null;
        }
    }
    


    public class Stack : ModBuff
    {
        
           
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Stacking fury");
            Description.SetDefault("Each stack grants your weapon 5% dmg, 5% defense shread, 9% magic resist shread");
            Main.buffNoSave[Type] = true;
            Main.debuff[Type] = false;
            canBeCleared = false;
        }
    }
    


}

