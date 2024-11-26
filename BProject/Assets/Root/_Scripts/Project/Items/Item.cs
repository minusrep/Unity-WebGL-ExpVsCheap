using System;
using DG.Tweening;
using Root.Constants;
using Root.UI;
using UnityEngine;
using UnityEngine.UIElements;

namespace Root
{
    public class Item : UIElement<VisualElement>
    {
        public VisualElement Parent => _root.parent;
        
        public float Price { get; private set; }

        public Color Color
        {
            get => _root.style.backgroundColor.value;
            
            set => _root.style.backgroundColor = value;
        }
        
        public bool Selectable
        {
            set
            {
                _controls.Active = value;
                
                _price.Active = !value;
            }
        }
        
        public VisualElement Root => _root;

        public Action<bool> ControlsCallback
        {
            set
            {
                _greaterButton.OnClick += () => value(true);
                
                _lessButton.OnClick += () => value(false);
            }
        }
        
        private ItemConfig Config
        {
            set
            {
                _title.Value = value.Name;
                
                Price = value.Price;
                
                _price.Value = value.Price.ToString();

                _icon.Sprite = value.Icon;
            }
        }
        
        private UIText _title;

        private UIText _price;
        
        private UIElement<VisualElement> _controls;

        private UIImage _icon;
        
        private UIButton _greaterButton;
        
        private UIButton _lessButton;

        public Item(VisualElement root, ItemConfig config = null) : base(root)
        {
            InitElements(root);
            
            if (config != null) Config = config;
        }

        private void InitElements(VisualElement root)
        {
            _title = new UIText(_root.Q<Label>(UIConstants.Title));
            
            _price = new UIText(_root.Q<Label>(UIConstants.Price));

            _controls = new UIElement<VisualElement>(_root.Q<VisualElement>(UIConstants.Controls));
            
            _icon = new UIImage(_root.Q<VisualElement>(UIConstants.MainIcon));
            
            _greaterButton = new UIButton(_root.Q<Button>(UIConstants.GreaterButton));
            
            _lessButton = new UIButton(_root.Q<Button>(UIConstants.LessButton));
        }

        public override void Show()
        {
            DOTween.To(() => _root.resolvedStyle.width,
                    x => _root.style.width = new Length(x, LengthUnit.Pixel),
                    960, 0.25f)
                .SetEase(Ease.Linear);
        }

        public void Hide(Action onComplete = null)
        {
            DOTween.To(() => _root.resolvedStyle.width,
                    x => _root.style.width = new Length(x, LengthUnit.Pixel),
                    0, 0.25f)
                .SetEase(Ease.Linear)
                .OnComplete(() => onComplete?.Invoke());
        }
        
        public override void Hide()
        {
            DOTween.To(() => _root.resolvedStyle.width,
                    x => _root.style.width = new Length(x, LengthUnit.Pixel),
                    0, 0.25f)
                .SetEase(Ease.Linear);
        }
    }
}