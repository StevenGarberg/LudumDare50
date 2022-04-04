using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.UI.Buttons
{
    [RequireComponent(typeof(Button))]
    public class ResetPositionButton : MonoBehaviour
    {
        private Button _button;
        [SerializeField] private Rigidbody2D _targetRigidbody2D;

        private Vector3 _startPosition;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void Start()
        {
            _startPosition = _targetRigidbody2D.transform.position;
            
            _button.onClick.AddListener(() =>
            {
                _targetRigidbody2D.velocity = Vector2.zero;
                _targetRigidbody2D.transform.position = _startPosition;
            });
        }
    }
}