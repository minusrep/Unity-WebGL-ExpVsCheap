using System;
using UnityEngine;

namespace Root
{
    public class ItemComparer
    {
        private Item Current
        {
            get => _current;
            
            set
            {
                _current = value;

                _current.Selectable = false;
            }
        }

        private Item Selectable
        {
            get => _selectable;
            
            set
            {
                _selectable = value;

                _selectable.ControlsCallback = Compare;

                _selectable.Selectable = true;

                while (_selectable.Color == _current.Color)
                    _factory.RandomizeColor(_selectable);
            }
        }
        
        private Item _current;

        private Item _selectable;

        private readonly ItemFactory _factory;
        
        public ItemComparer(ItemFactory factory)
        {
            _factory = factory;
        }
        
        public void Setup()
        {
            Current = _factory.Create();
            
            Selectable = _factory.Create();
        }
        
        private void Compare(bool greater)
        {
            var succses = false;
            
            if (greater) succses = Current.Price < Selectable.Price;
            
            else succses = Current.Price >= Selectable.Price;

            if (!succses) return;

            var temp = Current;

            Current = Selectable;

            Selectable = _factory.Create();

            _factory.Destroy(temp);
        }
    }
}