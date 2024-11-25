using Root.Constants;
using Root.UI;
using UnityEngine.UIElements;

namespace Root
{
    public class Item : UIElement<VisualElement>
    {
        public ItemConfig Config
        {
            set
            {
                _title.Value = value.Name;
                
                _price.Value = value.Price.ToString();

                _controls.Active = value.State == ItemState.New;
            }
        }

        private UIText _title;

        private UIText _price;
        
        private UIElement<VisualElement> _controls;

        private UIElement<Image> _icon;
        
        private UIButton _greaterButton;
        
        private UIButton _lessButton;
        
                
        public Item(VisualElement root) : base(root)
        {
            InitElements(root);
        }

        private void InitElements(VisualElement root)
        {
            _title = new UIText(_root.Q<Label>(UIConstants.Title));
            
            _price = new UIText(_root.Q<Label>(UIConstants.Price));

            _controls = new UIElement<VisualElement>(_root.Q<Label>(UIConstants.Controls));
            
            _icon = new UIElement<Image>(_root.Q<Image>(UIConstants.Icon));
            
            _greaterButton = new UIButton(_root.Q<Button>(UIConstants.GreaterButton));
            
            _lessButton = new UIButton(_root.Q<Button>(UIConstants.LessButton));
        }
    }
}