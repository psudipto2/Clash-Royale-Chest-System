using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scriptable;
using SlotState;
using SlotService;
using ChestMVC;

namespace SlotService
{
    public class Slot : MonoBehaviour
    {
        [HideInInspector] public SlotStates currentState;
        [SerializeField] ChestView chestView;
        public ChestController chestController;
        private void Start()
        {
            currentState = SlotStates.Available;
            CurrentSlot();
        }
        public void SpawnRandomChest()
        {
            chestController=ChestService.Instance.CreateNewChest(chestView);
        }
        public void CurrentSlot()
        {
            chestView.currentSlot = this;
        }
    }
}

