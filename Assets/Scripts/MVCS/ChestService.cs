using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;
using Scriptable;
using PopUp;
using ChestMVC;
using System;
using Common;
using Random = UnityEngine.Random;

namespace ChestMVC
{
    public class ChestService : MonoGenericSingleton<ChestService>
    {
        public ChestScriptableObjectList chestList;
        public ChestController currentController;
        [HideInInspector] public ChestScriptableObject chestScriptable;
        private List<ChestController> chests = new List<ChestController>();



        public ChestController CreateNewChest(ChestView chestView)
        {
            int rand = Random.Range(0, chestList.chests.Length);
            chestScriptable = chestList.chests[rand];
            ChestModel chestModel = new ChestModel(chestScriptable);
            ChestController chestController = new ChestController(chestModel, chestView);
            return chestController;
        }

        public void OpenInstantly()
        {
            currentController.chestView.OpenInstantly();

        }
        public void StartTimer()
        {
            currentController.chestView.EnterOpeningState();
        }

        public void OpenChest()
        {
            currentController.chestView.OpenChest();
        }
    }
}

