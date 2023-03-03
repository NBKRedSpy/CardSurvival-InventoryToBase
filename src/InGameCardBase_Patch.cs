using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using UnityEngine;

namespace InventoryToBase
{
    /// <summary>
    /// Most of this code is the game's code.  Needed to just add the .Base redirection when holding shift.
    /// </summary>
    [HarmonyPatch(typeof(InGameCardBase), nameof(InGameCardBase.SwapCard))]
    public static class InGameCardBase_Patch
    {

        public static void Prefix(InGameCardBase __instance, ref bool __runOriginal, GraphicsManager ___GraphicsM)
        {
            

            if(!(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
            {
                __runOriginal = true;
                return;
            }

            __runOriginal = false;

            SlotInfo slotInfo = null;

            if (__instance.CurrentSlot.SlotType == SlotsTypes.Inventory || __instance.CurrentSlot.SlotType == SlotsTypes.Base || __instance.CurrentSlot.SlotType == SlotsTypes.Equipment)
            {
                if (__instance.CurrentSlot.SlotType != SlotsTypes.Equipment || !__instance.CardModel.IsMandatoryEquipment)
                {
                    slotInfo = new SlotInfo(SlotsTypes.Base);
                }
            }
            else if (__instance.CurrentSlot.SlotType == SlotsTypes.Item)
            {
                if ((bool)(UnityEngine.Object)___GraphicsM.InspectedCard && (bool)(UnityEngine.Object)___GraphicsM.CurrentInspectionPopup)
                {
                    if (___GraphicsM.InspectedCard.CardModel.CardType != CardTypes.Explorable)
                        slotInfo = new SlotInfo(SlotsTypes.Inventory);
                }
                else if (___GraphicsM.CharacterWindow.gameObject.activeInHierarchy)
                {
                    slotInfo = new SlotInfo(SlotsTypes.Base);
                }
                else if (!___GraphicsM.HasPopup)
                {
                    slotInfo = new SlotInfo(SlotsTypes.Base);
                }
            }

            if (slotInfo != null)
            {
                slotInfo.SlotIndex = 1000;
                ___GraphicsM.MoveCardToSlot(__instance, slotInfo, false, false);
            }

        }

    }
}
