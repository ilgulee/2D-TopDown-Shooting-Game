using UnityEngine;

namespace Assets.Scripts
{
    public class IgnoreCollision : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            //ignore collision between enemyBullet and enemies(target)
            Physics2D.IgnoreCollision(GetComponent<CircleCollider2D>()
                , GameObject.FindWithTag("target").GetComponent<CircleCollider2D>());
        }
    }
}
