using UnityEngine;


namespace NikolayTrofimov_Game
{
    public abstract class InteractiveObject : MonoBehaviour, IExecute
    {
        protected Color _color;

        private bool _isInteractable;

        public bool IsInteractable
        {
            get { return _isInteractable; }
            private set
            {
                _isInteractable = value;
                GetComponent<Renderer>().enabled = _isInteractable;
                GetComponent<Collider>().enabled = _isInteractable;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!IsInteractable || !other.CompareTag("Player"))
            {
                return;
            }
            Interaction();
            IsInteractable = false;
            gameObject.SetActive(false);
        }

        protected abstract void Interaction();
        public abstract void Execute(float timeDeltatime);

        private void Start()
        {
            IsInteractable = true;
            //_color = ColorHSV();
            if (TryGetComponent(out Renderer renderer))
            {
                //renderer.material.color = _color;
                _color = renderer.material.color;
            }
            else
            {
                _color = Color.white;
            }
        }
    }
}