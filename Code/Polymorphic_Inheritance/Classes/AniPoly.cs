using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;

namespace Polymorphic_Inheritance
{
    public class AniPoly : AniShape
    {
        private static int _size { get; set; } = 25; //Size of polygon
        internal int _sides { get; private set; } //Amount of sides on polygon

        //******************************************************
        //Constructor Method: Take user specified position, color, sides,parent, sequenceOffSet and sequenceDelta; initialize the class.
        //******************************************************
        public AniPoly(PointF position, Color color, double tickDelta, int sides, Shape parent = null, double sequence = 0)
            : base(position, color, sequence, tickDelta, parent)
        {
            //If polygon has less than 3 sides
            if (sides < 3)
                throw new ArgumentException("AniPoly object created has less than 3 sides");

            _sides = sides;
        }

        //******************************************************
        //Render Method: Draw the shape as a Polygon
        //******************************************************
        public override void Render(CDrawer drawer)
        {
            //Draw line to parent
            base.Render(drawer);

            drawer.AddPolygon((int)_position.X, (int)_position.Y, _size, _sides, _sequence, _color);
        }
    }
}
