using System.Collections.Generic;
using UnityEngine;

namespace PerfomanceAnalysis
{
    [CreateAssetMenu(menuName = "Create/" + nameof(GoodsListScriptableObject), fileName = nameof(GoodsListScriptableObject))]
    public class GoodsListScriptableObject : ScriptableObject
    {
        public List<GoodsScriptableObject> GoodsList;
    }
}
