using Codice.CM.Triggers;
using Root.Constants;
using UnityEngine.UIElements;

namespace Root.UI
{
    public class UIMainWindow : UIWindow
    {
        public override string Name => "UIMainWindow";

        private ItemFactory _itemFactory;
        
        protected override void InitElements()
        {
            _itemFactory = new ItemFactory();
            
            _itemFactory.Init(_assetsProvider, _content);

            _itemFactory.Create();
        }
    }
}