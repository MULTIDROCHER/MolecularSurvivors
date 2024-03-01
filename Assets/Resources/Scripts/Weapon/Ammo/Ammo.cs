using UnityEngine;

namespace MolecularSurvivors
{
    [RequireComponent(typeof(Collider2D))]
    public class Ammo : MonoBehaviour
    {
        protected Collider2D Collider;

        protected virtual void Awake()
        {
            Collider = GetComponent<Collider2D>();
        }
    }
}
