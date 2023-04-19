namespace MagliaDanilo.UnrealDefense.Common
{
    public class Pair<TOne, TTwo>
    {
        private TOne FirstElement { get; set; }
        private TTwo SecondElement { get; set; }

        public Pair(TOne firstElement, TTwo secondElement)
        {
            FirstElement = firstElement;
            SecondElement = secondElement;
        }

        public Pair<TOne, TTwo> Copy()
        {
            return new Pair<TOne, TTwo>(FirstElement, SecondElement);
        }
    }
}