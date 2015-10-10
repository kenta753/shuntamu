﻿using System.Collections.Generic;
using System.Drawing;

namespace shuntamu.View
{
    /// <summary>
    /// Map の 抽象クラス
    /// このクラスを継承して Map を生成する
    /// </summary>
    abstract class MapBase : IDrawable
    {
        protected MapBase(Size size)
        {
            _elements = new DrawHub(new Point(0, 0), size);
        }

        private readonly DrawHub _elements;

        public List<MapElementBase> Elements
        {
            get { return _elements.ConvertAll(input => (MapElementBase)input); } 
        }

        public void AddElement(MapElementBase element)
        {
            _elements.Add(element);
        }

        public void Draw(Point zeropoint)
        {
            _elements.Draw(zeropoint);
        }

        public void Update()
        {
            foreach (var variable in _elements)
            {
                if(variable is MotionObject) ((MotionObject)variable).Update(this);
            }
        }

        public Point Point
        {
            get { return _elements.Point; }
            set { _elements.Point = value; }
        }

        public Size Size
        {
            get { return _elements.Size; }
            set { _elements.Size = value; }
        }
    }
}
