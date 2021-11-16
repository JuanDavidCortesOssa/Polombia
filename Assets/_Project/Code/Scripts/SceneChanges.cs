﻿using UnityEngine;
using UnityEngine.SceneManagement;

namespace Polombia
{
    public class SceneChanges : MonoBehaviour
    {
        public enum Scenes { MainMenu, Win, Lose, MainScene }
        //public Scenes scenes;

        public void GoToMainMenu()
        {
            ChangeScene(Scenes.MainMenu);
        }

        public void GoToLose()
        {
            ChangeScene(Scenes.Lose);
        }

        public void GoToWin()
        {
            ChangeScene(Scenes.Win);
        }

        public void GoToMainScene()
        {
            ChangeScene(Scenes.MainScene);
        }

        public void Quit()
        {
            Application.Quit();
        }

        private void ChangeScene(Scenes scene)
        {
            SceneManager.LoadScene(scene.ToString());
        }
    }
}
