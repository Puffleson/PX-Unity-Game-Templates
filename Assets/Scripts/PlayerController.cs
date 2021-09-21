using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    private Rigidbody2D m_Rigidbody;
    private Animator m_Animator;
    private enum State {idle, run, jump, fall}
    private State state = State.idle;
    private Collider2D m_Collider;
    [SerializeField] private LayerMask ground;
    [SerializeField] private LayerMask ladder;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 8f;
    public float maxHealth = 100f;
    private float currentHealth;
    private float score = 0f;
    private int currentKeyAmount = 0;

    //for live system
    public LivesSystem gameManagerLivesSystemScript;

    //for checkpoint reset system
    public CheckpointResetSystem gameManagerCheckpointSystemScript;

    //for ladder and rope system
    private float inputVertical;
    public float distance;
    public LayerMask whatIsLadder;
    private bool isClimbing;

    private float horizontalMove = 0f;
    private Vector3 velocity = Vector3.zero;
    private float m_MovementSmoothing = .05f;

    // Runs when the character object turns on
    private void Awake()
    {

        currentHealth = maxHealth;      // Set the current health as the maximum health to start
    }

    // Runs when the Scene starts
    private void Start()
    {
        SoundManagerScript.PlaySound("run");        // Play background music
        m_Rigidbody = GetComponent<Rigidbody2D>();      // Get the current object's Rigidbody2D component
        m_Animator = GetComponent<Animator>();      // Get the current object's Animator component
        m_Collider = GetComponent<Collider2D>();   // Get the current object's Collider2D component

    }

    // Runs once every frame
   private void Update()
   {

       horizontalMove = Input.GetAxisRaw("Horizontal");     // Get the player input for the X axis (left and right) - keyboard keys "A" and "D"
       getMovementKey(horizontalMove * Time.fixedDeltaTime);      // Calls getMovementKey() function and passes the input the user presses
       getState();      // Calls getState() function
       m_Animator.SetInteger("state", (int)state);      // Set the current state the player is current in "State {idle, run, jump, fall}"

       ladderAndropeSystem(); // Activating ladder System

    }

    // Uses the player input to move the character
    private void getMovementKey(float horizontalMove)
   {
        Vector3 targetVelocity = new Vector2(horizontalMove * 10f, m_Rigidbody.velocity.y);     //Calculates the new velocity that the player will use after the key is released
        // Runs if input is "A" meaning left
        if (horizontalMove < 0 && (state == State.run || state == State.idle))
       {
            m_Rigidbody.velocity = new Vector2(-speed,m_Rigidbody.velocity.y);      //  Move the player left
            m_Rigidbody.velocity = Vector3.SmoothDamp(m_Rigidbody.velocity, targetVelocity, ref velocity, m_MovementSmoothing);     //Smoothen the movement after the key is released
            transform.localScale = new Vector2(-1,1);       // Rotate the sprite to face left
       }
       else if (horizontalMove > 0 && (state == State.run || state == State.idle)) // Runs if input is "D" meaning right
        {
            m_Rigidbody.velocity = new Vector2(speed,m_Rigidbody.velocity.y);     // Move the player right
            m_Rigidbody.velocity = Vector3.SmoothDamp(m_Rigidbody.velocity, targetVelocity, ref velocity, m_MovementSmoothing);     //Smoothen the movement after the key is released
            transform.localScale = new Vector2(1,1);      // Rotate the sprite to face right
        }

       // Can only Jump when the "Spacebar" key is pressed and the player is touching the floor (Layer is Foreground layer)
        if (Input.GetButtonDown("Jump") && m_Collider.IsTouchingLayers(ground))
       {
            SoundManagerScript.PlaySound("jump");       // Play jump sound
            m_Rigidbody.velocity = new Vector2(m_Rigidbody.velocity.x, jumpForce);      // Moves the player object up at a certain jump force specified by the user
            state = State.jump;     // change the state to "Jump"
       }

        if (Input.GetButtonDown("Jump") && m_Collider.IsTouchingLayers(ladder))
        {
            SoundManagerScript.PlaySound("jump");       // Play jump sound
            m_Rigidbody.velocity = new Vector2(m_Rigidbody.velocity.x, jumpForce);      // Moves the player object up at a certain jump force specified by the user
            state = State.jump;     // change the state to "Jump"
        }

        if (horizontalMove < 0 && (state == State.jump || state == State.fall))
        {
            m_Rigidbody.velocity = new Vector2(-speed/2, m_Rigidbody.velocity.y);      //  Move the player left
            m_Rigidbody.velocity = Vector3.SmoothDamp(m_Rigidbody.velocity, targetVelocity, ref velocity, m_MovementSmoothing);     //Smoothen the movement after the key is released
            transform.localScale = new Vector2(-1, 1);       // Rotate the sprite to face left
        }
        else if (horizontalMove > 0 && (state == State.jump || state == State.fall)) // Runs if input is "D" meaning right
        {
            m_Rigidbody.velocity = new Vector2(speed/2, m_Rigidbody.velocity.y);     //slow speed in are for more control
            m_Rigidbody.velocity = Vector3.SmoothDamp(m_Rigidbody.velocity, targetVelocity, ref velocity, m_MovementSmoothing);     //Smoothen the movement after the key is released
            transform.localScale = new Vector2(1, 1);      // Rotate the sprite to face right
        }
    }

   private void getState()
   {
          // Only runs when the state is "Jump"
        if(state == State.jump)
        {
            // Runs when the velocity for the Y axis in going down
            if (m_Rigidbody.velocity.y < 0.1f)
            {
                state = State.fall;     // change the state to "Fall"
            }
        }
        else if(state == State.fall)  // Only runs when the state is "Fall"
        {
            // Runs when the player lands on the ground, touching layer "Floor"
            if (m_Collider.IsTouchingLayers(ground))
            {
                state = State.idle;     // change the state to "Idle"
            }
        }
        else if(Mathf.Abs(m_Rigidbody.velocity.x) > 2f)   // Only runs when the absolute value of horizontal velocity movement is higher than 2, indicating the player is running
        {
            state = State.run;      // change the state to "Run"
        }
        else  // When nothing is happening, the player is considered "Idle"
        {
            state = State.idle;     // change the state to "Idle"
        }
   }

    // Decreases the player's health value
    public void takeDamage(float damage)
    {
        // Decreases the player's current health by the damage value, if it is less than or equal to 0, player loses
        if ((currentHealth -= damage) <= 0)
        {

            gameManagerLivesSystemScript.deductLive(); //Calling deductLive function from LivesSystem Script of GameManager

            currentHealth = maxHealth; //Set health to full again

            gameManagerCheckpointSystemScript.resetPlayerAtStart(); //Calling resetPlayerAtStart function from CheckpointResetSystem Script of GameManager

            transform.localScale = new Vector2(1, 1); //player face to right

        }

        if (gameManagerLivesSystemScript.lives <= 0) //if lives are 0 or less than that then
        {
            PlayerPrefs.SetFloat("PlayerScore", score);     // Set global scene variable to use in Win and Lose Scenes
            SceneManager.LoadScene("loseScene");      // Change to lose screen

        }

    }

    private void ladderAndropeSystem()
    {

        //Ladder And Rope System "START"

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, distance, whatIsLadder); //getting the position{collider} and layer information of ladderORrope

        if (hitInfo.collider != null) //if collider is there on ladderORrope then
        {

            isClimbing = true; //set the isClimbing variable to "true" means it is climbing on the ladderORrope
            state = State.idle; //changing the player state to idle if it is not moving for better presentation

        }

        else
        {

            isClimbing = false; //set the isClimbing variable to "false" means it is not climbing on the ladderORrope

        }

        if (isClimbing == true) //if the isClimbing variable is "true" then
        {

            inputVertical = Input.GetAxisRaw("Vertical"); //Get the player input for the Y axis (up and down) - keyboard keys "W" and "S"
            m_Rigidbody.velocity = new Vector2(m_Rigidbody.velocity.x, inputVertical * speed); //Moves the player object up at a certain speed specified by the user
            m_Rigidbody.gravityScale = 0; //Set the RigidBody Gravity Scale to "0" so that player can easily climb on the ladderORrope

        }

        else
        {

            m_Rigidbody.gravityScale = 5; //Set the RigidBody Gravity Scale to "5" because player is not climbing the ladderORrope

        }
        //Ladder And Rope System "END"

    }

    // Returns player's current health to script that calls it
    public float getPlayerHealth()
    {
        return currentHealth;
    }


    // Increase current score value by the amount
    public float updateScore(float amount)
    {
        score += amount;    // current score = current score + amount

        //Debug.Log("PrefScore: " + PlayerPrefs.GetFloat("PlayerScore").ToString());
        return score;       // Return the score to Collectables script when called
    }

    // Increases the player's current health by amount
    public void healPlayerHealth(float amount)
    {
        // Only heals when the player is not full health
        if (currentHealth < maxHealth)
        {
            currentHealth += amount;    // current health = current health + amount
        }

    }

    // Returns the amount of keys the player current has collected
    public int getKeyAmount()
    {
        return currentKeyAmount;
    }

    // Increase the amount of keys the player has collected
    public void addKeyAmount()
    {
        currentKeyAmount += 1;
    }

    public float getScore()
    {
        return score;
    }
}
