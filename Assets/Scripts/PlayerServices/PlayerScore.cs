using System.Collections;
using UnityEngine;
using TMPro;
namespace Assets.Scripts.PlayerServices
{
    public class PlayerScore : MonoBehaviour
    {

        public int scoreValue = 10;
        public TMP_Text scoreText;

        // Use this for initialization
        void Start()
        {
            //scoreText = GetComponent<TMP_Text>();
            scoreValue = 10;
        }

        // Update is called once per frame
        void Update()
        {
            //scoreText.text = "Score : " + scoreValue.ToString();
        }

        public void addScore(int amt)
        {
            scoreValue += amt;
            scoreText.text = "Score : " + scoreValue.ToString();
        }
    }
}