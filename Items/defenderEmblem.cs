using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace OP_Accessories.Sprites
{

    public class defenderEmblem : ModItem
    {
        public static bool active = false;
        public static int PlayerHPbase;
        public static int PlayerHP2base;
        public static int PlayerHP;
        public static int playerHP2;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Defender Emblem");
            Tooltip.SetDefault("Doubles Armor! increases HP by 30%\n" +
                "but decreases potion healing by 50% \n" +
                "Increases immune time and grants immunity to broken armor");
        }
        public override void SetDefaults()
        {
            item.Size = new Vector2(34);
            item.value = 9664502;
            item.rare = 8;
            item.accessory = true;


        }
        public override void UpdateAccessory(Player player, bool hideVisual)

        {
            active = true;
            
            if (player.statDefense > 1)
            {
                player.statDefense *= 2;
            }
                player.AddBuff(mod.BuffType("WarBuff"), 600, false);
                player.AddBuff(mod.BuffType("Armor"), 600, false);
                player.longInvince = true;
                player.buffImmune[BuffID.BrokenArmor] = true;

            player.noFallDmg = true;
            player.noKnockback = true;
            if (player.statLifeMax > 100)
            {
                player.statLifeMax2 = (player.statLifeMax * 150) / 100;

            }
            else
            {
                player.statLifeMax = 100;
            }
        }
        


    }


        public class WarBuff : ModBuff
        {


            public override void SetDefaults()
            {
                DisplayName.SetDefault("Warmog's Heart");
                Description.SetDefault("Massive HP regen while not in combat");
                Main.buffNoSave[Type] = true;
                Main.debuff[Type] = false;
                canBeCleared = false;
            }



        }
        public class Armor : ModBuff
        {

            public override void SetDefaults()
            {
                DisplayName.SetDefault("Blessing of." +
                    " nature");
                Description.SetDefault("Grants immunity to broken armor and Doubles current defense");
                Main.buffNoSave[Type] = true;
                Main.debuff[Type] = false;
                canBeCleared = false;
            }

        }
        public class Cooldown : ModBuff
        {

            public override void SetDefaults()
            {
                DisplayName.SetDefault("Warmog's curse is upon you");
                Description.SetDefault("you have caused pain to his heart");
                Main.buffNoSave[Type] = true;
                Main.debuff[Type] = true;
                canBeCleared = false;
            }

        }
        public class liferegen : ModPlayer
        {

            public int i = 0;
            public bool hurt = true;

        public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            if (defenderEmblem.active)
            {
                {
                    if (Main.rand.NextFloat(0, 100) > 70 && !hurt)
                    {

                        return false;
                    }
                    else
                    {
                        player.AddBuff(mod.BuffType("Cooldown"), 600, false);
                        player.ClearBuff(mod.BuffType("WarBuff"));
                        hurt = true;
                        i = 0;
                        return base.PreHurt(pvp, quiet, ref damage, ref hitDirection, ref crit, ref customDamage, ref playSound, ref genGore, ref damageSource);
                    }
                }
            }
     return base.PreHurt(pvp, quiet, ref damage, ref hitDirection, ref crit, ref customDamage, ref playSound, ref genGore, ref damageSource);
                   
        }
        public override void PostHurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
        {

            if (defenderEmblem.active)
            {

                player.immune = true;
                player.immuneTime = 80;
                base.PostHurt(pvp, quiet, damage, hitDirection, crit);
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
            defenderEmblem.active = false;
        }

        public virtual void GetHealLife(Item item, bool quickHeal, ref int healValue)
            {
            if (defenderEmblem.active)
            {
                healValue -= (healValue * 20) / 100;
            }
            }

        public override void PostUpdate()
        {
            if (defenderEmblem.active)
            {
                if (hurt)
                {
                    player.lifeRegen = 0;
                    i++;

                    player.ClearBuff(mod.BuffType("WarBuff"));
                    {
                        if (i >= 600)
                        {

                            hurt = false;
                        }
                    }
                }
                else
                {
                    if (player.statLife < player.statLifeMax2-1)
                    {
                        player.statLife += 2;
                        player.HealEffect(2);
                    }
                }
            }
        }
        }

    }






