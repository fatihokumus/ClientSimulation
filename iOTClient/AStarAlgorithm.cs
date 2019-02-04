using System;
using System.Collections.Generic;
using System.Collections;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iOTClient
{
    public class AStarAlgorithm
    {
        public class matrixNode
        {
            public int fr = 0, to = 0, sum = 0;
            public int x, y;
            public matrixNode parent;
        }

        public static matrixNode AStar(char[][] matrix, int fromX, int fromY, int toX, int toY)
        {
            Dictionary<string, matrixNode> greens = new Dictionary<string, matrixNode>(); //open 
            Dictionary<string, matrixNode> reds = new Dictionary<string, matrixNode>(); //closed 

            matrixNode startNode = new matrixNode { x = fromX, y = fromY };
            string key = startNode.x.ToString() + startNode.x.ToString();
            greens.Add(key, startNode);

            Func<KeyValuePair<string, matrixNode>> smallestGreen = () =>
            {
                KeyValuePair<string, matrixNode> smallest = greens.ElementAt(0);

                foreach (KeyValuePair<string, matrixNode> item in greens)
                {
                    if (item.Value.sum < smallest.Value.sum)
                        smallest = item;
                    else if (item.Value.sum == smallest.Value.sum
                            && item.Value.to < smallest.Value.to)
                        smallest = item;
                }

                return smallest;
            };


            List<KeyValuePair<int, int>> fourNeighbors = new List<KeyValuePair<int, int>>()
                                            { new KeyValuePair<int, int>(-1,0),
                                              new KeyValuePair<int, int>(0,1),
                                              new KeyValuePair<int, int>(1, 0),
                                              new KeyValuePair<int, int>(0,-1) };

            int maxX = matrix.GetLength(0);
            if (maxX == 0)
                return null;
            int maxY = matrix[0].Length;

            while (true)
            {
                if (greens.Count == 0)
                    return null;

                KeyValuePair<string, matrixNode> current = smallestGreen();
                if (current.Value.x == toX && current.Value.y == toY)
                    return current.Value;

                greens.Remove(current.Key);
                reds.Add(current.Key, current.Value);

                foreach (KeyValuePair<int, int> plusXY in fourNeighbors)
                {
                    int nbrX = current.Value.x + plusXY.Key;
                    int nbrY = current.Value.y + plusXY.Value;
                    string nbrKey = nbrX.ToString() + nbrY.ToString();
                    if (nbrX < 0 || nbrY < 0 || nbrX >= maxX || nbrY >= maxY
                        || matrix[nbrX][nbrY] == 'X' //obstacles marked by 'X'
                        || reds.ContainsKey(nbrKey))
                        continue;

                    if (greens.ContainsKey(nbrKey))
                    {
                        matrixNode curNbr = greens[nbrKey];
                        int from = Math.Abs(nbrX - fromX) + Math.Abs(nbrY - fromY);
                        if (from < curNbr.fr)
                        {
                            curNbr.fr = from;
                            curNbr.sum = curNbr.fr + curNbr.to;
                            curNbr.parent = current.Value;
                        }
                    }
                    else
                    {
                        matrixNode curNbr = new matrixNode { x = nbrX, y = nbrY };
                        curNbr.fr = Math.Abs(nbrX - fromX) + Math.Abs(nbrY - fromY);
                        curNbr.to = Math.Abs(nbrX - toX) + Math.Abs(nbrY - toY);
                        curNbr.sum = curNbr.fr + curNbr.to;
                        curNbr.parent = current.Value;
                        greens.Add(nbrKey, curNbr);
                    }
                }
            }
        }

        private static Point EndPoint;

        private static Point StartPoint;
        

        public static Path FindPath(char[][] matrix, Point startPoint, Point endPoint)
        {
            try
            {
                if (Collides(matrix, startPoint) || Collides(matrix, endPoint))
                {
                    return null;
                }

                StartPoint = startPoint;
                EndPoint = endPoint;

                // initialize the open set of nodes with start point
                C5.IPriorityQueue<State> openSet = new C5.IntervalHeap<State>();

                // associate handles with points
                var handles = new Dictionary<Point, C5.IPriorityQueueHandle<State>>();

                // add start point to queue and associate point with handle
                C5.IPriorityQueueHandle<State> handle = null;
                openSet.Add(ref handle, new State { Point = startPoint, Heuristic = 0 });
                handles.Add(StartPoint, handle);

                var closedSet = new HashSet<Point>();

                // the g-score is the distance from start point to the current point
                var gScore = new Dictionary<Point, double> { { startPoint, 0 } };

                // the f-score is the g-score plus heuristic
                var fScore = new Dictionary<Point, double> { { startPoint, Utils.Distance(startPoint, EndPoint) } };

                // cameFrom is used to reconstruct path when target is found
                var cameFrom = new Dictionary<Point, Point>();

                // process nodes in the open set...
                
                while (!openSet.IsEmpty)
                {
                  
                    // fetch highest priority node, i.e. the one with
                    // lowest heuristic value
                    State minState = openSet.DeleteMin();
                    Point x = minState.Point;
                    handles.Remove(x);

                    if (x == EndPoint)
                    {
                        // we found a solution
                        return ReconstructPath(cameFrom);
                    }

                    closedSet.Add(x);
                    if (x.X >= 0 && x.Y >= 0)
                    {
                        var neighbours = GetNeighbours(matrix, x);

                        // for each neighbour...
                        foreach (var y in neighbours)
                        {
                           
                            if (closedSet.Contains(y))
                            {
                                continue;
                            }

                            // total cost from start
                            var tentativeGScore = gScore[x] + Utils.Distance(x, y);

                            bool tentativeIsBetter;
                            handle = null;
                            if (!openSet.Exists(s => s.Point == y) && !closedSet.Contains(y))
                            {
                                // will get priority adjusted further down
                                openSet.Add(ref handle, new State { Point = y });
                                handles.Add(y, handle);
                                tentativeIsBetter = true;
                            }
                            else if (tentativeGScore < gScore[y])
                            {
                                tentativeIsBetter = true;
                            }
                            else
                            {
                                tentativeIsBetter = false;
                            }

                            if (tentativeIsBetter)
                            {
                                // update f-score of y
                                cameFrom[y] = x;
                                gScore[y] = tentativeGScore;
                                fScore[y] = gScore[y] + Utils.Distance(y, EndPoint);
                                var heuristic = fScore[y];

                                // set priority of y
                                if (handle == null)
                                {
                                    handle = handles[y];
                                }

                                openSet.Replace(handle, new State { Heuristic = heuristic, Point = y });
                            }
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException == null ? ex.Message : ex.InnerException.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }

        private static Path ReconstructPath(IDictionary<Point, Point> cameFrom)
        {
            var points = new Stack<Point>();
            points.Push(EndPoint);
            Point p = cameFrom[EndPoint];
            while (p != StartPoint)
            {
                points.Push(p);
                p = cameFrom[p];
            }

            points.Push(StartPoint);
            return new Path(points.ToArray());
        }
        private static List<Point> GetNeighbours(char[][] matrix, Point point)
        {
            var points = new List<Point>(8);
            foreach (var size in Constants.Directions)
            {
                var pt = Point.Add(point, size);

                if (pt.X >= 0 && pt.Y >= 0)
                {
                    bool collides = Collides(matrix, pt);
                    if (!collides)
                    {
                        points.Add(pt);
                    }
                }

            }

            return points;
        }

        private static bool Collides(char[][] matrix, Point point)
        {
            foreach (var size in Constants.Directions)
            {
                var pt = Point.Add(point, size);

                //var c = this.Surface.GetPixel(pt.X, pt.Y);
                if (pt.X < matrix.Length && pt.Y < matrix[0].Length && pt.X >= 0 && pt.Y >= 0)
                {
                    if (matrix[pt.X][pt.Y] == 'X')
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }

    public class Path : IEnumerable<Point>
    {
        /// <summary>
        /// The list of points that make up the path.
        /// </summary>
        public readonly List<Point> Points = new List<Point>();

        /// <summary>
        /// Initializes a new instance of the Path class.
        /// </summary>
        /// <param name="points">Points used to construct path</param>
        public Path(IEnumerable<Point> points)
        {
            this.Points.AddRange(points);
        }

        /// <summary>
        /// Gets the number of points in path.
        /// </summary>
        public int Count
        {
            get
            {
                return this.Points.Count;
            }
        }

        /// <summary>
        /// Add a point to the path.
        /// </summary>
        /// <param name="point">Point to add</param>
        public void Add(Point point)
        {
            this.Points.Add(point);
        }

        /// <summary>
        /// Get enumerator.
        /// </summary>
        /// <returns>Point enumerator</returns>
        public IEnumerator<Point> GetEnumerator()
        {
            return this.Points.GetEnumerator();
        }

        /// <summary>
        /// Get enumerator.
        /// </summary>
        /// <returns>Point enumerator</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.Points.GetEnumerator();
        }
    }

    public static class Constants
    {
        /// <summary>
        /// East direction.
        /// </summary>
        public static readonly Size E = new Size(1, 0);

        /// <summary>
        /// North direction.
        /// </summary>
        public static readonly Size N = new Size(0, -1);

        /// <summary>
        /// Northeast direction.
        /// </summary>
        public static readonly Size NE = new Size(1, -1);

        /// <summary>
        /// Northwest direction.
        /// </summary>
        public static readonly Size NW = new Size(-1, -1);

        /// <summary>
        /// South direction.
        /// </summary>
        public static readonly Size S = new Size(0, 1);

        /// <summary>
        /// Southeast direction.
        /// </summary>
        public static readonly Size SE = new Size(1, 1);

        /// <summary>
        /// Southwest direction.
        /// </summary>
        public static readonly Size SW = new Size(-1, 1);

        /// <summary>
        /// West direction.
        /// </summary>
        public static readonly Size W = new Size(-1, 0);

        /// <summary>
        /// All directions.
        /// </summary>
        public static readonly Size[] Directions = new Size[8] { NW, N, NE, E, SE, S, SW, W };
    }

    public class State : IComparable<State>
    {
        /// <summary>
        /// Gets or sets the heuristic value.
        /// </summary>
        public double Heuristic
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the point.
        /// </summary>
        public Point Point
        {
            get;
            set;
        }

        /// <summary>
        /// Compare by heuristic value.
        /// </summary>
        /// <param name="other">Other state</param>
        /// <returns>If first heuristic is smaller than second, -1. If equal, 0, otherwise 1</returns>
        public int CompareTo(State other)
        {
            return this.Heuristic.CompareTo(other.Heuristic);
        }

        /// <summary>
        /// Get hash code. Uses the point to generate hash code.
        /// </summary>
        /// <returns>State hash code</returns>
        public override int GetHashCode()
        {
            return this.Point.GetHashCode();
        }
    }
    public static class Utils
    {
        /// <summary>
        /// Calculates the distance between two points.
        /// </summary>
        /// <param name="p1">First point</param>
        /// <param name="p2">Second points</param>
        /// <returns>Distance between p1 and p2, rounded down to integer</returns>
        public static double Distance(Point p1, Point p2)
        {
            var offset = (Size)p1 - (Size)p2;
            var distanceSquared = (offset.Height * offset.Height) + (offset.Width * offset.Width);
            return Math.Sqrt(distanceSquared);
        }
    }
}
