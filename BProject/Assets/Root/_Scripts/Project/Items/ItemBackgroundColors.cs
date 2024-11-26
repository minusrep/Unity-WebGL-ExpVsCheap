using System.Collections.Generic;
using UnityEngine;

namespace Root
{
    [CreateAssetMenu(fileName = "ItemBackgroundColors", menuName = "Configs/ItemBackgroundColors")]
    public class ItemBackgroundColors : ScriptableObject
    {
        public List<Color> Colors => _colors;
        
        public Color GetRandom() => _colors[Random.Range(0, _colors.Count)];
        
        [SerializeField] private List<Color> _colors;

        [SerializeField] private int _generationCount;

    }
}