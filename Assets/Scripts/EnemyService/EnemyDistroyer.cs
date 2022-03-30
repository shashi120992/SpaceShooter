using System.Collections;
using UnityEngine;

namespace Assets.Scripts.EnemyService
{
    public class EnemyDistroyer : MonoBehaviour
    {
        /*
        float timer = 0;
        float timeTOmove = 0.5f;
        */
        private void Update()
        {
            /*
             timer += Time.deltaTime;
            if (timer > timeTOmove)
            {
                transform.Translate(new Vector3(0, -2f, 0));
                timer = 0;
            }
            */

            if ( transform.position.y < -4f)
            {
                //Destroy(gameObject);
                gameObject.SetActive(false);
            }
        }
    }
}