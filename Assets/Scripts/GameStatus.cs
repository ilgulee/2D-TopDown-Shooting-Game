using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class GameStatus : MonoBehaviour
    {
        public int NumLives = 3;

        public int Score = 0;

        public int PlayerLevel = 1;

        public int StageLevel = 1;

        private static GameStatus _instance;

        public static GameStatus GetInstance()
        {
            return _instance;
        }
        // Use this for initialization
        void Start()
        {
            if (_instance != null)
            {
                Destroy(this.gameObject);
                return;
            }
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        private void Update()
        {
            // Change Stage when reach to certain score.
            if (GameStatus.GetInstance().Score >= 100 && GameStatus.GetInstance().StageLevel == 1)
            {
                SceneManager.LoadScene("Level2");
                GameStatus.GetInstance().StageLevel = 2;
            }
        }
    }
}
