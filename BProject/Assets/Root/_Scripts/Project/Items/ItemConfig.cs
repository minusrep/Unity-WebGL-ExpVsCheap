using System;
using UnityEngine;

namespace Root
{
    [Serializable]
    public class ItemConfig
    {
        public string Name => _name;
        
        public float Price => _price;
        
        public Sprite Icon => _icon;
        
        public ItemState State => _state;
        
        [SerializeField] private string _name;

        [SerializeField] private float _price;

        [SerializeField] private Sprite _icon;
        
        [SerializeField] private ItemState _state;
    }
}