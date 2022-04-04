using System.Collections;
using LudumDare50.Controllers;
using UnityEngine;
using UnityEngine.UI;

namespace LudumDare50.Behaviours
{
    [RequireComponent(typeof(Text))]
    public class TimerText : MonoBehaviour
    {
        private Text _text;
        
        private void Awake()
        {
            _text = GetComponent<Text>();
        }

        private void Start()
        {
            StartCoroutine(TextUpdateRoutine());
        }

        private IEnumerator TextUpdateRoutine()
        {
            while (true)
            {
                _text.text = $"<b>Time:</b> {GameController.Instance.TimeElapsed}";
                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}