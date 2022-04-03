using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Singleton;
using TMPro;
using Common;
using ChestMVC;

namespace PopUp
{
    public class PopUpController : MonoGenericSingleton<PopUpController>
    {
        [Header("Unlocked Chest Pop Up")]
        [SerializeField] private GameObject unlockedChestPopUp;
        [SerializeField] private Image unlockedPopUpChestImage;
        [SerializeField] private Button unlockWithGems;

        [Header("Opening Chest Pop Up")]
        [SerializeField] private GameObject openingChestPopUp;
        [SerializeField] private Image openingChestPopUpChestImage;
        [SerializeField] private Button openWithGems;
        [SerializeField] private TextMeshProUGUI timerText;

        [Header("Opened Chest Pop Up")]
        [SerializeField] private GameObject openedChestPopup;
        [SerializeField] private Image openedChestPopUpChestImage;

        [Header("Reward Pop Up")]
        [SerializeField] private GameObject rewardPopup;
        [SerializeField] private TextMeshProUGUI coinText;
        [SerializeField] private TextMeshProUGUI gemText;
        [SerializeField] private Image rewardChestImage;

        [Header("Common Pop Up")]
        [SerializeField] private GameObject cantOpenPopUp;
        [SerializeField] private GameObject slotFullPopUp;
        [SerializeField] private GameObject notEnoughGamesPopUp;

        [HideInInspector]public ChestController chestController;
        private GameObject activePopUp;
        [HideInInspector]public float timer;
        [SerializeField] private TimeDisplay timerContoller;
        public void UnlockChestPopUpTrue(int GemNumber,Sprite chestImage, ChestController Controller)
        {
            unlockedChestPopUp.SetActive(true);
            unlockedPopUpChestImage.sprite = chestImage;
            unlockWithGems.GetComponentInChildren<TextMeshProUGUI>().text = GemNumber.ToString();
            this.chestController = Controller;
            activePopUp = unlockedChestPopUp;
        }
        public void OpeningChestPopUpTrue(int GemNumber, Sprite chestImage, ChestController Controller)
        {
            openingChestPopUp.SetActive(true);
            openingChestPopUpChestImage.sprite = chestImage;
            openWithGems.GetComponentInChildren<TextMeshProUGUI>().text = GemNumber.ToString();
            timerText.text = timerContoller.TimerDisplay((int)timer);
            this.chestController = Controller;
            activePopUp = openingChestPopUp;
        }

        public void OpenedChestPopUp(Sprite chestImage)
        {
            openedChestPopup.SetActive(true);
            openedChestPopUpChestImage.sprite = chestImage;
            activePopUp = openedChestPopup;
        }

        public void RewardPopUp(int coinReward, int gemReward, Sprite chestImage) 
        {
            rewardPopup.SetActive(true);
            coinText.text = coinReward.ToString();
            gemText.text = gemReward.ToString();
            rewardChestImage.sprite = chestImage;
        }
        public void UnlockChestPopUpFalse()
        {
            unlockedChestPopUp.SetActive(false);
            chestController = null;
        }

        public void OpeningChestPopUpFalse()
        {
            openingChestPopUp.SetActive(false);
        }

        public void CantOpenPopUp()
        {
            cantOpenPopUp.SetActive(true);
        }
        public void SlotFullPopUp()
        {
            slotFullPopUp.SetActive(true);
        }
        public void NotEnoughGemsPopUp()
        {
            notEnoughGamesPopUp.SetActive(true);
        }
        public void CloseActivePopUp()
        {
            activePopUp.SetActive(false);
            chestController = null;
        }
        
    }
}

