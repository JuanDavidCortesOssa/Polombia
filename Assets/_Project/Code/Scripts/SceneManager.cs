﻿using UnityEngine;
using UnityEngine.SceneManagement;

namespace Polombia
{
    public class SceneManager : Singleton<SceneManager>
    {
        public enum Scenes { MainMenu, Win, Lose, MainScene, Wi2 }
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

        public void GoToWin2()
        {
            ChangeScene(Scenes.Wi2);
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
            UnityEngine.SceneManagement.SceneManager.LoadScene(scene.ToString());
        }
    }
}
