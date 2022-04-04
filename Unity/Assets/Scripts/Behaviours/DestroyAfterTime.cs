using UnityEngine;

namespace LudumDare50.Behaviours
{
    public class DestroyAfterTime : MonoBehaviour
    {
        [SerializeField]
        private float _secondsUntilDestroy = 1.0f;

        private void Start()
        {
            Destroy(gameObject, _secondsUntilDestroy);
        }
    }
}