using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgSpriteScrolling : MonoBehaviour
{

    float scrollspeed = -0.01f;
    Vector3 offset;

    // Use this for initialization
    void Start()
    {
        offset = GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        offset.y += scrollspeed;
        GetComponent<Transform>().position = offset;

        // rest position for continuous scrolling
        if (offset.y <= -15)
            offset.y = 15;
    }
}
