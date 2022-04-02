using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using ChestMVC;
using SlotService;
using Common;
using ChestState;
using PopUp;
using System;

namespace ChestMVC
{
    public class ChestView : MonoBehaviour
    {
        public ChestController chestController;
        [HideInInspector] public Slot currentSlot;
        [SerializeField] public TimerContoller timerContoller;
        [HideInInspector] public ChestStates currentState;

        [Header("Slot View")]
        [SerializeField] private GameObject slotAvaiable;
        [SerializeField] private GameObject slotNotAvaiable;
        [SerializeField] private Button chestButton;
        [SerializeField] public TextMeshProUGUI timerText;
        [SerializeField] private TextMeshProUGUI chestStatus;
        [SerializeField] private GameObject timerImage;

        
        

        public void SetController(ChestController chestController)
        {
            this.chestController = chestController;
        }

        public void CreateLockedChestView()
        {
            slotAvaiable.SetActive(false);
            slotNotAvaiable.SetActive(true);
            timerImage.SetActive(false);
            chestButton.image.sprite = chestController.chestModel.closedChestImage;
            timerText.text = timerContoller.TimerDisplay(chestController.chestModel.timerInSeconds);
            //chestButton.enabled = true;
            currentState = ChestStates.Locked;
            chestStatus.text = "Locked";
        }
        public void CreateUnlockedChestView()
        {
            slotAvaiable.SetActive(false);
            slotNotAvaiable.SetActive(true);
            timerImage.SetActive(true);
            chestButton.image.sprite = chestController.chestModel.closedChestImage;
            timerText.text = timerContoller.TimerDisplay((int)chestController.timer);
            chestStatus.text = "Open";
            //chestButton.enabled = true;
            //SlotController.Instance.openingChest = true;
            currentState = ChestStates.Unlocked;
        }

        public void CreateEmptyChestView()
        {
            slotAvaiable.SetActive(true);
            slotNotAvaiable.SetActive(false);
            currentState = ChestStates.None;
        }
        

        /*public void CreateOpeningChestView()
        {
            timerText.text = timerContoller.TimerDisplay((int)chestController.timer);
        }*/

        public void OnClickChestButton()
        {
            Debug.Log("Button Clicked");
            if (currentState == ChestStates.Locked)
            {
                PopUpController.Instance.CantOpenPopUp();
            }
            else if (currentState == ChestStates.Unlocked)
            {
                ChestService.Instance.currentController = chestController;
                PopUpController.Instance.UnlockChestPopUpTrue(chestController.GetGemCost(chestController.timer), chestController.chestModel.closedChestImage,chestController);
            }
            else if (currentState == ChestStates.Opening)
            {
                //ChestService.Instance.currentController = chestController;
                PopUpController.Instance.OpeningChestPopUpTrue(chestController.gemCost, chestController.chestModel.closedChestImage, chestController);                
            }
        }
        
        public void EnterOpeningState()
        {
            PopUpController.Instance.UnlockChestPopUpFalse();
            SlotController.Instance.MakeOtherChestLocked(currentSlot);
            currentState = ChestStates.Opening;
            StartCoroutine(chestController.StartTimer());
        }

        public void OpenInstantly()
        {
            if (CoinGemManager.Instance.gem < chestController.gemCost)
            {
                PopUpController.Instance.NotEnoughGemsPopUp();
                PopUpController.Instance.CloseActivePopUp();
            }
            PopUpController.Instance.CloseActivePopUp();
            CoinGemManager.Instance.DecreaseGem(chestController.gemCost);
            PopUpController.Instance.RewardPopUp(chestController.coinReward, chestController.gemReward,chestController.chestModel.openChestImage);
            RecieveRewards(chestController.coinReward, chestController.gemReward);
            CreateEmptyChestView();
            SlotController.Instance.MakeSlotAvaialable(currentSlot);
            SlotController.Instance.MakeOtherChestUnlocked();
            currentSlot.chestController = null;
        }
        private void RecieveRewards(int coinReward,int gemReward)
        {
            CoinGemManager.Instance.IncreaseCoin(coinReward);
            CoinGemManager.Instance.IncreaseGem(gemReward);
        }
    }
}

