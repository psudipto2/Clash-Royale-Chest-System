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
        [HideInInspector] public int gem;

        [SerializeField] private TextMeshProUGUI coinNumber;
        [SerializeField] private TextMeshProUGUI gemNumber;

        public void SetCoinGem(int coin,int gem)
        {
            this.coin = coin;
            this.gem = gem;
            coinNumber.text = coin.ToString();
            gemNumber.text = gem.ToString();
        }
        public void IncreaseCoin(int coinValue)
        {
            coin += coinValue;
            coinNumber.text = coin.ToString();
        }
        public void IncreaseGem(int gemValue)
        {
            gem += gemValue;
            gemNumber.text = gem.ToString();
        }
        public void DecreaseGem(int gemValue)
        {
            gem -= gemValue;
        }
    }
}

