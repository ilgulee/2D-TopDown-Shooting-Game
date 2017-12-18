using UnityEngine;

namespace Assets.Scripts
{
    class MovingTarget : MonoBehaviour
    {
        public float BulletVelocity;
        public GameObject Bullet;
        public bool StartShootingTimer;
        public bool CanShoot = true;
        public float ShootingTimer;

        void Start()
        {
            Destroy(gameObject, 8f);
            GetComponent<Rigidbody2D>().isKinematic = true;
            GetComponent<Rigidbody2D>().velocity = Vector2.down * 2;
        }

        void Update()
        {
            if (StartShootingTimer)
            {
                ShootingTimer += Time.deltaTime;
                if (ShootingTimer >= 1.5)
                {
                    StartShootingTimer = false;
                    CanShoot = true;
                    ShootingTimer = 0;
                }
            }
            DetectPlayer(); 
        }

        private void DetectPlayer()
        {
            if ((GameObject.Find("player") != null))
            {
                float playerXPositon = GameObject.Find("player").transform.position.x;
                if (transform.position.x < (playerXPositon + 1) && transform.position.x > (playerXPositon - 1))
                {
                    Shoot();
                }
            }
        }

        private void Shoot()
        {
            if (CanShoot)
            {
                GameObject b = Instantiate(Bullet, transform.position - transform.up * 1.2f, Quaternion.identity);
                b.GetComponent<Rigidbody2D>().AddForce(Vector3.down * BulletVelocity);
                CanShoot = false;
                StartShootingTimer = true;
            }
        }
    }
}
