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
            __runOriginal = false;

            bool isShiftPressed = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

            SlotInfo _ToSlot = (SlotInfo)null;
            if (__instance.CurrentSlot.SlotType == SlotsTypes.Inventory || __instance.CurrentSlot.SlotType == SlotsTypes.Base || __instance.CurrentSlot.SlotType == SlotsTypes.Equipment)
            {
                if (__instance.CurrentSlot.SlotType != SlotsTypes.Equipment || !__instance.CardModel.IsMandatoryEquipment)
                {
                    //---Change.  Move to base is shift is pressed.
                    if (isShiftPressed)
                    {
                        _ToSlot = new SlotInfo(SlotsTypes.Base);
                    }
                    else
                    {
                        _ToSlot = new SlotInfo(SlotsTypes.Item);
                    }
                }
            }
            else if (__instance.CurrentSlot.SlotType == SlotsTypes.Item)
            {
                if ((bool)(UnityEngine.Object)___GraphicsM.InspectedCard && (bool)(UnityEngine.Object)___GraphicsM.CurrentInspectionPopup)
                {
                    if (___GraphicsM.InspectedCard.CardModel.CardType != CardTypes.Explorable)
                        _ToSlot = new SlotInfo(SlotsTypes.Inventory);
                }
                else if (___GraphicsM.CharacterWindow.gameObject.activeInHierarchy)
                {
                    //---Change.  Move to base is shift is pressed.
                    if (isShiftPressed)
                    {
                        _ToSlot = new SlotInfo(SlotsTypes.Base);
                    }
                    else
                    {
                        _ToSlot = new SlotInfo(SlotsTypes.Equipment);
                    }
                }
                else if (!___GraphicsM.HasPopup)
                    _ToSlot = new SlotInfo(SlotsTypes.Base);
            }
            if (_ToSlot == null)
                return;
            _ToSlot.SlotIndex = 1000;
            ___GraphicsM.MoveCardToSlot(__instance, _ToSlot, true, false);

        }

    }
}
