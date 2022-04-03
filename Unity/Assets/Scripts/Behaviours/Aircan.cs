using LudumDare50.Unity.Managers;
using UnityEngine;

namespace LudumDare50.Behaviours
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class Aircan : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                // TODO: Play sound
                PlayerManager.Instance.Player.AddAir();
                Destroy(gameObject);
                // TODO: Tell game to spawn another
            }
        }
    }
}