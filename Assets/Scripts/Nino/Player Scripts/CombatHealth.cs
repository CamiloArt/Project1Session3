using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class CombatHealth : MonoBehaviour {

	public float startingHealth = 100;                            
	public float currentHealth;                                  
	public Slider healthSlider;
	public bool isDead;




	void Awake () 
	{
		currentHealth = startingHealth;
	}


	void Update()
	{

		healthSlider.value = currentHealth;

		if(currentHealth <= 0 && !isDead)
		{
			Death ();
		}
	}

	void Death ()
	{
		isDead = true;
	}

	public void ReceiveDamage(float damageTaken){
		currentHealth -= damageTaken;
	}

}
