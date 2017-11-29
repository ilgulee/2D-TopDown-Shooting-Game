using UnityEngine;

namespace Assets.Scripts
{
    public class ScrollingBG : MonoBehaviour
    {

        // Update is called once per frame
        void Update()
        {
            GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, 0.5f * Time.time);
        }
    }
}
