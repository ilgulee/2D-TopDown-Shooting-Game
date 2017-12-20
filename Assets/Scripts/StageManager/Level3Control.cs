using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class Level3Control : MonoBehaviour
    {

        public GameObject enemyType1;
        public GameObject enemyType2;
        public GameObject boss;

        private int spawnedEnemy;
        private bool bossPop;

        // Use this for initialization
        void Start()
        {
            spawnedEnemy = 0;
            bossPop = false;

            // position.x between -4 ~ 4  enemy number: 30
            StartCoroutine(spwanEnemy(enemyType1, new Vector3(-4, 8, 0), 1.0f));
            StartCoroutine(spwanEnemy(enemyType2, new Vector3( 0, 8, 0), 2.0f));
            StartCoroutine(spwanEnemy(enemyType1, new Vector3( 4, 8, 0), 3.0f));
            StartCoroutine(spwanEnemy(enemyType1, new Vector3(-1, 8, 0), 4.0f));
            StartCoroutine(spwanEnemy(enemyType2, new Vector3( 2, 8, 0), 4.0f));
            StartCoroutine(spwanEnemy(enemyType1, new Vector3( 0, 8, 0), 5.0f));

            StartCoroutine(spwanEnemy(enemyType2, new Vector3(-4, 8, 0), 7.0f));
            StartCoroutine(spwanEnemy(enemyType1, new Vector3(4, 8, 0), 7.0f));
            StartCoroutine(spwanEnemy(enemyType2, new Vector3(-3, 8, 0), 8.0f));
            StartCoroutine(spwanEnemy(enemyType2, new Vector3(3, 8, 0), 8.0f));
            StartCoroutine(spwanEnemy(enemyType1, new Vector3(-2, 8, 0), 9.0f));
            StartCoroutine(spwanEnemy(enemyType2, new Vector3(2, 8, 0), 9.0f));

            StartCoroutine(spwanEnemy(enemyType1, new Vector3(-4, 8, 0), 11.0f));
            StartCoroutine(spwanEnemy(enemyType1, new Vector3(0, 8, 0), 12.0f));
            StartCoroutine(spwanEnemy(enemyType2, new Vector3(4, 8, 0), 13.0f));
            StartCoroutine(spwanEnemy(enemyType1, new Vector3(-1, 8, 0), 14.0f));
            StartCoroutine(spwanEnemy(enemyType1, new Vector3(2, 8, 0), 14.0f));
            StartCoroutine(spwanEnemy(enemyType2, new Vector3(0, 8, 0), 15.0f));

            StartCoroutine(spwanEnemy(enemyType2, new Vector3(-2, 8, 0), 17.0f));
            StartCoroutine(spwanEnemy(enemyType2, new Vector3(2, 8, 0), 17.0f));
            StartCoroutine(spwanEnemy(enemyType1, new Vector3(-3, 8, 0), 18.0f));
            StartCoroutine(spwanEnemy(enemyType2, new Vector3(3, 8, 0), 18.0f));
            StartCoroutine(spwanEnemy(enemyType2, new Vector3(-4, 8, 0), 19.0f));
            StartCoroutine(spwanEnemy(enemyType1, new Vector3(4, 8, 0), 19.0f));

            StartCoroutine(spwanEnemy(enemyType1, new Vector3(-4, 8, 0), 20.0f));
            StartCoroutine(spwanEnemy(enemyType2, new Vector3(-2, 8, 0), 21.0f));
            StartCoroutine(spwanEnemy(enemyType1, new Vector3(-3, 8, 0), 22.0f));
            StartCoroutine(spwanEnemy(enemyType1, new Vector3(4, 8, 0), 24.0f));
            StartCoroutine(spwanEnemy(enemyType2, new Vector3(2, 8, 0), 25.0f));
            StartCoroutine(spwanEnemy(enemyType1, new Vector3(3, 8, 0), 26.0f));


            /**
             * Stage Boss
             */
            StartCoroutine(spwanEnemy(boss, new Vector3(0, 8, 0), 32.0f));

        }

        // Update is called once per frame
        void Update()
        {
            if (spawnedEnemy >= 31 && GameObject.FindGameObjectWithTag("target") == null)
                StartCoroutine(nextStage(1.5f));
        }

        /**
         * 
         */
        private IEnumerator spwanEnemy(GameObject enemyType, Vector3 position, float waitTime)
        {
            yield return new WaitForSeconds(waitTime);
            GameObject t = Instantiate(enemyType, position, Quaternion.identity);
            Vector3 viewPortPosition = Camera.main.WorldToViewportPoint(t.transform.position);
            Vector3 viewPortXDelta = Camera.main.WorldToViewportPoint(t.transform.position + Vector3.left / 2);
            float deltaX = viewPortPosition.x - viewPortXDelta.x;
            viewPortPosition.x = Mathf.Clamp(viewPortPosition.x, 0 + deltaX, 1 - deltaX);
            t.transform.position = Camera.main.ViewportToWorldPoint(viewPortPosition);
            t.GetComponent<ManageTargetHealth>().Type = ManageTargetHealth.TargetBoulder;

            // check number of enemies
            spawnedEnemy++;
            Debug.Log(spawnedEnemy);
        }

        // proceed to next stage
        private IEnumerator nextStage(float waitTime)
        {
            yield return new WaitForSeconds(waitTime);
            SceneManager.LoadScene("Win");
            GameStatus.GetInstance().StageLevel = 3;
        }
    }
}

