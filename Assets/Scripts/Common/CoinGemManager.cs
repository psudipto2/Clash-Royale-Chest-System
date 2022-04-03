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
        [SerializeField]private int gem;

        [SerializeField] private TextMeshProUGUI coinNumber;
        [SerializeField] private TextMeshProUGUI gemNumber;

        private void Start()
        {
            coin = 0;
            gem = 2;
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
            Debug.Log("Decreasing Gem");
            gem = gem - gemValue;
            gemNumber.text = gem.ToString();
        }
        public int GetGem()
        {
            return gem;
        }
    }
}

