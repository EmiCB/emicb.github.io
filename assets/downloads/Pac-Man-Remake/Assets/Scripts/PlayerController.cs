using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// + = Add
/// - = Remove
/// 
/// NOTES:
/// + continuous movement
/// + animations
/// + sounds
/// 
/// DONT FORGET TO FIX AND UNCOMMENT TIME

public class PlayerController : MonoBehaviour
{
	
// Public allows you to change varriables using the Unity inspector
	//Sets speed and gravity
    public float speed = 6.0F;
    public float gravity = 20.0F;
	// Time that power pellet is effective
	public float eatTime = 1.0F;
	public float timer;

    // Sets integers
    private int score = 0;
	private int lives = 3;
	// Sets ghosts eaten
	private int ghostsEaten = 0;
	// Sets a number of deaths
	//private int deaths = 0;

	// Sets texts
	public Text scoreText;
	public Text livesText;
	public Text restartText;

	// Sets booleans
	private bool powerPelletActive;
	private bool gameOver;
	private bool restart;
	private bool wait;

	// Sounds
	private AudioSource deathSound; 

    IEnumerator Start()
	{
		// Sets gameOver to false
		gameOver = false;
		// Sets restart to flase
		restart = false;
		// Sets powerPelletActive to flase
		powerPelletActive = false;
		// Sets wait to true
		wait = true;
        // Sets the score to zero
        score = 0;
		// Sets the lives to 3
		lives = 3;
		// Sets time to 11
		timer = 1.1F;
        // Displays your current score
        scoreText.text = "Score: " + score.ToString();
		// Displays your current lives
		livesText.text = "Lives: " + lives.ToString();

		deathSound = GetComponent<AudioSource>();

		// Waits for 5 seconds
		yield return new WaitForSeconds(5);
		wait = false;
    }

    //Movement using the Player Controller component in Unity
    private Vector3 moveDirection = Vector3.zero;

    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
		if (controller.isGrounded && wait == false)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
            moveDirection *= speed;

            //Locks direction the player is facing so that it matches the direction the player is moving
            if (Input.GetKeyDown(KeyCode.UpArrow))
                transform.forward = new Vector3(1f, 0f, 0f); //Faces North when UpArrow is pressed
            else if (Input.GetKeyDown(KeyCode.DownArrow))
                transform.forward = new Vector3(-1f, 0f, 0f); //Faces South when DownArrow is pressed
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
                transform.forward = new Vector3(0f, 0f, 1f); //Faces West when LeftArrow is pressed
            else if (Input.GetKeyDown(KeyCode.RightArrow))
                transform.forward = new Vector3(0f, 0f, -1f); //Faces East when RightArrow is pressed
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

		if (lives == 0) 
		{
			GameOver ();
		}

		if (gameOver == true) 
		{
			restartText.text = "Press 'R' For Restart";
			restart = true;
		}
    }

    // When the game object touches something
    void OnTriggerEnter(Collider other)
	{
		// Score system:
		// Picks up certain game objects with the "Pellet" tag
		if (other.gameObject.CompareTag ("Pellet")) 
		{
			other.gameObject.SetActive (false);

			// Adds 10 points to your score
			score = score + 10;

			// Displays your current score
			scoreText.text = "Score: " + score.ToString ();
		}

		// Picks up certain game objects with the "PowerPellet" tag
		if (other.gameObject.CompareTag ("PowerPellet")) 
		{
			other.gameObject.SetActive (false);

			// Adds 50 points to your score
			score = score + 50;

			// Displays your current score
			scoreText.text = "Score: " + score.ToString ();

			// Starts timer & sets stuff
			powerPelletActive = true;
			timer = 0.0F;
			ghostsEaten = 0;

			// DO NOT USE A WHILE LOOP
			// Timer
			if (powerPelletActive == true && timer <= eatTime) 
			{
				Debug.Log (timer);

				timer += Time.deltaTime;

				Debug.Log (timer);
			}
			else 
			{
				powerPelletActive = false;
			}
		}

		// Picks up certain game objects with the "Cherry" tag
		if (other.gameObject.CompareTag ("Cherry")) 
		{
			other.gameObject.SetActive (false);

			// Adds 100 points to your score
			score = score + 100;

			// Displays your current score
			scoreText.text = "Score: " + score.ToString ();
		}

		// Picks up certain game objects with the "Strawberry" tag
		if (other.gameObject.CompareTag ("Strawberry")) 
		{
			other.gameObject.SetActive (false);

			// Adds 300 points to your score
			score = score + 300;

			// Displays your current score
			scoreText.text = "Score: " + score.ToString ();
		}

		// Picks up certain game objects with the "Orange" tag
		if (other.gameObject.CompareTag ("Orange")) 
		{
			other.gameObject.SetActive (false);

			// Adds 500 points to your score
			score = score + 500;

			// Displays your current score
			scoreText.text = "Score: " + score.ToString ();
		}

		// Picks up certain game objects with the "Apple" tag
		if (other.gameObject.CompareTag ("Apple")) 
		{
			other.gameObject.SetActive (false);

			// Adds 700 points to your score
			score = score + 700;

			// Displays your current score
			scoreText.text = "Score: " + score.ToString ();
		}

		// Picks up certain game objects with the "Pineapple" tag
		if (other.gameObject.CompareTag ("Pineapple")) 
		{
			other.gameObject.SetActive (false);

			// Adds 1000 points to your score
			score = score + 1000;

			// Displays your current score
			scoreText.text = "Score: " + score.ToString ();
		}

		// Picks up certain game objects with the "Galaxian Spaceship" tag
		if (other.gameObject.CompareTag ("Galaxian Spaceship")) 
		{
			other.gameObject.SetActive (false);

			// Adds 2000 points to your score
			score = score + 2000;

			// Displays your current score
			scoreText.text = "Score: " + score.ToString ();
		}

		// Picks up certain game objects with the "Bell" tag
		if (other.gameObject.CompareTag ("Bell")) 
		{
			other.gameObject.SetActive (false);

			// Adds 3000 points to your score
			score = score + 3000;

			// Displays your current score
			scoreText.text = "Score: " + score.ToString ();
		}

		// Picks up certain game objects with the "Key" tag
		if (other.gameObject.CompareTag ("Key")) 
		{
			other.gameObject.SetActive (false);

			// Adds 5000 points to your score
			score = score + 5000;

			// Displays your current score
			scoreText.text = "Score: " + score.ToString ();
		}

		//Ghost interactions
		if (other.gameObject.CompareTag ("Ghost"))
		{
			// Death
			if (powerPelletActive == false) 
			{
				this.gameObject.SetActive (false);

				deathSound.Play();

				lives = lives - 1;

				livesText.text = "Lives: " + lives.ToString ();
			}
			// Eat ghosts
			else if (powerPelletActive == true) 
			{
				if (timer <= eatTime) 
				{
					if (ghostsEaten == 0) 
					{
						// Adds 200 points to your score
						score = score + 200;

						// Displays your current score
						scoreText.text = "Score: " + score.ToString ();

						// Gets rid of other gameobject
						other.gameObject.SetActive (false);

						// Adds 1 to ghosts eaten
						ghostsEaten = ghostsEaten + 1;
					} 
					else if (ghostsEaten == 1) 
					{
						// Adds 400 points to your score
						score = score + 400;

						// Displays your current score
						scoreText.text = "Score: " + score.ToString ();

						// Gets rid of other gameobject
						other.gameObject.SetActive (false);

						// Adds 1 to ghosts eaten
						ghostsEaten = ghostsEaten + 1;
					} 
					else if (ghostsEaten == 2) 
					{
						// Adds 800 points to your score
						score = score + 800;

						// Displays your current score
						scoreText.text = "Score: " + score.ToString ();

						// Gets rid of other gameobject
						other.gameObject.SetActive (false);

						// Adds 1 to ghosts eaten
						ghostsEaten = ghostsEaten + 1;
					} 
					else if (ghostsEaten == 3) 
					{
						// Adds 1600 points to your score
						score = score + 1600;

						// Displays your current score
						scoreText.text = "Score: " + score.ToString ();

						// Gets rid of other gameobject
						other.gameObject.SetActive (false);

						// Resets ghosts eaten
						ghostsEaten = 0;
					}
				}
				else 
				{
					powerPelletActive = false;
				}
			}
		}
    }

	public void GameOver()
	{
		gameOver = true;
	}
}