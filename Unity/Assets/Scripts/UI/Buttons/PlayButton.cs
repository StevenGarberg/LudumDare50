﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace DefaultNamespace.UI.Buttons
{
    [RequireComponent(typeof(Button))]
    public class PlayButton : MonoBehaviour
    {
        private void Start()
        {
            GetComponent<Button>().onClick.AddListener(() =>
            {
                SceneManager.LoadScene("Minigame");
            });
        }
    }
}