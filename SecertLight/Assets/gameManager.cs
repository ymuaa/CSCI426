using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour {

	public Text EnergyLevelLabel;
	public Text GameWinLabel;
	public Text GameOverLabel;
    private int energyLevel;
	public bool gameOver = false;
	public Button Restart;
	public Button Home;
	public Button NextLevel;

	public int EnergyLevel
	{
		get
		{
			return energyLevel;
		}
		set
		{
			energyLevel = value;
			EnergyLevelLabel.text = "EnergyLevel : " + energyLevel;
		}
	}

	// Use this for initialization
	void Start () {
		EnergyLevel =1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void GameWin(){
		gameOver = true;
	    GameWinLabel.gameObject.SetActive(true);
	    NextLevel.gameObject.SetActive(true);
	    Home.gameObject.SetActive(true);
	    Time.timeScale = 0;

	}
	public void GameOver(){
		gameOver = true;
	    GameOverLabel.gameObject.SetActive(true);
	    Restart.gameObject.SetActive(true);
	    Home.gameObject.SetActive(true);
	    Time.timeScale = 0;

	}
}
