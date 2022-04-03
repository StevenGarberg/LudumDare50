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
                AudioManager.Instance.Play("Pickup");
                PlayerManager.Instance.Player.AddAir();
                gameObject.SetActive(false);
                // TODO: Tell game to spawn another
            }
        }
    }
}