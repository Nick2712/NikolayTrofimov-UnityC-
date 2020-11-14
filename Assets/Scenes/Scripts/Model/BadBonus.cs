using UnityEngine;
using static UnityEngine.Random;


namespace NikolayTrofimov_Game
{
    public sealed class BadBonus : InteractiveObject, IFly, IRotation
    {
        private EffectManager _effectManager;
        private float _lengthFlay;
        private float _speedRotation;

        private void Awake()
        {
            _lengthFlay = Range(1.0f, 5.0f);
            _speedRotation = Range(10.0f, 50.0f);
        }

        public void SetEffectManager(EffectManager effectManager)
        {
            _effectManager = effectManager;
        }

        protected override void Interaction()
        {
            //OnCaughtPlayerChange.Invoke(gameObject.name, _color);
            _effectManager.BadEffecting(name, GetComponent<Renderer>().material.color);
        }

        public override void Execute(float timeDeltatime)
        {
            if (!IsInteractable) { return; }
            Fly();
            Rotation();
        }

        public void Fly()
        {
            transform.localPosition = new Vector3(transform.localPosition.x,
                Mathf.PingPong(Time.time, _lengthFlay),
                transform.localPosition.z);
        }

        public void Rotation()
        {
            transform.Rotate(Vector3.up * (Time.deltaTime * _speedRotation), Space.World);
        }
    }
}