using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ChestMVC;
using SlotService;
using Common;
using PopUp;
using System;
using Random = UnityEngine.Random;

namespace ChestMVC
{
    public class ChestController
    {
        public ChestModel chestModel;
        public ChestView chestView;
        public float timer;
        public int gemCost;
        public int coinReward;
        public int gemReward;
        public ChestController(ChestModel chestModel,ChestView chestView)
        {
            this.chestModel = chestModel;
            this.chestView = chestView;
            this.timer = chestModel.timerInSeconds;
            this.coinReward = Random.Range(chestModel.coinLowerLimit, chestModel.coinUpperLimit);
            this.gemReward = Random.Range(chestModel.gemLowerLimit, chestModel.gemUpperLimit);
            ShowChestInScene();
        }

        private void ShowChestInScene()
        {
            chestView.SetController(this);
            if (SlotController.Instance.openingChest)
            {
                chestView.CreateLockedChestView();
            }
            else
            {
                chestView.CreateUnlockedChestView();
            }
            
        }
        public int GetGemCost(float timer)
        {
            return Mathf.CeilToInt(timer / 720);
        }

        public IEnumerator StartTimer()
        {
            while (timer > 0)
            {
                chestView.timerText.text = chestView.timerContoller.TimerDisplay((int)timer);
                PopUpController.Instance.timer = timer;
                gemCost = GetGemCost(timer);
                yield return new WaitForSeconds(1f);
                timer -= 1;
            }
            chestView.EnteringOpenedState();
            
        }

    }
}

