using UnityEngine;

namespace Assets.Scripts
{
	public class IgnoreCollision : MonoBehaviour {

		// Use this for initialization
		void Start () {
			Physics2D.IgnoreCollision(GetComponent<CircleCollider2D>()
				,GameObject.FindWithTag("target").GetComponent<CircleCollider2D>());
		}
	
		// Update is called once per frame
		void Update () {
		
		}
	}
}
