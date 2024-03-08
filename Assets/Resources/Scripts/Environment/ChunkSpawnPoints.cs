using UnityEngine;

namespace MolecularSurvivors.Environment
{
    public class ChunkSpawnPoints : MonoBehaviour
    {
        [SerializeField] private Transform _right;
        [SerializeField] private Transform _rightUp;
        [SerializeField] private Transform _rightDown;
        [SerializeField] private Transform _left;
        [SerializeField] private Transform _leftUp;
        [SerializeField] private Transform _leftDown;
        [SerializeField] private Transform _up;
        [SerializeField] private Transform _down;

        public Transform Right => _right;

        public Transform RightUp => _rightUp;

        public Transform RightDown => _rightDown;

        public Transform Left => _left;

        public Transform LeftUp => _leftUp;

        public Transform LeftDown => _leftDown;

        public Transform Up => _up;

        public Transform Down => _down;
    }
}
