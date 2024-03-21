namespace MolecularSurvivors
{
    public static class PercentConverter
    {
        private static readonly int _percentValue = 100;

        public static float GetValueByPercent(float maxValue, float percent)
        {
            return maxValue * percent / _percentValue;
        }

        public static int GetValueByPercent(int maxValue, int percent)
        {
            return maxValue * percent / _percentValue;
        }
    }
}
