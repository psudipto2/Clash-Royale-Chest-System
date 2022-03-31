using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ChestMVC;
using System;

namespace ChestMVC
{
    public class ChestController
    {
        public ChestModel chestModel;
        public ChestView chestView;
        public ChestController(ChestModel chestModel,ChestView chestView)
        {
            this.chestModel = chestModel;
            this.chestView = chestView;
            ShowChestInScene();
        }

        private void ShowChestInScene()
        {
            chestView.SetController(this);
            chestView.CreateLockedChestView();
        }
    }
}

