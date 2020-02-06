using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;

namespace Polymorphic_Inheritance
{
    public abstract class Shape : IRender
    {
        internal PointF _position { get; set;} //Position of the shape
        internal Color _color { get; private set;} //Color of the shape
        internal Shape _parent { get; private set;} //Reference to parent shape

        //******************************************************
        //Constructor Method: Take user specified position, color and parent; initialize the class.
        //******************************************************
        public Shape(PointF position, Color color, Shape parent = null)
        {
            _position = position;
            _color = color;
            _parent = parent;
        }

        //******************************************************
        //Render Method: Draw a line between the instance amd its parent(if EXISTS)
        //******************************************************
        public virtual void Render(CDrawer drawer)
        {
            if(!object.ReferenceEquals(_parent, null))
                drawer?.AddLine((int)_position.X, (int)_position.Y, (int)_parent._position.X, (int)_parent._position.Y, Color.White, 1);
        }
    }
}
