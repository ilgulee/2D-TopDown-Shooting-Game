using UnityEngine;

namespace Assets.Scripts
{
    public class SpawnMovingTargets:MonoBehaviour
    {
        private float timer = 0;
        public GameObject newObject;

        void Update()
        {
            timer += Time.deltaTime;
            float range = Random.Range(-5, 5);
            if (GameObject.Find("player") != null)
            {
                Vector3 newPositon = new Vector3(GameObject.Find("player").transform.position.x + range, transform.position.y, 0);
                if (timer >= 1)
                {
                    GameObject t = Instantiate(newObject, newPositon, Quaternion.identity);

                    t.GetComponent<ManageTargetHealth>().Type = ManageTargetHealth.TargetBoulder;

                    timer = 0;
                }
            }
            
        }
    }
}