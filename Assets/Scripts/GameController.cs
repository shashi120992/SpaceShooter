using System.Collections;
using UnityEngine;
using TMPro;

namespace Assets.Scripts
{
    public class GameController : MonoBehaviour
    {
        float currentScore = 0;
        public TMP_Text scoreText;

        private void Start()
        {
            currentScore = 0;
        }

        public void addScore(float amt)
        {
            currentScore += amt;
            scoreText.text = "Score : " + currentScore.ToString();
        }

    }
}