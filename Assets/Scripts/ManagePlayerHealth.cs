using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
	public class ManagePlayerHealth : MonoBehaviour
	{
		public GameObject Explosion;


		// Use this for initialization
		private void Start () {
		
		}
	
		// Update is called once per frame
		private void Update () {
			
		}

		private void OnCollisionEnter2D(Collision2D coll)
		{
			if (coll.gameObject.tag == "target")
			{
			    Invoke("LoadScene", 2);
				Destroy(coll.gameObject);
				DestroyPlayer();
			}
            
		}

		private void DestroyPlayer()
		{
			GameObject explosion = Instantiate(Explosion, transform.position, Quaternion.identity);
			Destroy(explosion, .5f);
		    this.GetComponent<SpriteRenderer>().enabled = false;






		}

	    private void LoadScene()
	    {
	        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	        Destroy(this.gameObject);
        }
	}
}
