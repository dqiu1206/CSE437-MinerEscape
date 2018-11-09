using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Health : MonoBehaviour {

	public float maxHealth = 100f;

	public TextMeshProUGUI text;
	
	private bool isInvincible = false;
	public float currentHealth;
    public Slider healthBar;
	
	// Use this for initialization
    void Start () {
		currentHealth = maxHealth;
		if (healthBar != null) {
			healthBar.value = currentHealth / maxHealth;
		}

	}
	
	// Update is called once per frame
	void Update () {
        if (healthBar != null) {
			healthBar.value = currentHealth / maxHealth;
		}
	}
	
	public void TurnOnInvincibility() {
		isInvincible = true;
	}
	
	public void TurnOffInvincibility() {
		isInvincible = false;
	}
	
	public void TakeDamage(float damage) {
		if (!isInvincible) {
			currentHealth -= damage;
			if (currentHealth <= 0) {
				currentHealth = 0;
			}
		}
	}
	
	
}
