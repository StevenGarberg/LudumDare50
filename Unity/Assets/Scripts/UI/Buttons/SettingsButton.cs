using System;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.UI.Buttons
{
    [RequireComponent(typeof(Button))]
    public class SettingsButton : MonoBehaviour
    {
        private void Start()
        {
            GetComponent<Button>().onClick.AddListener(() =>
            {
                throw new NotImplementedException();
            });
        }
    }
}