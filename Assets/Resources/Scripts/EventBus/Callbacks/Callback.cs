namespace MolecularSurvivors
{
    public class Callback
    {
        public readonly object Signal;

        public Callback(object callback) => Signal = callback;
    }
}