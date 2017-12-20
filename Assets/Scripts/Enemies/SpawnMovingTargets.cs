using UnityEngine;

namespace Assets.Scripts
{
    public class SpawnMovingTargets : MonoBehaviour
    {
        private float timer = 0;
        public GameObject NewObject;

        void Update()
        {
            timer += Time.deltaTime;
            float range = Random.Range(-5, 5);
            if (GameObject.Find("player") != null)
            {
                Vector3 newPositon = new Vector3(GameObject.Find("player").transform.position.x + range, transform.position.y, 0);

                if (timer >= 1f)
                {
                    GameObject t = Instantiate(NewObject, newPositon, Quaternion.identity);
                    Vector3 viewPortPosition = Camera.main.WorldToViewportPoint(t.transform.position);//1
                    Vector3 viewPortXDelta = Camera.main.WorldToViewportPoint(t.transform.position + Vector3.left / 2);
                    float deltaX = viewPortPosition.x - viewPortXDelta.x;
                    viewPortPosition.x = Mathf.Clamp(viewPortPosition.x, 0 + deltaX, 1 - deltaX);//2
                    t.transform.position = Camera.main.ViewportToWorldPoint(viewPortPosition);//4
                    //we specify that the value of the variable called type, for the script called ManageTargetHealth, 
                    //that is a component of the object t is TargetBoulder
                    t.GetComponent<ManageTargetHealth>().Type = ManageTargetHealth.TargetBoulder;

                    timer = 0;
                }
            }
        }
    }
}