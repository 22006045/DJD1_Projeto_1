using UnityEngine;

public class Player : Character
{
    [SerializeField]
    public float       moveSpeed ;
    [SerializeField]
    private float       jumpSpeed = 100.0f;
    [SerializeField]
    private float       maxJumpTime = 0.1f;
    [SerializeField]
    private int         maxJumps = 1;
    [SerializeField]
    private int         jumpGravityStart = 1;
    [SerializeField]
    AudioSource         jumpSound;
    [SerializeField]
    AudioSource         footstep;
    [SerializeField]
    AudioSource         secondfootstep;
   
  
    
    private float           hAxis;
    private int             nJumps;
    private float           timeOfJump;

    

    void FixedUpdate()
    {
        if (canMove)
        {
            rb.velocity = new Vector2(hAxis * moveSpeed, rb.velocity.y);
        }
    }

    protected override void Update()
    {
        hAxis = Input.GetAxis("Horizontal");

        bool isGround = IsGround();

        if ((isGround) && (Mathf.Abs(rb.velocity.y) < 0.1f))
        {
            nJumps = maxJumps;
        }

        Vector2 currentVelocity = rb.velocity;

        if ((Input.GetButtonDown("Jump")) && (nJumps > 0) && IsGround())
        {
            currentVelocity.y = jumpSpeed;

            rb.velocity = currentVelocity;

            nJumps--;

            rb.gravityScale = jumpGravityStart;

            timeOfJump = Time.time;

            jumpSound.pitch = Random.Range(1.0f, 1.2f);
            jumpSound.Play();
        }
        else 
        {
            float elapsedTimeSinceJump = Time.time - timeOfJump;
            if ((Input.GetButton("Jump")) && (elapsedTimeSinceJump < maxJumpTime))
            {
                rb.gravityScale = jumpGravityStart;
            }
            else
            {
                rb.gravityScale = 5.0f;
            }
        
        }

      
        
       



        TurnTo(-currentVelocity.x);

        animator.SetFloat("AbsSpeedX", Mathf.Abs(currentVelocity.x));
        animator.SetFloat("SpeedY", currentVelocity.y);
        //animator.SetBool("OnGround", isGround);

       

        base.Update();
    }

    protected override void OnDeath()
    {
        GameMng gameManager = FindObjectOfType<GameMng>();
        gameManager.BackToMainMenu(2);
    }
    
    protected void Footstep()
    {
        footstep.Play();
    }

}
