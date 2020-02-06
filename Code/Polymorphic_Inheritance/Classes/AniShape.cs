using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;

namespace Polymorphic_Inheritance
{
    public abstract class AniShape : Shape, IAnimate
    {
        internal double _sequence { get; private set;} //Radians for movement
        internal double _tickDelta { get; private set;} //Movement speed of sequence

        //******************************************************
        //Constructor Method: Take user specified position, color, parent, sequenceOffSet and sequenceDelta; initialize the class.
        //******************************************************
        public AniShape(PointF position, Color color, double sequence, double tickDelta, Shape parent = null)
            : base(position, color, parent)
        {
            _sequence = sequence;
            _tickDelta = tickDelta;
        }

        //******************************************************
        //Tick Method: Move instance's sequence.
        //******************************************************
        public virtual void Tick()
        {
            _sequence += _tickDelta;
        }
    }
}
