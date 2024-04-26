namespace MolecularSurvivors
{
    public class Callback
    {
        //public readonly int Priority;
        public readonly object Signal;

        public Callback( /* int priority, */  object callback)
        {
            //Priority = priority;
            Signal = callback;
        }
    }
}