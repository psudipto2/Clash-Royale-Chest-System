using UnityEngine;
using ChestType;

namespace Scriptable
{
    [CreateAssetMenu(fileName = "ChestScriptableObject", menuName = "ScriptableObject/Chest/NewChestScriptableObject")]
    public class ChestScriptableObject : ScriptableObject
    {
        [SerializeField] private ChestTypes chest;
        [SerializeField] public int coinUpperLimit;
        [SerializeField] public int coinLowerLimit;
        [SerializeField] public int gemUpperLimit;
        [SerializeField] public int gemLowerLimit;
        [SerializeField] public int timerInSeconds;
        [SerializeField] public Sprite closedChestImage;
        [SerializeField] public Sprite openChestImage;
    }
}
