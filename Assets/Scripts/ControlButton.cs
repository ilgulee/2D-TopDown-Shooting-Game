using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
	public class ControlButton : MonoBehaviour {

		// Use this for initialization
		void Start () {
		
		}
	
		// Update is called once per frame
		void Update () {
		
		}

		public void StartLevel1()
		{
			SceneManager.LoadScene("Level1");
		}

		public void LoadSplashScreen()
		{
		    //to reset GameStatus 
		    ResetGameStatus();
		    SceneManager.LoadScene("SplashScreen");
		}

	    private void ResetGameStatus()
	    {
	        GameObject gameObject = GameObject.Find("GameStatus");
	        if (gameObject == null)
	        {
	            Debug.LogError("Failed to find an object named GameStatus");
	            this.enabled = false;
	            return;
	        }
	        //It's the GameStatus script
	        GameStatus gameStatus = gameObject.GetComponent<GameStatus>();
	        gameStatus.NumLives = 3;
	        gameStatus.PlayerLevel = 0;
	        gameStatus.Score = 0;
	    }
	}
}
