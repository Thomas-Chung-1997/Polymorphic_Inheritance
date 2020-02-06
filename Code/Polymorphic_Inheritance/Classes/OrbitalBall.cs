﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;

namespace Polymorphic_Inheritance
{
    public class OrbitalBall : AniBall
    {
        //******************************************************
        //Constructor Method: Take user specified color, sides, parent, sequenceOffSet and sequenceDelta; initialize the class.
        //******************************************************
        public OrbitalBall(Color color, double distance, double tickDelta, Shape parent, double sequence = 0)
            : base(color, distance, tickDelta, parent, sequence) { }

        //******************************************************
        //Tick Method: Set new position on shape based on sequence and distance to parent.
        //******************************************************
        public override void Tick()
        {
            base.Tick();

            _position = new PointF((float)(_parent._position.X + (_distance * Math.Cos(_sequence))), (float)(_parent._position.Y + (_distance * Math.Sin(_sequence))));
        }
    }
}
