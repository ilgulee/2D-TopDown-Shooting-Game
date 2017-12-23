using UnityEngine;

namespace Assets.Scripts
{
    public class ChasingTarget : MonoBehaviour
    {
        private float rotationSpeed = 100f;
        private Transform player;
        private float _movingSpeed = 4;
        private float _bulletSpeed = 500;
        public Vector3 BulletOffSet = new Vector3(0, 0.5f, 0);

        public GameObject Bullet;

        public float FireDelay = 2f;

        private float _cooldownTimer = 2;

        // Use this for initialization
        void Start()
        {
            GetComponent<Rigidbody2D>().isKinematic = true;
        }

        // Update is called once per frame
        void Update()
        {
            if (player == null)
            {
                GameObject go = GameObject.Find("player");
                if (go != null)
                {
                    player = go.transform;
                }
            }

            if (player == null)
            {
                return;
            }

            Vector3 direction = player.position - transform.position;
            direction.Normalize();

            float zAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90;
            Quaternion desiredRotation = Quaternion.Euler(0, 0, zAngle);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);

            MoveForward();
            BulletInstance();
        }

        private void BulletInstance()
        {
            _cooldownTimer -= Time.deltaTime;

            if (_cooldownTimer <= 0)
            {
                _cooldownTimer = FireDelay;
                Vector3 offset = transform.rotation * BulletOffSet;
                GameObject bulletGameObject = Instantiate(Bullet, transform.position - offset, transform.rotation);
                bulletGameObject.GetComponent<Rigidbody2D>().AddRelativeForce(Vector3.down * _bulletSpeed);

            }

        }

        private void MoveForward()
        {
            Vector3 pos = transform.position;
            Vector3 velocity = new Vector3(0, _movingSpeed * Time.deltaTime, 0);
            pos -= transform.rotation * velocity;
            transform.position = pos;
        }
    }
}
