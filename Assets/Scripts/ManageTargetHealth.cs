using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class ManageTargetHealth:MonoBehaviour
    {
        public int Health, Type;
        public static int TargetBoulder = 0;

        public bool IsBlinking = false;
        public float Timer;
        public Color PreviousColor;

        public GameObject Explosion; 

        void Start()
        {
            if (Type == TargetBoulder)
            {
                Health = 30;
            }
        }

        void Update()
        {
            if (IsBlinking)
            {
                Timer += Time.deltaTime;
                if (Timer >= .1)
                {
                    IsBlinking = false;
                    GetComponent<SpriteRenderer>().color = PreviousColor;
                    Timer = 0;
                }
            }
        }

        public void GotHit(int damage)
        {
            Health -= damage;
            if (Health <= 0)
            {
                DestroyTarget();
            }
            PreviousColor = GetComponent<SpriteRenderer>().color;
            GetComponent<SpriteRenderer>().color = Color.red;
            IsBlinking = true;
        }

        private void DestroyTarget()
        {
            GameObject explosion = Instantiate(Explosion, transform.position, Quaternion.identity);
            Destroy(explosion,.5f);
            Destroy(gameObject);
        }
    }
}
