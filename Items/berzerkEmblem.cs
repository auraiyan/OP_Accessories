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
    public class berzerkEmblem : ModItem
    {
        public float dmgIncrease = 0.40f;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Berzerk Emblem");
            Tooltip.SetDefault("Inceases Dmg by 40% but massivly decreases your defense \n" +
                "Only workes if your hp is lower then 60%");
        }
        public override void SetDefaults()
        {
            item.Size = new Vector2(34);
            item.value = 3887345;
            item.rare = 10;
            item.accessory = true;

        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (player.statLifeMax2 < player.statLifeMax2 * 0.61) {
                if (player.statDefense > 35)
                {
                    player.statDefense -= ((player.statDefense * 40) / 100) + 30;
                }
                else {
                    player.statDefense = 0;
                }
                player.meleeDamage += player.meleeDamage * dmgIncrease;
                player.rangedDamage += player.rangedDamage * dmgIncrease;
                player.magicDamage += player.magicDamage * dmgIncrease;
                player.thrownDamage += player.thrownDamage * dmgIncrease;
                player.bulletDamage += player.bulletDamage * dmgIncrease;

                player.maxRunSpeed += player.maxRunSpeed * .50f;
                player.moveSpeed += player.moveSpeed * .50f;
                player.maxFallSpeed += player.maxFallSpeed * .50f;
                player.accRunSpeed += player.accRunSpeed * .50f;
                player.toolTime += (player.toolTime * 60) / 100;
                player.meleeSpeed += player.meleeSpeed * .30f;

                player.AddBuff(mod.BuffType("Berzerk"), 600, false);
            }
        }
        
    }
    public class Berzerk : ModBuff
    {


        public override void SetDefaults()
        {
            DisplayName.SetDefault("Berzerk Mode");
            Description.SetDefault("Huge boost to your movement, damage and speed");
            Main.buffNoSave[Type] = true;
            Main.debuff[Type] = false;
            canBeCleared = false;
        }
    }

}
