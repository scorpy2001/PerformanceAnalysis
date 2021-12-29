using UnityEngine;

namespace PerfomanceAnalysis
{
    [CreateAssetMenu(menuName = "Create/" + nameof(GoodsScriptableObject), fileName = nameof(GoodsScriptableObject))]
    public class GoodsScriptableObject : ScriptableObject
    {
        public Sprite Sprite;
        public string GoodsId;
        public int Price;
        public int SecondsLeft;
    }
}
