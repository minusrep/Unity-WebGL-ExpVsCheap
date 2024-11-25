using UnityEngine.UIElements;

namespace Root.UI
{
    public class UIElement<T> where T : VisualElement
    {
        public bool Active 
        {
            get => _root.style.display == DisplayStyle.Flex;

            set
            {
                _root.style.display = value ? DisplayStyle.Flex : DisplayStyle.None;
            }
        }

        protected T _root;

        public UIElement()
        {

        }

        public UIElement(T root = null)
        {
            _root = root;
        }
        
        public virtual void Show()
        {
            Active = true;
        }

        public virtual void Hide()
        {
            Active = false;
        }
    }
}
