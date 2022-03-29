using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Singleton;

namespace Common
{
    public class CoinGemManager : MonoGenericSingleton<CoinGemManager>
    {
        private int coin;
        private int gem;

        [SerializeField] private TextMeshProUGUI coinNumber;
        [SerializeField] private TextMeshProUGUI gemNumber;

        public void UpdateCoin(int coinValue)
        {
            coin += coinValue;
            coinNumber.text = coin.ToString();
        }
        public void UpdateGem(int gemValue)
        {
            gem += gemValue;
            gemNumber.text = gem.ToString();
        }
    }
}

