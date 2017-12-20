using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Stage2Boss : MonoBehaviour
    {
        public float BulletVelocity;
        public GameObject Bullet;
        public bool StartShootingTimer;
        public bool CanShoot = true;
        public float ShootingTimer;

        private bool incoming;
        private Vector3 posStarting;
        
        // Use this for initialization
        void Start()
        {
            incoming = true;
            posStarting = new Vector3(0, 3.5f, 0);
            GetComponent<Rigidbody2D>().velocity = Vector2.down;
            Shoot();
        }

        // Update is called once per frame
        void Update()
        {
            Movement();
            Shoot();
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
        }
        
        void Movement()
        {
            // reset movement
            if (incoming && GetComponent<Transform>().position.y <= 4.5f)
            {
                GetComponent<Transform>().position = new Vector3(0, 4.5f, 0);
                GetComponent<Rigidbody2D>().velocity = new Vector2(0.5f, 0.5f);
                incoming = false;
            }
            else if(!incoming)
            {
                if(GetComponent<Transform>().position.x >= 2)
                    GetComponent<Rigidbody2D>().velocity += new Vector2(-0.5f, 0);
                else if(GetComponent<Transform>().position.x <= -2)
                    GetComponent<Rigidbody2D>().velocity += new Vector2(0.5f, 0);

                if (GetComponent<Transform>().position.y >= 5f)
                    GetComponent<Rigidbody2D>().velocity += new Vector2(0, -0.5f);
                else if (GetComponent<Transform>().position.y <= 4f)
                    GetComponent<Rigidbody2D>().velocity += new Vector2(0, 0.5f);
            }
        }

        void Shoot()
        {
            
            if (CanShoot && !incoming)
            {
                for(float i = -0.8f; i <= 0.8; i += 0.2f)
                {
                    GameObject bullet1 = Instantiate(Bullet, transform.position - transform.up * 1.2f, Quaternion.identity);
                    bullet1.GetComponent<Rigidbody2D>().AddForce(new Vector2(i, -1).normalized * BulletVelocity);
                }
                CanShoot = false;
                StartShootingTimer = true;
            }
        }
    }
}
