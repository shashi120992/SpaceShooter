using System.Collections;
using UnityEngine;

namespace Assets.Scripts.EnemyService
{
    public class EnemyProjectile : MonoBehaviour
    {

        public GameObject EnemyLazor;
        public CanvasManager canvasManager;
        [HideInInspector] PlayerShooting playerShooting;

        private void Update()
        {
            
            transform.Translate(new Vector3(0, -5 * Time.deltaTime, 0));

            if (transform.position.y < -4f)
            {
                Destroy(gameObject);
                //gameObject.SetActive(false);
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                GameObject collitionGameObject = collision.gameObject;
                if(collitionGameObject.GetComponent<PlayerHealth>() != null)
                {
                    collitionGameObject.GetComponent<PlayerHealth>().takeDamage(20);
                }
                //Destroy(collision.gameObject);
                Destroy(EnemyLazor);
                
                //gameObject.SetActive(false);
                //canvasManager.gameOverCanvas.enabled = true;
            }
        }
    }
}
