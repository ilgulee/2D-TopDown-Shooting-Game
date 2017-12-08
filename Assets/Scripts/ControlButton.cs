using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class ControlButton : MonoBehaviour
    {
        public void StartLevel1()
        {
            SceneManager.LoadScene("Level1");
        }

        public void LoadSplashScreen()
        {
            //to reset GameStatus 
            ResetGameStatus();
            SceneManager.LoadScene("TitlePage");
        }

        private void ResetGameStatus()
        {
            GameStatus.GetInstance().NumLives = 3;
            GameStatus.GetInstance().PlayerLevel = 0;
            GameStatus.GetInstance().Score = 0;
        }
    }
}
