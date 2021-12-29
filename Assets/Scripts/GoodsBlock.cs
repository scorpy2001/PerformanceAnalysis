using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PerfomanceAnalysis
{
    public class GoodsBlock : MonoBehaviour
    {
        [SerializeField] private List<Goods> _goodsList;

        public void AddOrSetGoods(Goods goods)
        {
            var existGoods = _goodsList.FirstOrDefault(g => g.GoodsId == goods.GoodsId);
            if (existGoods != null)
            {
                existGoods = goods;
            }
            else
            {
                _goodsList.Add(goods);
            }
        }

        public void RemoveGoods(string goodsId){
            var goods = _goodsList.FirstOrDefault(g => g.GoodsId == goodsId);
            if(goods != null){
                _goodsList.Remove(goods);
            }
        }
    }
}
