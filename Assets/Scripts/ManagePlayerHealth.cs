using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class ManagePlayerHealth : MonoBehaviour
    {
        public GameObject Explosion;
        public AudioClip HitSound;
        public float TimerForShield;
        public bool StartInvincibility = true;

        // Update is called once per frame
        private void Update()
        {
            if (StartInvincibility)
            {
                TimerForShield += Time.deltaTime;
                if (TimerForShield >= 2)
                {
                    TimerForShield = 0;
                    StartInvincibility = false;
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D coll)  //OnCollisionEnter2D(Collision2D coll)
        {
            if (coll.gameObject.tag == "target" && !StartInvincibility)
            {
                //Destroy(coll.gameObject);
                coll.gameObject.GetComponent<ManageTargetHealth>().GotHit(100);
                DestroyPlayer();
            }
            if (coll.gameObject.tag == "bullet" && !StartInvincibility)
            {
                Destroy(coll.gameObject);
                DestroyPlayer();
            }
        }

        public void DestroyPlayer()
        {
            GetComponent<AudioSource>().clip = HitSound;
            GetComponent<AudioSource>().Play();
            GameObject explosion = Instantiate(Explosion, transform.position, Quaternion.identity);
            Destroy(explosion, .5f);

            this.gameObject.SetActive(false);

            //To reduce live
            ReduceLive();
        }

        private void ReduceLive()
        {

            GameStatus.GetInstance().NumLives--;

            int live = GameStatus.GetInstance().NumLives;
            if (live >= 1)
            {
                Invoke("LoadScene", 2);
            }
            else
            {
                Invoke("LoadLose", 2);
            }
        }

        private void LoadLose()
        {
            SceneManager.LoadScene("Lose");
        }
        private void LoadScene()
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);


        }
    }
}
