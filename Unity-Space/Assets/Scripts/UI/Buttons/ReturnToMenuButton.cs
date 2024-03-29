﻿using LudumDare50.Controllers;
using LudumDare50.Unity.Managers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace DefaultNamespace.UI.Buttons
{
    [RequireComponent(typeof(Button))]
    public class ReturnToMenuButton : MonoBehaviour
    {
        private void Start()
        {
            GetComponent<Button>().onClick.AddListener(() =>
            {
                Time.timeScale = 1;
                
                AudioManager.Instance.Play("select");
                GameController.Instance.Quit();
                
                Invoke(nameof(LoadMenu), 0.25f);

            });
        }

        private void LoadMenu()
        {
            SceneManager.LoadScene("Menu");
        }
    }
}