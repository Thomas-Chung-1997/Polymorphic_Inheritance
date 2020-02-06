using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GDIDrawer;

namespace Polymorphic_Inheritance
{
    public partial class MainForm : Form
    {
        private CDrawer _drawer = new CDrawer(1000, 1000); //Drawer
        List<Fungus> _fungii = new List<Fungus>(); //List of Fungii
        List<Shape> _shapes = new List<Shape>(); //List of Shapes

        public MainForm()
        {
            InitializeComponent();

            //Fixed Squares
            {
                _shapes.Add(new FixedSquare(new PointF(450, 500), Color.Red, null));
                _shapes.Add(new FixedSquare(new PointF(550, 500), Color.Red, _shapes[0]));
            }

            //CCW OrbitalBall Chain
            {
                List<Shape> local = new List<Shape>();
                local.Add(new OrbitalBall(Color.Yellow, 50, -0.1, _shapes[0]));
                local.Add(new OrbitalBall(Color.Pink, 50, -0.15, local[0]));
                local.Add(new OrbitalBall(Color.Blue, 50, -0.2, local[1]));
                local.Add(new OrbitalBall(Color.Green, 50, -0.25, local[2]));
                _shapes.AddRange(local);
            }

            //CW OrbitalBall Chain
            {
                List<Shape> local = new List<Shape>();
                local.Add(new OrbitalBall(Color.Yellow, 50, 0.05, _shapes[1]));
                local.Add(new OrbitalBall(Color.Pink, 50, 0.075, local[0]));
                local.Add(new OrbitalBall(Color.Blue, 50, 0.1, local[1]));
                local.Add(new OrbitalBall(Color.Green, 50, 0.125, local[2]));
                _shapes.AddRange(local);
            }

            //Orbital Ball, HorizontalWobbleBall, VeritcalWobbleBall Chain
            {
                List<Shape> local = new List<Shape>();
                local.Add(new FixedSquare(new PointF(200, 500), Color.Cyan, null));
                local.Add(new VerticalWobbleBall(Color.Red, 100, 0.1, local[0]));
                local.Add(new HorizontalWobbleBall(Color.Red, 100, 0.15, local[1]));
                local.Add(new OrbitalBall(Color.LightBlue, 25, 0.2, local[2]));
                _shapes.AddRange(local);
            }

            //VerticalWobbleBall on Fixed Square
            {
                List<Shape> localA = new List<Shape>();
                List<Shape> localB = new List<Shape>();
                for (int i = 50; i < 1000; i += 50)
                    localA.Add(new FixedSquare(new PointF(i, 100), Color.Cyan, null));
                _shapes.AddRange(localA);

                double so = 50;
                foreach (Shape s in localA)
                {
                    localB.Add(new VerticalWobbleBall(Color.Purple, 50, 0.1, s, so));
                    so += 0.7;
                }
                _shapes.AddRange(localB);
            }

            //3-Tier cloud of quad balls orbiting FixedSquare
            {
                List<Shape> local = new List<Shape>();
                local.Add(new FixedSquare(new PointF(800, 500), Color.GreenYellow, null));
                local.Add(new OrbitalBall(Color.Yellow, 30, 0.1, local[0]));
                local.Add(new OrbitalBall(Color.Yellow, 30, 0.1, local[0], Math.PI / 2));
                local.Add(new OrbitalBall(Color.Yellow, 30, 0.1, local[0], Math.PI));
                local.Add(new OrbitalBall(Color.Yellow, 30, 0.1, local[0], Math.PI / 2 * 3));
                local.Add(new OrbitalBall(Color.Yellow, 60, -0.05, local[0]));
                local.Add(new OrbitalBall(Color.Yellow, 60, -0.05, local[0], Math.PI / 2));
                local.Add(new OrbitalBall(Color.Yellow, 60, -0.05, local[0], Math.PI));
                local.Add(new OrbitalBall(Color.Yellow, 60, -0.05, local[0], Math.PI / 2 * 3));
                local.Add(new OrbitalBall(Color.Yellow, 90, 0.025, local[0]));
                local.Add(new OrbitalBall(Color.Yellow, 90, 0.025, local[0], Math.PI / 2));
                local.Add(new OrbitalBall(Color.Yellow, 90, 0.025, local[0], Math.PI));
                local.Add(new OrbitalBall(Color.Yellow, 90, 0.025, local[0], Math.PI / 2 * 3));
                _shapes.AddRange(local);
            }

            //AniPoly
            {
                _shapes.Add(new AniPoly(new PointF(100, 300), Color.Tomato, 0.1, 3, null));
                _shapes.Add(new AniPoly(new PointF(135, 300), Color.Tomato, -0.1, 3, null, 1));
                _shapes.Add(new AniPoly(new PointF(170, 300), Color.Tomato, 0.1, 3, null));
            }

            //HorizontalWobbleBalls chain
            {
                List<Shape> local = new List<Shape>();
                local.Add(new FixedSquare(new PointF(500, 200), Color.Wheat, null));
                for (int i = 1; i < 20; ++i)
                    local.Add(new HorizontalWobbleBall(Color.Orange, 25, 0.1, local[i - 1]));
                _shapes.AddRange(local);
            }

            //Highlight on a fixed square
            {
                List<Shape> local = new List<Shape>();
                local.Add(new FixedSquare(new PointF(800, 300), Color.LightCoral, null));
                local.Add(new AniHighlight(Color.Yellow, 30, -0.2, local[0]));
                _shapes.AddRange(local);
            }

            //Fungus
            {
                _fungii.Add(new Fungus(new Point(500, 500), _drawer, FungusColor.red));
                _fungii.Add(new Fungus(new Point(500, 500), _drawer, FungusColor.green));
                _fungii.Add(new Fungus(new Point(500, 500), _drawer, FungusColor.blue));
            }
        }

        //******************************************************
        //Timer Tick Event: Tick and re-render all shapes onto drawer.
        //******************************************************
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            //Clear drawer
            _drawer.Clear();

            //Tick
            _shapes.ForEach(s =>
            {
                if (s is IAnimate AniS)
                    AniS.Tick();
            });

            //Render
            _shapes.ForEach(s => s.Render(_drawer));
            _drawer.Render();
        }
    }
}
