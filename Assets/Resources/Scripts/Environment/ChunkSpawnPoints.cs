using UnityEngine;

namespace MolecularSurvivors.Environment
{
    public class ChunkSpawnPoints : MonoBehaviour
    {
        [field: SerializeField] public Transform Right { get; private set; }

        [field: SerializeField] public Transform RightUp { get; private set; }

        [field: SerializeField] public Transform RightDown { get; private set; }

        [field: SerializeField] public Transform Left { get; private set; }

        [field: SerializeField] public Transform LeftUp { get; private set; }

        [field: SerializeField] public Transform LeftDown { get; private set; }

        [field: SerializeField] public Transform Up { get; private set; }

        [field: SerializeField] public Transform Down { get; private set; }
    }
}
