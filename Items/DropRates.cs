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
    public class DropRates : GlobalItem
    {

        public override void OpenVanillaBag(string context, Player player, int arg)
        {
            if (context == "bossBag" /* && arg == ItemID.FishronBossBag*/)
            {
                

                int caseSwitch = Main.rand.Next(1,15);

                switch (caseSwitch)
                {
                    case 1:

                        player.QuickSpawnItem(mod.ItemType("sniperEmblem"));
                        break;
                    case 2:

                        player.QuickSpawnItem(mod.ItemType("berzerkEmblem"));
                        break;
                    case 3:

                        player.QuickSpawnItem(mod.ItemType("defenderEmblem"));
                        break;
                    case 4:

                        player.QuickSpawnItem(mod.ItemType("rageEmblem"));
                        break;
                    case 5:

                        player.QuickSpawnItem(mod.ItemType("speedEmblem"));
                        break;
                    case 6:

                        player.QuickSpawnItem(mod.ItemType("lifeStealEmblem"));
                        break;

                    default:

                        break;
                }
            }

            //if (npc.type == NPCID.WallofFlesh && !Main.expertMode)//Wall of flesh
            //{

            //    if (Main.rand.Next(2) == 0)
            //    {
            //        Item.NewItem(npc.getRect(), mod.ItemType("sniperEmblem"));
            //    }
            //}
            //if (npc.type == NPCID.WallofFlesh && Main.expertMode) //Wall of flesh expert
            //{

            //    if (Main.rand.Next(2) == 0)
            //    {
            //        Item.NewItem(npc.getRect(), mod.ItemType("berzerkEmblem"));
            //    }
            //}
            //if (npc.type == NPCID.Spazmatism && Main.expertMode) //Spazmatism
            //{

            //    if (Main.rand.Next(2) == 0)
            //    {
            //        Item.NewItem(npc.getRect(), mod.ItemType("defenderEmblem"));
            //    }
            //}
            //if (npc.type == NPCID.Spazmatism && Main.expertMode) //Spazmatism expert
            //{

            //    if (Main.rand.Next(2) == 0)
            //    {
            //        Item.NewItem(npc.getRect(), mod.ItemType("rageEmblem"));
            //    }
            //}
            //if (npc.type == NPCID.SkeletronPrime && !Main.expertMode) //Skeletron Prime
            //{

            //    if (Main.rand.Next(2) == 0)
            //    {
            //        Item.NewItem(npc.getRect(), mod.ItemType("rageEmblem"));
            //    }

            //}
            //if (npc.type == NPCID.SkeletronPrime && Main.expertMode) //Skeletron Prime expert
            //{

            //    if (Main.rand.Next(2) == 0)
            //    {
            //        Item.NewItem(npc.getRect(), mod.ItemType("speedEmblem"));
            //    }
            //}
            //if (npc.type == NPCID.Plantera && !Main.expertMode) //Plantara
            //{

            //    if (Main.rand.Next(2) == 0)
            //    {
            //        Item.NewItem(npc.getRect(), mod.ItemType("speedEmblem"));
            //    }
            //}

            //if (npc.type == NPCID.Plantera && Main.expertMode) //Plantara expert
            //{

            //    if (Main.rand.Next(2) == 0)
            //    {
            //        Item.NewItem(npc.getRect(), mod.ItemType("defenderEmblem"));
            //    }
            //}
            //if (npc.type == NPCID.Pumpking && !Main.expertMode) //Pumpking
            //{

            //    if (Main.rand.Next(2) == 0)
            //    {
            //        Item.NewItem(npc.getRect(), mod.ItemType("berzerkEmblem"));
            //    }
            //}






        }
    }
}
