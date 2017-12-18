﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class Level1Control : MonoBehaviour
    {
        public GameObject NewObject;

        private int spawnedEnemy; 

        // Use this for initialization
        void Start()
        {
            spawnedEnemy = 0;

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
        }

        // Update is called once per frame
        void Update()
        {
            // proceed to next stage when stage is cleared
            if (spawnedEnemy >= 24 && GameObject.FindGameObjectWithTag("target") == null)
                nextStage();
        }

        private IEnumerator spwanEnemy(Vector3 position, float waitTime)
        {
            yield return new WaitForSeconds(waitTime);
            GameObject t = Instantiate(NewObject, position, Quaternion.identity);
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
        private void nextStage()
        {
            SceneManager.LoadScene("Level2");
            GameStatus.GetInstance().StageLevel = 2;
        }
    }
}
