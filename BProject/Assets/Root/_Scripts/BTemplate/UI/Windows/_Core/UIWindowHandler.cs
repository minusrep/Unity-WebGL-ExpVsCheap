using System;
using System.Collections.Generic;
using System.Linq;
using Root.Services;
using Root.Tools;

namespace Root.UI
{
    public class UIWindowHandler : IWindowManipulator, IServiceUser
    {
        protected ILocator<IService> _services;

        private List<UIWindow> _windows;

        private UIWindow _actual;

        private UIWindow _previous;

        public UIWindowHandler()
        {
            _windows = new List<UIWindow>();
        }

        public virtual void Init(ILocator<IService> serviceLocator) 
            => _services = serviceLocator;

        public void Open<T>() where T : UIWindow
        {
            Clear();

            var founded = _windows.First(a => a is T);

            if (founded == null) throw new KeyNotFoundException($"{typeof(T)} not found");

            _previous = _actual;

            _actual = founded;

            _actual.Show();
        }

        public T Get<T>() where T : UIWindow
        {
            var founded = _windows.First(a => a is T);

            if (founded == null) throw new KeyNotFoundException($"{typeof(T)} not found");

            return founded as T;
        }

        public void Add<T>() where T : UIWindow, new()
        {
            var window = new T();

            window.Init(_services);

            _windows.Add(window);
        }
        
        public void PreviousWindow()
        {
            Clear();

            if (_previous == null) throw new ArgumentNullException("Previous window is empty");

            var last = _actual;

            _actual = _previous;

            _previous = last;

            _actual.Show();
        }

        protected void Clear()
            => _windows.ForEach(a => a.Hide());


    }
}
