using System.Collections;
using UnityEngine;
using TMPro;
using Assets.Scripts.PlayerServices;

namespace Assets.Scripts
{
    public class projectile : MonoBehaviour
    {

        public GameObject lazor;
        PlayerScore playerScore;

        private void Start()
        {
            playerScore = GetComponent<PlayerScore>();
        }

        private void Update()
        {
            transform.Translate(new Vector3(0, 5 * Time.deltaTime, 0));
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                if(playerScore != null)
                {
                    playerScore.addScore(10);
                }
                
                //PlayerScore.scoreValue += 10;
                Destroy(collision.gameObject);
                
                //Destroy(lazor);
                gameObject.SetActive(false);
                
            }

            if (collision.gameObject.tag == "Finish")
            {
                //Destroy(lazor);
                gameObject.SetActive(false);
            }
        }

       
    }
} 