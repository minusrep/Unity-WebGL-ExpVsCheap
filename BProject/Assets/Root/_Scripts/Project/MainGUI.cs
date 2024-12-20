using Root.Services;
using Root.Tools;

namespace Root.UI
{
    public class MainGUI : GUI
    {
        private UIWindowHandler _windowHandler;
        
        public override void Init(ILocator<IService> services, ILocator<IController> controllers)
        {
            base.Init(services, controllers);   
            
            InitWindowHandler(services);

            ApplySubscribtions();
            
            Begin();
        }

        private void Begin()
            => _windowHandler.Get<UIGameWindow>().Begin();
        
        private void InitWindowHandler(ILocator<IService> services)
        {
            _windowHandler = new UIWindowHandler();
            
            _windowHandler.Init(services);

            _windowHandler.Add<UIStartWindow>();
            
            _windowHandler.Add<UIGameWindow>();

            _windowHandler.Add<UIOverlayWindow>();

            _windowHandler.Open<UIStartWindow>();
        }
        
        private void ApplySubscribtions()
        {
            var startWindow = _windowHandler.Get<UIStartWindow>();
            
            startWindow.StartButton.OnClick += () => _windowHandler.Open<UIGameWindow>();
        }
    }
}