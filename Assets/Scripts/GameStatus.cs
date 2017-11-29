using UnityEngine;

namespace Assets.Scripts
{
    public class GameStatus : MonoBehaviour
    {
        public int NumLives = 3;

        public int Score = 0;

        public int PlayerLevel = 1;

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
    }
}
