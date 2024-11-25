using Root.Constants;
using Root.Services;
using UnityEngine.UIElements;

namespace Root
{
    public class ItemFactory
    {
        private IAssetsProvider _assetsProvider;

        private VisualElement _container;

        private VisualTreeAsset _itemPrefab;
        
        public void Init(IAssetsProvider assetsProvider, VisualElement container)
        {
            _assetsProvider = assetsProvider;
            
            _container = container;
            
            InitItemPrefab();
        }

        public Item Create()
        {
            var source = _itemPrefab.Instantiate();
            
            _container.Add(source);

            return new Item(source);
        }
        
        private void InitItemPrefab()
        {
            _itemPrefab = _assetsProvider.Load<VisualTreeAsset>(AssetsConstants.ItemPrefabPath);
        }
    }
}