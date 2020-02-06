using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;

namespace Polymorphic_Inheritance
{
    public abstract class AniBall : AniChild
    {
        internal static int _size { get; private set; } = 20; //Size of ball

        //******************************************************
        //Constructor Method: Take user specified color, sides, parent, sequenceOffSet and sequenceDelta; initialize the class.
        //******************************************************
        public AniBall(Color color, double distance, double tickDelta, Shape parent, double sequence = 0)
            : base(color, distance, tickDelta, parent, sequence) { }

        //******************************************************
        //Render Method: Draw shape as a ball.
        //******************************************************
        public override void Render(CDrawer drawer)
        {
            //Draw line to parent
            base.Render(drawer);

            drawer?.AddCenteredEllipse((int)_position.X, (int)_position.Y, _size, _size, _color);
        }
    }
}
