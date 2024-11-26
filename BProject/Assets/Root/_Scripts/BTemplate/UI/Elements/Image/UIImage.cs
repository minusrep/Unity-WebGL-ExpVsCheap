using Root.UI;
using UnityEngine;
using UnityEngine.UIElements;

namespace Root.UI
{
    public class UIImage : UIElement<VisualElement>
    {
        public Sprite Sprite
        {
            get => _root.style.backgroundImage.value.sprite;
            
            set
            {
                _root.style.backgroundImage = new StyleBackground(value);    
            }
        }
        
        public UIImage(VisualElement root) : base(root)
        {
            
        }
    }
}