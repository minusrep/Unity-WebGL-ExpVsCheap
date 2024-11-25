using Root.Constants;
using UnityEngine;
using UnityEngine.UIElements;

namespace Root.UI
{
    public class UIStartWindow : UIWindow
    {
        public override string Name => "UIStartWindow";

        public UIButton StartButton { get; private set; }
        
        protected override void InitElements()
        {
            StartButton = new UIButton(_root.Q<Button>(UIConstants.StartButton));
        }
    }
}