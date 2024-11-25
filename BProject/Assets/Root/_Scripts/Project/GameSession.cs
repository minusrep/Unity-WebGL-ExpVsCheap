using System.Collections;
using Root.Services;
using Root.UI;
using UnityEngine;

namespace Root.Sessions
{
    public class GameSession : Session
    {
        protected override SceneType Scene => SceneType.Game;

        protected override IEnumerator Init()
        {
            yield return new WaitUntil(() => IsLoaded);
            
            MainGUI _gui = new MainGUI();
            
            RegisterController<MainGUI>(_gui);
        }
    }
}