using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerBullet : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            Destroy(gameObject, 3); //set the bullet to be removed in 10 seconds
        }

        void OnTriggerEnter2D(Collider2D coll)
        {
            //The object linked to this script checks colliding with obejct tagged "target" and does damage to it.
            if (coll.gameObject.tag == "target")
            {
                coll.gameObject.GetComponent<ManageTargetHealth>().GotHit(10);
                Destroy(gameObject); //after giving hit damage to target, the bullet itself removed from scene.
            }
        }
    }
}
