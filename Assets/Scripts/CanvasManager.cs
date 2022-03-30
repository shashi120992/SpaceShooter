using System.Collections;
using UnityEngine;
using TMPro;

namespace Assets.Scripts
{
    public class CanvasManager : MonoBehaviour
    {
		//canvases
		public Canvas menuCanvas;
		public Canvas instructionsCanvas;
		public Canvas highscoreCanvas;
		public Canvas gameCanvas;
		public Canvas gameOverCanvas;


		//textfeilds
		public TMP_Text nameText;
		public TMP_Text scoreText;
		public TMP_Text endscoreText;
		public TMP_Text actualHighscoreText;
		public TMP_Text newHighscoreText;
		public TMP_Text newHighText;

		public string playerName = "Shashi";
		public int score = 0;

		public enum GameStates
		{
			menu,
			instructions,
			game,
			over,
			hiscore,
		};

		// store the actual game state
		public GameStates gameState = GameStates.menu;

		void resetGame()
		{
			playerName = "Shashi";
			score = 0;
		}



		void Start()
		{
			// set the UI screens
			menuCanvas.enabled = true;
			instructionsCanvas.enabled = false;
			highscoreCanvas.enabled = false;
			gameCanvas.enabled = false;
			gameOverCanvas.enabled = false;

			// create the PlayerPref
			initScore();
		}

		void Update()
		{
			// check the game states
			switch (gameState)
			{
				case GameStates.menu:
					if (Input.GetKeyDown(KeyCode.Escape))
					{
						Application.Quit();
					}
					break;

				case GameStates.game:
					showName();
					showScore();

					if (Input.GetKeyDown(KeyCode.Escape))
					{
						showMenu();
					}
					break;

				case GameStates.instructions:
					break;

				case GameStates.over:
					break;

				case GameStates.hiscore:
					break;
			}
		}

		public void initScore()
		{
			if (!PlayerPrefs.HasKey("Score"))
				PlayerPrefs.SetInt("Score", 0);
		}


		public void showScore()
		{
			scoreText.text = "Score: " + score.ToString();
		}


		public void showName()
		{
			nameText.text = "Name: Shashi ";
		}







		//Insrtuctions
		//--------------------------------------------------------------------------------
		public void showInstructions()
		{
			menuCanvas.enabled = false;
			instructionsCanvas.enabled = true;
		}

		public void hideInstructions()
		{
			menuCanvas.enabled = true;
			instructionsCanvas.enabled = false;
		}
		//-----------------------------------------------------------------------------------------

		//High Scores
		//-----------------------------------------------------------------------------------------
		public void showHighscore()
		{
			menuCanvas.enabled = false;
			highscoreCanvas.enabled = true;
			actualHighscoreText.text = "Actual Hiscore: " + PlayerPrefs.GetInt("Score") + " points";
			newHighscoreText.text = "Your Score: " + score + " points";
			if (score > PlayerPrefs.GetInt("Score"))
				newHighText.enabled = true;
			else
				newHighText.enabled = false;
		}

		public void hideHighScore()
		{
			menuCanvas.enabled = true;
			highscoreCanvas.enabled = false;
			if (score > PlayerPrefs.GetInt("Score"))
			{
				PlayerPrefs.SetInt("Score", score);
			}
			resetGame();
		}

		public void checkHighScore()
		{
			gameOverCanvas.enabled = false;
			if (score > PlayerPrefs.GetInt("Score"))
			{
				showHighscore();
			}
			else
			{
				menuCanvas.enabled = true;
				resetGame();
			}
		}

		// -----------------------------------------------------------------------------------------------
		//
		public void startGame()
		{
			menuCanvas.enabled = false;
			highscoreCanvas.enabled = false;
			instructionsCanvas.enabled = false;
			gameCanvas.enabled = true;
			gameState = GameStates.game;
		}

		public void showMenu()
		{
			menuCanvas.enabled = true;
			gameState = GameStates.menu;
			resetGame();
		}
		
	}
}