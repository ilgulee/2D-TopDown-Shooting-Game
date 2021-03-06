﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class Level1Control : MonoBehaviour
    {
        public GameObject enemyType1;
        public GameObject ItemPowerUp;

        private int spawnedEnemy;
        private bool _stageCleared;

        // Use this for initialization
        void Start()
        {
            spawnedEnemy = 0;
            //_stageCleared = false;

            // position.x between -4 ~ 4  enemy number: 24
            StartCoroutine(spwanEnemy(new Vector3(-4, 8, 0), 1.0f));
            StartCoroutine(spwanEnemy(new Vector3(-2, 8, 0), 2.0f));
            StartCoroutine(spwanEnemy(new Vector3(4, 8, 0), 3.0f));
            StartCoroutine(spwanEnemy(new Vector3(-1, 8, 0), 4.0f));
            StartCoroutine(spwanEnemy(new Vector3(2, 8, 0), 4.0f));
            StartCoroutine(spwanEnemy(new Vector3(0, 8, 0), 5.0f));

            StartCoroutine(spwanEnemy(new Vector3(-4, 8, 0), 7.0f));
            StartCoroutine(spwanEnemy(new Vector3(1, 8, 0), 8.0f));
            StartCoroutine(spwanEnemy(new Vector3(3, 8, 0), 8.0f));
            StartCoroutine(spwanEnemy(new Vector3(-1, 8, 0), 9.0f));
            StartCoroutine(spwanEnemy(new Vector3(-3, 8, 0), 9.0f));
            StartCoroutine(spwanEnemy(new Vector3(4, 8, 0), 10.0f));

            StartCoroutine(spwanEnemy(new Vector3(-4, 8, 0), 12.0f));
            StartCoroutine(spwanEnemy(new Vector3(-2, 8, 0), 13.0f));
            StartCoroutine(spwanEnemy(new Vector3(4, 8, 0), 14.0f));
            StartCoroutine(spwanEnemy(new Vector3(-1, 8, 0), 15.0f));
            StartCoroutine(spwanEnemy(new Vector3(2, 8, 0), 15.0f));
            StartCoroutine(spwanEnemy(new Vector3(0, 8, 0), 16.0f));

            StartCoroutine(spwanEnemy(new Vector3(4, 8, 0), 18.0f));
            StartCoroutine(spwanEnemy(new Vector3(-1, 8, 0), 19.0f));
            StartCoroutine(spwanEnemy(new Vector3(3, 8, 0), 19.0f));
            StartCoroutine(spwanEnemy(new Vector3(1, 8, 0), 20.0f));
            StartCoroutine(spwanEnemy(new Vector3(-3, 8, 0), 20.0f));
            StartCoroutine(spwanEnemy(new Vector3(-3, 8, 0), 20.0f));

            // items
            StartCoroutine(dropItem(6.0f));
        }

        // Update is called once per frame
        void Update()
        {
            if (spawnedEnemy >= 24 && GameObject.FindGameObjectWithTag("target") == null)
            {
                StartCoroutine(nextStage(1.5f));
            }
        }

        private IEnumerator spwanEnemy(Vector3 position, float waitTime)
        {
            yield return new WaitForSeconds(waitTime);
            GameObject t = Instantiate(enemyType1, position, Quaternion.identity);
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

        private IEnumerator dropItem(float waitTime)
        {
            yield return new WaitForSeconds(waitTime);

            GameObject item = Instantiate(ItemPowerUp, new Vector2(0, 8), Quaternion.identity);
        }
        // proceed to next stage
        private IEnumerator nextStage(float waitTime)
        {
            yield return new WaitForSeconds(waitTime);
            SceneManager.LoadScene("Level2");
            // save player power lvl before moving to next stage
            if (GameObject.FindGameObjectWithTag("Player").GetComponent<MovePlayer>().PowerUp == true)
                GameStatus.GetInstance().PowerUp = true;

            GameStatus.GetInstance().StageLevel = 2;
        }
    }
}
