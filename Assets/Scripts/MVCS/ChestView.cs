using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using ChestMVC;
using SlotService;
using Common;
using System;

namespace ChestMVC
{
    public class ChestView : MonoBehaviour
    {
        public ChestController chestController;
        [HideInInspector]public Slot currentSlot;

        //Slot View
        [SerializeField] private GameObject slotAvaiable;
        [SerializeField] private GameObject slotNotAvaiable;
        [SerializeField] private Button chestButton;
        [SerializeField] private TextMeshProUGUI timerText;


        public void SetController(ChestController chestController)
        {
            this.chestController = chestController;
        }

        public void CreateLockedChestView()
        {
            slotAvaiable.SetActive(false);
            slotNotAvaiable.SetActive(true);
            chestButton.image.sprite = chestController.chestModel.closedChestImage;
            timerText.text = TimerContoller.Instance.TimerDisplay(chestController.chestModel.timerInMinutes);
        }
    }
}

