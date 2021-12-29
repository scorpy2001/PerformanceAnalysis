using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PerfomanceAnalysis
{
    public class Goods : MonoBehaviour
    {
        public event Action<string> OnGoodsClick = delegate { };
        [SerializeField] private TMP_Text _infoText;
        [SerializeField] private Image _image;
        [SerializeField] private Button _button;
        [SerializeField] private string _goodsId;
        [SerializeField] private int _price;
        [SerializeField] private int _secondsLeft;
        [SerializeField] private GoodsType _type = GoodsType.None;

        //public string Text { set { _infoText.text = value; } }
        public int Price
        {
            set
            {
                _price = value;
                _infoText.text = _price.ToString();
            }
        }

        public int SecondsLeft
        {
            get => _secondsLeft;
            set
            {
                _secondsLeft = value;
                _infoText.text = _secondsLeft.ToString();
            }
        }

        public string GoodsId => _goodsId;

        private void OnEnable()
        {
            if (_goodsId != null && _type == GoodsType.Goods)
            {
                _button.onClick.AddListener(() => { OnGoodsClick.Invoke(_goodsId); });
            }
        }

        private void OnDisable()
        {
            _button.onClick.RemoveAllListeners();
        }

        public void Init(GoodsScriptableObject goods, GoodsType type)
        {
            _image.sprite = goods.Sprite;
            _goodsId = goods.GoodsId;
            _type = type;
            // _price = goods.Price;
            // _secondsLeft = goods.SecondsLeft;
            if (_type == GoodsType.Goods)
            {
                _button.onClick.RemoveAllListeners();
                _button.onClick.AddListener(() => { OnGoodsClick.Invoke(_goodsId); });
            }
        }
    }
}
