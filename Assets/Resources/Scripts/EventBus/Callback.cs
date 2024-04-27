namespace MolecularSurvivors
{
    public class Callback
    {
        public readonly object Signal;

        public Callback(object callback) => Signal = callback;
    }

    public class CallbackWithType : Callback
    {
        public readonly CountableType Type;

        public CallbackWithType(object callback, CountableType type)
        : base(callback)
        {
            Type = type;
        }
    }

    public enum CountableType
    {
        Level,
        Kills,
        Gold,
    }
}