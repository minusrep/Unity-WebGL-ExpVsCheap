using System.Collections.Generic;
using Codice.CM.Triggers;
using Root.Constants;
using UnityEngine.UIElements;

namespace Root.UI
{
    public class UIGameWindow : UIWindow
    {
        private const int MAX_QUEUE_SIZE = 2;
        
        public override string Name => "UIMainWindow";

        private ItemFactory _itemFactory;
        
        private ItemComparer _itemComparer;

        protected override void InitElements()
        {
            _itemFactory = new ItemFactory();
            
            _itemComparer = new ItemComparer(_itemFactory);
            
            _itemFactory.Init(_assetsProvider, _content);
            
            _itemComparer.Setup();
        }

        public void Begin()
        {
        }
        
        public void Reset()
        {
        }
    }
}