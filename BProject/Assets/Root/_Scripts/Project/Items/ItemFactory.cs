using System.Collections.Generic;
using DG.Tweening;
using Mono.Cecil.Cil;
using Root.Constants;
using Root.Services;
using UnityEngine;
using UnityEngine.UIElements;

namespace Root
{
    public class ItemFactory
    {
        private const int MAX_QUEUE_COUNT = 2;
        
        private IAssetsProvider _assetsProvider;

        private VisualElement _container;

        private VisualTreeAsset _itemPrefab;

        private List<ItemConfig> _itemConfigs;
        
        private ItemBackgroundColors _itemBackgroundColors;
        
        public void Init(IAssetsProvider assetsProvider, VisualElement container)
        {
            _assetsProvider = assetsProvider;
            
            _container = container;

            _itemConfigs = new List<ItemConfig>();

            _itemBackgroundColors = assetsProvider.Load<ItemBackgroundColors>(AssetsConstants.ItemBackgroundColors);
            
            _itemConfigs.AddRange(assetsProvider.LoadAll<ItemConfig>(AssetsConstants.ItemConfigs));
            
            InitItemPrefab();
        }
        
        public Item Create()
        {
            var config = _itemConfigs[Random.Range(0, _itemConfigs.Count)];
            
            var source = _itemPrefab.Instantiate();

            var item = new Item(source, config);
            
            RandomizeColor(item);
            
            _container.Add(source);

            item.Show();
            
            return item;
        }

        public void RandomizeColor(Item item)
        {
            item.Color = _itemBackgroundColors.GetRandom();
        }

        public void Destroy(Item item)
            => item.Hide(() => _container.Remove(item.Root));
        
        private void InitItemPrefab()
        {
            _itemPrefab = _assetsProvider.Load<VisualTreeAsset>(AssetsConstants.ItemPrefabPath);
        }
    }
}