namespace MagliaDanilo.UnrealDefense.Common
{
    public class Position
    {
        public double X { get; }
        public double Y { get; }

        public Position(double x, double y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Position)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }


        public override string ToString()
        {
            return $"[{X}, {Y}]";
        }

        public Position Copy()
        {
            return new Position(X, Y);
        }
    }
}