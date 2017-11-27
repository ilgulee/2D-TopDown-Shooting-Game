using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
	public class StatusPanelUpdate : MonoBehaviour {

		// Use this for initialization
		void Start () {
		
		}
	
		// Update is called once per frame
		void Update () {
			//to grab the GameSatus
			GameObject gameObject=GameObject.Find("GameStatus");
			if (gameObject == null)
			{
				Debug.LogError("Failed to find an object named GameStatus");
				this.enabled = false;
				return;
			}
			//It's the GameStatus script
			GameStatus gameStatus = gameObject.GetComponent<GameStatus>();
			GetComponent<Text>().text = "Score: " + gameStatus.Score + " Lives: " + gameStatus.NumLives+" Level: "+gameStatus.PlayerLevel;
		}
	}
}
