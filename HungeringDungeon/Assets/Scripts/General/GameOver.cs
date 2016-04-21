using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class GameOver : MonoBehaviour {

	public CanvasGroup gameOverText;
	bool countingDown = false;
	public float timeRemaining;


	void Update(){
		if(countingDown){
			if(timeRemaining<0.0f){
				Application.LoadLevel("StartScreen");
			}else{
				timeRemaining-=Time.deltaTime;
			}
		}else{
			if(GameObject.FindGameObjectsWithTag("Spawner").Length==0 && GameObject.FindGameObjectsWithTag("Enemy").Length==0){
				win();
			}
		}

	}

	public void gameOver(){
		gameOverText.alpha = 1;
		countingDown = true;
	}

    void win(){
		gameOverText.alpha = 1;
		gameOverText.GetComponent<Text>().text = "You win!";
		gameOverText.GetComponent<Text>().color = Color.green;
		countingDown = true;
	}
}
