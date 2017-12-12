using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleControl : MonoBehaviour {

    Vector3 offset;
	// Use this for initialization
	void Start () {
        offset = GetComponent<RectTransform>().localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        offset.x += 5f;
        if (transform.localPosition.x < -100)
            GetComponent<RectTransform>().localPosition = offset;
    }
}
