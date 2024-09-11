using System;
using System.Collections.Generic;

namespace LandGrabInSpace
{
    public struct Coord
    {
        public Coord(ushort x, ushort y)
        {
            X = x;
            Y = y;
        }

        public ushort X { get; }
        public ushort Y { get; }

        public int CalculateSideLength()
        {
            return X * Y;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj is Coord coord)
            {
                return X == coord.X && Y == coord.Y;
            }

            return false;
        }

        public static bool operator ==(Coord obj1, Coord obj2)
        {
            if (ReferenceEquals( obj1, obj2))
                return true;
            if (ReferenceEquals(obj1, null))
                return false;
            if (ReferenceEquals(obj2, null))
                return false;
            return obj1.Equals(obj2);
        }

        public static bool operator !=(Coord obj1, Coord obj2) => !(obj1 == obj2);

        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode();
        }
    }

    public struct Plot
    {
        public Coord Coord1 { get; }
        public Coord Coord2 { get; }
        public Coord Coord3 { get; }
        public Coord Coord4 { get; }

        public Plot(Coord coord1, Coord coord2, Coord coord3, Coord coord4)
        {
            Coord1 = coord1;
            Coord2 = coord2;
            Coord3 = coord3;
            Coord4 = coord4;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj is Plot second)
            {
                return Coord1 == second.Coord1
                    && Coord2 == second.Coord2
                    && Coord3 == second.Coord3
                    && Coord4 == second.Coord4;
            }

            return false;
        }

        //public override bool Equals(object obj) => obj is Plot other && this.Equals(other);
        //public bool Equals(Plot other) => Co1 == other.Co1 && Co2 == other.Co2 && Co3 == other.Co3 && Co4 == other.Co4;

        public int CalculateTotalSideLength()
        {
            return Coord1.CalculateSideLength() + Coord2.CalculateSideLength() + Coord3.CalculateSideLength() + Coord4.CalculateSideLength();
        }

        public override int GetHashCode()
        {
            return Coord1.GetHashCode() ^ Coord2.GetHashCode() ^ Coord3.GetHashCode() ^ Coord4.GetHashCode();
        }
    }


    public class ClaimsHandler
    {
        HashSet<Plot> Stakes = new HashSet<Plot>();
        List<Plot> stakeList = new();
        private Plot lastClaim;
        public void StakeClaim(Plot plot)
        {
            Stakes.Add(plot);
            stakeList.Add(plot);
            lastClaim = plot;
        }

        public bool IsClaimStaked(Plot plot)
        {
            return Stakes.Contains(plot);
        }

        public bool IsLastClaim(Plot plot)
        {
            return plot.Equals(lastClaim);
        }

        public Plot GetClaimWithLongestSide()
        {
            var maxLenght = 0;
            //int count = 1;
            var plotMax = new Plot();
            var lenght = 0;
            foreach (var plot in stakeList)
            {
                lenght = plot.CalculateTotalSideLength();
                if (lenght > maxLenght)
                {
                    maxLenght = lenght;
                    plotMax = plot;
                }

            }
            return plotMax;
        }

        static void Main()
        {
            var ch = new ClaimsHandler();
            var longer = CreatePlot(new Coord(10, 1), new Coord(20, 1), new Coord(10, 2), new Coord(20, 2));
            var shorter = CreatePlot(new Coord(1, 1), new Coord(2, 1), new Coord(1, 2), new Coord(2, 2));
            ch.StakeClaim((Plot)longer);
            ch.StakeClaim((Plot)shorter);
            ch.GetClaimWithLongestSide();
        }

        private static object CreatePlot(Coord coord1, Coord coord2, Coord coord3, Coord coord4)
        {
            return new Plot(coord1, coord2, coord3, coord4);
        }
    }
}
