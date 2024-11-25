using Root.Constants;
using UnityEngine.UIElements;
using DG.Tweening;
using Root.Services;
using Root.Tools;
using UnityEngine;

namespace Root.UI
{
    public abstract class UIWindow : UIElement<VisualElement>
    {
        public abstract string Name { get; }

        protected UIDocument _document;

        protected ICreator _creator;
        
        protected IAssetsProvider _assetsProvider;

        protected VisualElement _content;
        
        public virtual void Init(ILocator<IService> services)
        {
            _creator = services.Get<ICreator>();
            
            _assetsProvider = services.Get<IAssetsProvider>();

            ConstructRoot();

            InitElements();
        }

        protected abstract void InitElements();

        private void ConstructRoot()
        {
            var prefab = _assetsProvider.Load<UIDocument>(AssetsConstants.UIWindowsPath + Name);

            _document = _creator.Create(prefab);

            _root = _document.rootVisualElement;

            _content = _root.Q<VisualElement>(UIConstants.Content);
        }

        public override void Show()
        {
            _content.transform.scale = UIConstants.WindowAppearFrom * Vector3.one;

            Active = true;

            var appearTween = DOTween.To(() => _content.transform.scale,
                                    x => _content.transform.scale = x,
                                    Vector3.one, UIConstants.WindowAppearTime);
        }
    }
}
