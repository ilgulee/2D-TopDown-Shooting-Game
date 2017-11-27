using UnityEngine;

namespace Assets.Scripts
{
	public class GameStatus : MonoBehaviour
	{
		public int NumLives = 3;

		public int Score = 0;

		public int PlayerLevel = 1;

	    private static GameStatus ThisIsTheOneAndOnlyGameStatus;
		// Use this for initialization
		void Start ()
		{
		    if (ThisIsTheOneAndOnlyGameStatus != null)
		    {
		        Destroy(this.gameObject);
		        return;
		    }
		    ThisIsTheOneAndOnlyGameStatus = this;
		    GameObject.DontDestroyOnLoad(this.gameObject);
		}
	
		// Update is called once per frame
		void Update () {
		
		}

	    
	}
}
