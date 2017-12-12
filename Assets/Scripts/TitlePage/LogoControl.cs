using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoControl : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        if (transform.rotation.x > 0)
            transform.Rotate(-Time.deltaTime * 30, 0, 0);
        else
            transform.rotation = new Quaternion(0, 0, 0, 0);
	}
}
