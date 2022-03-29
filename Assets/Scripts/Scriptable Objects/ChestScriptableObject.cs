using UnityEngine;
using ChestType;

namespace Scriptable
{
    [CreateAssetMenu(fileName = "ChestScriptableObject", menuName = "ScriptableObject/Chest/NewChestScriptableObject")]
    public class ChestScriptableObject : ScriptableObject
    {
        [SerializeField] private ChestTypes chest;
        [SerializeField] private int coinUpperLimit;
        [SerializeField] private int coinLowerLimit;
        [SerializeField] private int gemUpperLimit;
        [SerializeField] private int gemLowerLimit;
        [SerializeField] private int timerInMinutes;
        [SerializeField] private Sprite closedChestImage;
        [SerializeField] private Sprite openChestImage;
    }
}
