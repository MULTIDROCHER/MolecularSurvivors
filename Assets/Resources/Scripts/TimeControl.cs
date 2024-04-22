using UnityEngine;

namespace MolecularSurvivors
{
    public class TimeControl
    {
        public void StopTime() => Time.timeScale = 0;

        public void StartTime() => Time.timeScale = 1;
    }
}