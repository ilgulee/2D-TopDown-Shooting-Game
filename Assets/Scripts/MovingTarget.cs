using UnityEngine;

namespace Assets.Scripts
{
    class MovingTarget:MonoBehaviour
    {
        public float BulletVelocity = 1000.0f;
        public GameObject Bullet;
        /// <summary>
        /// Direction will be used to determine in what direction the target will be moving.
        /// </summary>
        //public float Direction = 1.0f;
        /// <summary>
        /// Timer will be employed to determine when the target changes direction.
        /// </summary>
        //public float Timer; 
        void Start()
        {
            Destroy(gameObject,10f);
            GetComponent<Rigidbody2D>().isKinematic = true;
            GetComponent<Rigidbody2D>().velocity = Vector2.down * 2;
        }

        void Update()
        {
            DetectPlayer();
            //Timer += Time.deltaTime;
            //transform.Translate(Vector3.left*Direction*Time.deltaTime*2);
            //if (Timer >= 1)
            //{
            //    Direction *= -1;
            //    Timer = 0;
            //}
        }

        private void DetectPlayer()
        {
            float playerXPositon = GameObject.Find("player").transform.position.x;
            if (transform.position.x < (playerXPositon + 1) && transform.position.x > (playerXPositon - 1))
            {
                //Shoot();
            }
        }

        private void Shoot()
        {
            GameObject b = Instantiate(Bullet, transform.position + transform.up * 1.5f, Quaternion.identity);
            b.GetComponent<Rigidbody2D>().AddForce(Vector3.down * BulletVelocity);
        }
    }
}
