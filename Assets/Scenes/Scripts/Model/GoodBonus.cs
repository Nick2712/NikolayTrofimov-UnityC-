﻿using UnityEngine;
using static UnityEngine.Random;


namespace NikolayTrofimov_Game
{
    public sealed class GoodBonus : InteractiveObject, IFly, IFlicker
    {
        public int Point;
        //public event Action<int> OnPointChange = delegate (int i) { };

        private EffectManager _effectManager;
        private Material _material;
        private float _lengthFly;

        private void Awake()
        {
            _material = GetComponent<Renderer>().material;
            _lengthFly = Range(1.0f, 5.0f);
        }

        public void SetEffectManager(EffectManager effectManager)
        {
            _effectManager = effectManager;
        }

        protected override void Interaction()
        {
            _effectManager.GoodEffecting();
            //OnPointChange.Invoke(Point);
        }

        public override void Execute(float timeDeltatime)
        {
            if (!IsInteractable) { return; }
            Fly();
            Flicker();
        }

        public void Fly()
        {
            transform.localPosition = new Vector3(transform.localPosition.x,
                Mathf.PingPong(Time.time, _lengthFly),
                transform.localPosition.z);
        }

        public void Flicker()
        {
            _material.color = new Color(_material.color.r, _material.color.g, _material.color.b,
                Mathf.PingPong(Time.time, 1.0f));
        }
    }
}