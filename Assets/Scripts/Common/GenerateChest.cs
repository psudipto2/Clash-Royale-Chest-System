using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ChestMVC;
using SlotService;

namespace Common
{
    public class GenerateChest : MonoBehaviour
    {
        [SerializeField] private Button generateChest;
        private void Start()
        {
            generateChest = generateChest.GetComponent<Button>();
            generateChest.onClick.AddListener(ChestGenerate);
        }
        private void ChestGenerate()
        {
            SlotController.Instance.SpawnRandomChestOnEmptySlot();
        }
    }
}


