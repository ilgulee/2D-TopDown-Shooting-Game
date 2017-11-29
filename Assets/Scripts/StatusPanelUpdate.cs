using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class StatusPanelUpdate : MonoBehaviour
    {

        // Update is called once per frame
        void Update()
        {

            GetComponent<Text>().text = "Score: " + GameStatus.GetInstance().Score
                + " Lives: " + GameStatus.GetInstance().NumLives + " Level: "
                + GameStatus.GetInstance().PlayerLevel;
        }
    }
}
