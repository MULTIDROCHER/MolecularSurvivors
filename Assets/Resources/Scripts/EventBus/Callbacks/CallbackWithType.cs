namespace MolecularSurvivors
{
    public class CallbackWithType : Callback
    {
        public readonly CountableType Type;

        public CallbackWithType(object callback, CountableType type)
        : base(callback)
        {
            Type = type;
        }
    }
}