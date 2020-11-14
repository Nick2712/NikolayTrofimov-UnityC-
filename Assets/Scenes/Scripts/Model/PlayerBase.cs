using UnityEngine;

namespace NikolayTrofimov_Game
{
    public abstract class PlayerBase : MonoBehaviour
    {
        public float Speed = 3.0f;
        public bool Invulnerability = false;

        public abstract void Move(float x, float y, float z);
    }
}
