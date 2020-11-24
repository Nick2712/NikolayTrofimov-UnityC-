using UnityEngine;


namespace NikolayTrofimov_Game
{
    public abstract class InteractiveObject : MonoBehaviour, IExecute
    {
        [SerializeField] private bool _isAllowScaling;
        [SerializeField] private float ActiveDis;

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

        private void OnDrawGizmos()
        {
            Gizmos.DrawIcon(transform.position, "001.png", _isAllowScaling);
        }

        private void OnDrawGizmosSelected()
        {
#if UNITY_EDITOR
            Transform t = transform;

            //Gizmos.matrix = Matrix4x4.TRS(t.position, t.rotation, t.localScale);
            //Gizmos.DrawWireCube(Vector3.zero, Vector3.one);

            var flat = new Vector3(ActiveDis, 0, ActiveDis);
            Gizmos.matrix = Matrix4x4.TRS(t.position, t.rotation, flat);
            Gizmos.DrawWireSphere(Vector3.zero, 5);
#endif
        }
    }
}