using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using GDIDrawer;

namespace Polymorphic_Inheritance
{
    public enum FungusColor { red, green, blue, yellow, pink, teal, black, white}; //Enumeration for Fungus Colors

    public class Fungus
    {
        private static Random _random { get; set; } = new Random(); //Random Number Generator
        private Dictionary<Point, int> _grid { get; set;} //Counter for all places visited by fungus
        private Point _cPoint { get; set;} //Current head of fungus
        private FungusColor _color { get; set;} //Color of fungus
        private Thread _thread { get; set;} //Thread for Fungus
        private CDrawer _drawer { get; set;} //Drawer

        //******************************************************
        //Constructor Method: Take user specified position, drawer, and color; initialize the class.
        //******************************************************
        public Fungus(Point start, CDrawer drawer, FungusColor color)
        {
            _grid = new Dictionary<Point, int>(); 
            _cPoint = start;
            _drawer = drawer;
            _color = color;
            Thread nThread = new Thread(ThreadMethod);

            //Set Thread in background and start
            _thread = nThread;
            _thread.IsBackground = true;
            _thread.Start();
        }

        //******************************************************
        //Thread Method: Move Fungus at set CPU saturation.
        //******************************************************
        private void ThreadMethod()
        {
            while (true)
            {
                MovePoint(Shuffle(GetAdjacent()));

                Thread.Sleep(0);
            }
        }

        //******************************************************
        //Get Adjacent Method: Return a list of all potential points of movement for current point of fungus.
        //******************************************************
        private List<Point> GetAdjacent()
        {
            List<Point> adjacent = new List<Point>(); //List of adjacent points

            //Get all 8 adjacent points to current point
            for(int y = _cPoint.Y - 1; y <= _cPoint.Y + 1; ++y)
            {
                for (int x = _cPoint.X - 1; x <= _cPoint.X + 1; ++x)
                {
                    Point nPoint = new Point(x, y);

                    if(!_cPoint.Equals(nPoint))
                    {
                        adjacent.Add(nPoint);
                    }
                }
            }

            //Delete points that are out of bounds
            adjacent = adjacent.Where(p => p.X > 0 && p.X < _drawer.m_ciWidth && p.Y > 0 && p.Y < _drawer.m_ciHeight).ToList();

            return adjacent;
        }

        //******************************************************
        //Shuffle Method: return a list of shuffle adjacent points
        //******************************************************
        private List<Point> Shuffle(List<Point> adjacent)
        {
            List<Point> shuffle = new List<Point>(); //Shuffled points
            int count = adjacent.Count; //Count of adjacent points to start

            for(int x = 0; x < count; ++x)
            {
                int spot = 0; //Current selected point

                //Select random point in list
                lock (_random)
                    spot = _random.Next(0, adjacent.Count);

                //Add select point into new list
                shuffle.Add(adjacent[spot]);

                //Make the random point into the last point in the adjacent list
                adjacent[spot] = adjacent.Last();

                //Remove last point of adjacent list
                adjacent.RemoveAt(adjacent.Count - 1);
            }

            return shuffle;
        }

        //******************************************************
        //Move Point Method: Take shuffled list of points, select the last visited point and move current point.
        //******************************************************
        private void MovePoint(List<Point> shuffle)
        {
            //Turn shuffle list into list of keyVaulePair
            List<KeyValuePair<Point, int>> nList = shuffle.ToDictionary(s => s, s => _grid.ContainsKey(s) ? _grid[s] : 0).ToList();

            //Sort list by value ascending
            nList.Sort((a, b) => a.Value - b.Value);

            //Get least visited point
            _cPoint = nList[0].Key;

            //If point was has visited
            if (_grid.ContainsKey(_cPoint))
            {
                _grid[_cPoint] += 16;

                if (_grid[_cPoint] > 255)
                    _grid[_cPoint] = 255;
            }
            //If point has not been visited
            else
            {
                _grid.Add(_cPoint, 32);
            }

            Color cColor = Color.FromArgb(0, 0, 0); //Color of current point

            //Set color depending on user preference
            switch (_color)
            {
                case FungusColor.red:
                    cColor = Color.FromArgb(_grid[_cPoint], 0, 0);
                    break;
                case FungusColor.green:
                    cColor = Color.FromArgb(0, _grid[_cPoint], 0);
                    break;
                case FungusColor.blue:
                    cColor = Color.FromArgb(0, 0, _grid[_cPoint]);
                    break;
                case FungusColor.pink:
                    cColor = Color.FromArgb(_grid[_cPoint], 0, _grid[_cPoint]);
                    break;
                case FungusColor.teal:
                    cColor = Color.FromArgb(0, _grid[_cPoint], _grid[_cPoint]);
                    break;
                case FungusColor.yellow:
                    cColor = Color.FromArgb(_grid[_cPoint], _grid[_cPoint], 0);
                    break;
                case FungusColor.white:
                    cColor = Color.FromArgb(_grid[_cPoint], _grid[_cPoint], _grid[_cPoint]);
                    break;
                case FungusColor.black:
                    cColor = Color.FromArgb(0, 0, 0);
                    break;
            }

            //Draw point onto drawer
            lock(_drawer)
                _drawer.SetBBPixel(_cPoint.X, _cPoint.Y, cColor);
        }
    }
}
