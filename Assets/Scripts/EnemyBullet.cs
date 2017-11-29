using UnityEngine;

namespace Assets.Scripts
{
    public class EnemyBullet : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            Destroy(gameObject, 3); //set the bullet to be removed in 3 seconds
        }

        void OnTriggerEnter2D(Collider2D coll)
        {
            //The enemy bullet object linked to this script checks colliding with obejct tagged "target" and does damage to it.
            if (coll.gameObject.tag == "player")
            {
                coll.gameObject.GetComponent<ManagePlayerHealth>().DestroyPlayer();

                Destroy(gameObject); //after giving hit damage to target, the bullet itself removed from scene.
            }
        }
    }
}
