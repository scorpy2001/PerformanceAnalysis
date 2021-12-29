using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

namespace PerfomanceAnalysis
{
    public class ShopManager : MonoBehaviour
    {
        [SerializeField] private GoodsListScriptableObject _goodsScriptableObjectList;
        [SerializeField] private Goods _goodsPrefab;
        [SerializeField] private Transform _goodsBlock;
        [SerializeField] private Transform _abilityBlock;
        [SerializeField] private TMP_Text _moneyText;
        [SerializeField] private int _money;

        private List<Goods> _goodsList;
        private List<Goods> _abilityList;
        private YieldInstruction _waiterOneSecond;

        private int Money
        {
            get => _money;
            set
            {
                _money = value;
                _moneyText.text = _money.ToString();
            }
        }

        private void Start()
        {
            _waiterOneSecond = new WaitForSeconds(1);

            _abilityList = new List<Goods>();
            _goodsList = new List<Goods>();
            _moneyText.text = Money.ToString();

            foreach (var goods in _goodsScriptableObjectList.GoodsList)
            {
                var goodsObject = Instantiate(_goodsPrefab, _goodsBlock);
                goodsObject.Init(goods, GoodsType.Goods);
                goodsObject.Price = goods.Price;
                goodsObject.OnGoodsClick += GoodsSelect;
                _goodsList.Add(goodsObject);
            }

            StartCoroutine(AbilityUpdate());
        }

        private IEnumerator AbilityUpdate()
        {
            var abilitiesToRemove = new List<Goods>();

            while (true)
            {
                yield return _waiterOneSecond;

                foreach (var ability in _abilityList)
                {
                    ability.SecondsLeft -= 1;
                    if(ability.SecondsLeft <= 0){
                        abilitiesToRemove.Add(ability);
                    }
                }

                foreach (var ability in abilitiesToRemove)
                {
                    _abilityList.Remove(ability);
                    Destroy(ability.gameObject);
                }
                abilitiesToRemove.Clear();

                Money += 1;
            }
        }

        private void GoodsSelect(string goodsId)
        {
            var goods = _goodsScriptableObjectList.GoodsList.FirstOrDefault(g => g.GoodsId == goodsId);

            if (goods != null)
            {
                var price = goods.Price;
                if (price <= Money)
                {
                    var ability = _abilityList.FirstOrDefault(a => a.GoodsId == goodsId);
                    if (ability == null)
                    {
                        var abilityObject = Instantiate(_goodsPrefab, _abilityBlock);
                        abilityObject.Init(goods, GoodsType.Ability);
                        abilityObject.SecondsLeft = goods.SecondsLeft;
                        _abilityList.Add(abilityObject);
                    }
                    else
                    {
                        ability.SecondsLeft += goods.SecondsLeft;
                    }
                    Money -= price;
                }
            }
        }

        private void OnDestroy()
        {
            foreach (var goods in _goodsList)
            {
                goods.OnGoodsClick -= GoodsSelect;
            }
        }
    }
}
