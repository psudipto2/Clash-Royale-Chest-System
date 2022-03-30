using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scriptable;

namespace ChestMVC
{
    public class ChestModel
    {
        public int coinUpperLimit { get; set; }
        public int coinLowerLimit { get; set; }
        public int gemUpperLimit { get; set; }
        public int gemLowerLimit { get; set; }
        public int timerInMinutes { get; set; }
        public Sprite closedChestImage { get; set; }
        public Sprite openChestImage { get; set; }
        public ChestModel(ChestScriptableObject chestScriptableObject)
        {
            coinUpperLimit = chestScriptableObject.coinUpperLimit;
            coinLowerLimit = chestScriptableObject.coinLowerLimit;
            gemUpperLimit = chestScriptableObject.gemUpperLimit;
            gemLowerLimit = chestScriptableObject.gemLowerLimit;
            timerInMinutes = chestScriptableObject.timerInMinutes;
            closedChestImage = chestScriptableObject.closedChestImage;
            openChestImage = chestScriptableObject.openChestImage;
        }
    }
}

