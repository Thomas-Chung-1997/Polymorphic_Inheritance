using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;

namespace Polymorphic_Inheritance
{
    public class AniHighlight : AniChild
    {
        private Point _startPoint { get; set; } //Start of beizer
        private Point _ControlPoint1 { get; set; } //Beizer's first control point
        private Point _ControlPoint2 { get; set; } //Beizer's second control point
        private Point _endPoint { get; set;} //End of beizer

        //******************************************************
        //Constructor Method: Take user specified color, sides, parent, sequenceOffSet and sequenceDelta; initialize the class.
        //******************************************************
        public AniHighlight(Color color, double distance, double tickDelta, Shape parent, double sequence = 0)
            : base(color, distance, tickDelta, parent, sequence) { }

        //******************************************************
        //Render Method: Draw beizer around the parent shape.
        //******************************************************
        public override void Render(CDrawer drawer)
        {
            //Draw line to parent
            base.Render(drawer);

            drawer?.AddBezier(_startPoint.X, _startPoint.Y, _ControlPoint1.X, _ControlPoint1.Y, _ControlPoint2.X, _ControlPoint2.Y, _endPoint.X, _endPoint.Y, Color.White, 1);
        }

        //******************************************************
        //Tick Method: Set new position on shape based on sequence and distance to parent.
        //******************************************************
        public override void Tick()
        {
            base.Tick();

            _startPoint = new Point((int)(_parent._position.X + (_distance * Math.Cos(_sequence))), (int)(_parent._position.Y + (_distance * Math.Sin(_sequence))));

            _ControlPoint1 = new Point((int)(_parent._position.X + ((_distance / 4 * 5) * Math.Cos(_sequence - Math.PI / 6))), (int)(_parent._position.Y + ((_distance / 4 * 5) * Math.Sin(_sequence - Math.PI / 6))));

            _ControlPoint2 = new Point((int)(_parent._position.X + ((_distance / 4 * 5) * Math.Cos(_sequence - Math.PI / 3))), (int)(_parent._position.Y + ((_distance / 4 * 5) * Math.Sin(_sequence - Math.PI / 3))));

            _endPoint = new Point((int)(_parent._position.X + (_distance * Math.Cos(_sequence - Math.PI / 2))), (int)(_parent._position.Y + (_distance * Math.Sin(_sequence - Math.PI / 2))));
        }
    }
}
