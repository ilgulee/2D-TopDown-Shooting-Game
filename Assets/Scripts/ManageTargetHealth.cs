using UnityEngine;

namespace Assets.Scripts
{
    public class ManageTargetHealth:MonoBehaviour
    {
        /// <summary>
        /// Health will be used to determine the health of each target.
        /// </summary>
        public int Health;
        /// <summary>
        /// Type is used to set different types of targets; each of these will have different levels of health.
        /// </summary>
        public int Type;
        /// <summary>
        /// TargetBoulder will be used as a type for our moving targets. Both static and public; this means that it can be accessed from 
        /// outside its class.
        /// </summary>
        public static int TargetBoulder = 0;

        private int _score;
        public AudioClip HitSound;

        public bool IsBlinking = false;
        public float Timer;
        public Color PreviousColor;

        public GameObject Explosion; 

        void Start()
        {
            if (Type == TargetBoulder)
            {
                Health = 30;
                _score = 30;
            }
        }

        void Update()
        {
            GetHitEffect();
        }

        /// <summary>
        /// If a target gets hit, this method gives an effect of bliking to it 
        /// </summary>
        private void GetHitEffect()
        {
            if (IsBlinking)
            {
                Timer += Time.deltaTime; //setting timer
                if (Timer >= .1)
                {
                    IsBlinking = false;
                    GetComponent<SpriteRenderer>().color = PreviousColor;
                    Timer = 0;
                }
            }
        }

        /// <summary>
        /// bullet gameObject will use this method to reduce the target's health
        /// </summary>
        /// <param name="damage"></param>
        public void GotHit(int damage)
        {
            Health -= damage;
            if (Health <= 0)
            {
                DestroyTarget();
            }
            else
            {
                PreviousColor = GetComponent<SpriteRenderer>().color;
                GetComponent<SpriteRenderer>().color = Color.red;
                IsBlinking = true;
            }
           
        }

        private void DestroyTarget()
        {
            GetComponent<AudioSource>().clip = HitSound;
            GetComponent<AudioSource>().Play();
            GameObject explosion = Instantiate(Explosion, transform.position, Quaternion.identity);
            Destroy(explosion,.5f);
            Destroy(gameObject);
            GetComponent<SpriteRenderer>().enabled = false;
            //to get score
            GetScore();
        }

        private void GetScore()
        {
            GameObject gameObject = GameObject.Find("GameStatus");
            if (gameObject == null)
            {
                Debug.LogError("Failed to find an object named GameStatus");
                this.enabled = false;
                return;
            }
            //It's the GameStatus script
            GameStatus gameStatus = gameObject.GetComponent<GameStatus>();
            gameStatus.Score += _score;
        }
    }
}
