using System;
using UnityEngine;

namespace Root
{
    [CreateAssetMenu(fileName = "itemConfig", menuName = "Configs/Item Config", order = 1)]
    public class ItemConfig : ScriptableObject
    {
        public string Name => _name;
        
        public float Price => _price;
        
        public Sprite Icon => _icon;

        public int ID => _id;
        
        [SerializeField] private string _name;

        [SerializeField] private float _price;

        [SerializeField] private Sprite _icon;

        [SerializeField] private int _id;
    }
}