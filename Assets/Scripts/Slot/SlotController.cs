using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;
using SlotService;
using SlotState;
using PopUp;

namespace SlotService
{
    public class SlotController : MonoGenericSingleton<SlotController>
    {
        [SerializeField] private Slot[] slots;
        
        [HideInInspector] public bool openingChest;
        private void Start()
        {
            openingChest = false;
        }
        public void SpawnRandomChestOnEmptySlot()
        {
            int slot = GetEmptySlot();
            if (slot == -1)
            {
                PopUpController.Instance.SlotFullPopUp();
            }
            else
            {
                slots[slot].SpawnRandomChest();
            }
        }
        private int GetEmptySlot()
        {
            for (int i = 0; i < 4; i++)
            {
                if (slots[i].currentState==SlotStates.Available)
                {
                    slots[i].currentState = SlotStates.Unavaiable;
                    return i;
                }
            }
            return -1;
        }
        public void MakeOtherChestLocked(Slot openingSlot)
        {
            openingChest = true;
            for (int i = 0; i < 4; i++)
            {
               if(slots[i].currentState==SlotStates.Unavaiable && slots[i]!=openingSlot)
                {
                    slots[i].chestController.chestView.CreateLockedChestView();
                }
            }
        }
        public void MakeOtherChestUnlocked()
        {
            openingChest = false;
            for (int i = 0; i < 4; i++)
            {
                if (slots[i].currentState == SlotStates.Unavaiable)
                {
                    slots[i].chestController.chestView.CreateUnlockedChestView();
                }
            }
        }
        public void MakeSlotAvaialable(Slot currentSlot)
        {
            currentSlot.currentState = SlotStates.Available;
        }
    }
}


