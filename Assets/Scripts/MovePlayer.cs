using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{

    public GameObject bullet; //set the public field of Game Object in the inspector of player

    public float bulletVelocity = 1000.0f; //set the public field of initializing bullet's velocity.  
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	    PlayerMove();
	    BulletInstance();
	}

    private void BulletInstance()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //if player pushes the space bar, the bullet object is placed in the game.
            GameObject b = Instantiate(bullet, transform.position + transform.up * 1.5f, Quaternion.identity);
            //giving the bullet velocity after launching.
            b.GetComponent<Rigidbody2D>().AddForce(transform.up * bulletVelocity);
        }
    }

    private void PlayerMove()
    {
        if (Input.GetKey(KeyCode.LeftArrow)) //if you want to check whether a key has been released, use GetKeyDown instead
        {
            gameObject.transform.Translate(Vector3.left * 0.1f); //o.1m to the left
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            gameObject.transform.Translate(Vector3.right * 0.1f);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            gameObject.transform.Translate(Vector3.up * 0.1f);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            gameObject.transform.Translate(Vector3.down * 0.1f);
        }

        Vector3 viewPortPosition = Camera.main.WorldToViewportPoint(transform.position);
        Vector3 viewPortXDelta = Camera.main.WorldToViewportPoint(transform.position + Vector3.left / 2);
        Vector3 viewPortYDelta = Camera.main.WorldToViewportPoint(transform.position + Vector3.up / 2);
        float deltaX = viewPortPosition.x - viewPortXDelta.x;
        float deltaY = -viewPortPosition.y + viewPortYDelta.y;
        viewPortPosition.x = Mathf.Clamp(viewPortPosition.x, 0 + deltaX, 1 - deltaX);
        viewPortPosition.y = Mathf.Clamp(viewPortPosition.y, 0 + deltaY, 1 - deltaY);
        transform.position = Camera.main.ViewportToWorldPoint(viewPortPosition);
    }
}
//CTRL+P to stop game scene
