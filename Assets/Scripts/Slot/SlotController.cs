using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;
using SlotService;
using SlotState;

namespace SlotService
{
    public class SlotController : MonoGenericSingleton<SlotController>
    {
        [SerializeField] private Slot[] slots;
        [SerializeField] private GameObject SlotFullPopUp;
        public void SpawnRandomChestOnEmptySlot()
        {
            int slot = GetEmptySlot();
            if (slot == -1)
            {
                if (!SlotFullPopUp.activeInHierarchy)
                {
                    SlotFullPopUp.SetActive(true);
                }
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
    }
}


