using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;

namespace Polymorphic_Inheritance
{
    public class FixedSquare : Shape
    {
        public static int _size { get; private set; } = 20; //Size of Square

        //******************************************************
        //Constructor Method: Take user specified position, color and parent; initialize the class.
        //******************************************************
        public FixedSquare(PointF position, Color color, Shape parent = null)
            : base(position, color, parent) { }

        //******************************************************
        //Render Method: Draw the Shape as a square.
        //******************************************************
        public override void Render(CDrawer drawer)
        {
            //Draw line to parent
            base.Render(drawer);

            drawer?.AddCenteredRectangle((int)_position.X, (int)_position.Y, _size, _size, _color);
        }
    }
}
