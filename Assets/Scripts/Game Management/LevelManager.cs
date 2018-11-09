using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

	public Transform spawnPosition;
	public Transform bottomOfLevel;
	
	public GameObject player;
    public GameObject gameOverUI;
	public Text livesText;
	public Text scoreText;
	public Text ammoText;
	public int lives = 2;
	public int score = 0;

	// Use this for initialization
	void Start () {
		player.transform.position = spawnPosition.position;
		livesText.text = "Lives: " + lives;
		scoreText.text = "Score: " + score;
		ammoText.text = "Ammo: " + player.GetComponent<PlayerMoveScript>().ammo;
	}
	
	// Update is called once per frame
	void Update () {
		if (player.GetComponent<Health>().currentHealth <= 0) {
			Reset();
		}
		if (player.transform.position.y < bottomOfLevel.position.y) {
			Reset();
		}
        if(lives == 0)
        {
			livesText.enabled = false;	
            gameOverUI.SetActive(true);
            Time.timeScale = 0;
        }
		
		ammoText.text = "Ammo: " + player.GetComponent<PlayerMoveScript>().ammo;
		
	}
	
	void Reset() {
		player.transform.position = spawnPosition.position;
		player.GetComponent<Health>().currentHealth = player.GetComponent<Health>().maxHealth;
		lives--;
		livesText.text = "Lives: " + lives;
	}
	
	public void IncreaseScore(int x) {
		score += x;
		scoreText.text = "Score: " + score;
	}
}
