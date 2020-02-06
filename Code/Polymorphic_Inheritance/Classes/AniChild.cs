using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;

namespace Polymorphic_Inheritance
{
    public abstract class AniChild : AniShape
    {
        internal double _distance { get; private set;}

        //******************************************************
        //Constructor Method: Take user specified color, distance, parent, sequenceOffSet and sequenceDelta; initialize the class.
        //******************************************************
        public AniChild(Color color, double distance, double tickDelta, Shape parent, double sequence = 0)
            : base(parent._position, color, sequence, tickDelta,parent)
        {
            //If parent doesn't exist
            if (object.ReferenceEquals(parent, null))
                throw new ArgumentException("Parent Animated Shape can not be null");

            _distance = distance;
        }
    }
}
