using UnityEngine;

namespace Scriptable
{
    [CreateAssetMenu(fileName = "ChestSOList", menuName = "ScriptableObject/Chest/ChestScriptableObjectList")]
    public class ChestScriptableObjectList : ScriptableObject
    {
        public ChestScriptableObject[] chests;
    }
}

