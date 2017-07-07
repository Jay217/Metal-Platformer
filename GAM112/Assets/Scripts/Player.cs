using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour 
{	
	Rigidbody RB;
	public Text UIDisplay;
	//Player Stats
	int Lives = 3;
	int Movement = 50;
	int JumpMovement = 350;
	int DmgOut = 1;
	float PlayTime = 0f;

	//All status bools start false
	//Harmful Status bool list
	bool Asleep = false;
	bool Confused = false;
	bool Enraged = false;

	//Helpful Status bool list
	bool Deafened = false;
	bool MutualTaste = false;


	void Start () 
	{
		RB = GetComponent<Rigidbody> ();
		
	}
	

	void Update () 
	{
		//Logic for the UI, Display remaining lives and how long they've played
		PlayTime += Time.deltaTime;
		UIDisplay.text = "Lives Remaining: " + Lives + ", Time " + PlayTime;

		//Movement and attack Logic
		if (Input.GetKey (KeyCode.A)) 
		{
			RB.AddForce (Vector3.left * Movement);
		}

		else if (Input.GetKey (KeyCode.D)) 
		{
			RB.AddForce (Vector3.right * Movement);
		}

		if (Input.GetKeyDown (KeyCode.W)) 
		{
			RB.AddForce (Vector3.up * JumpMovement);
		}

		if (Input.GetKey (KeyCode.E)) 
		{
			//Add Throw metal ball logic
		}

		if (Input.GetKey (KeyCode.Q))
		{
			//Add Punch logic
		}

		//Stop player from moving if asleep
		while (Asleep == true)
		{
			Movement = 0;
		}

		//reverse controls when confused
		while (Confused == true) 
		{
			if (Input.GetKey (KeyCode.A)) {
				RB.AddForce (Vector3.right * Movement);
			}

			else if (Input.GetKey (KeyCode.D)) {
				RB.AddForce (Vector3.left * Movement);
			}
				
			if (Input.GetKeyDown (KeyCode.S)) 
			{
				RB.AddForce (Vector3.up * JumpMovement);
			}

			if (Input.GetKey (KeyCode.Q)) 
			{
				//Add Metal Ball logic
			}
					
		}

		//Constant moving while enraged
		while (Enraged == true) 
		{
			
		}

		//Disable all other statuses while deafened
		while (Deafened == true) 
		{
			Asleep = false;
			Confused = false;
			Enraged = false;
			MutualTaste = false;
		}

		//Double damage output while mutual taste is true
		while (MutualTaste == true) 
		{
			DmgOut = 2;			
		}

		//Load the lose screen when out of lives
		if (Lives == 0) 
		{
			SceneManager.LoadScene ("GameOverLose");	
		}
	}

	//If the player falls out of the world load the lose screen
	public void OnCollisionEnter (Collision Collision)
	{
		if (Collision.gameObject.tag == "Death") 
		{
			SceneManager.LoadScene ("GameOverLose");	
		}

		//if the player collides with an enemy lose a life
		if (Collision.gameObject.tag == "Enemy")
		{
				Lives -= 1;	
		}
	}
}
