using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   
    public AudioClip deathSound;

    private AudioSource audioSource;

    [SerializeField]
    private int jumpForce;

    [SerializeField]
    private Rigidbody2D myBody;

    private Animator anim;

    private SpriteRenderer sr;

    private bool IsDead;

    private string DIE_ANIMATION = "IsDead";

    private float soma;
    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {     
        PlayerJump();
        AnimatePlayer();
        //Debug.Log(myBody.velocity);
    }

    private void PlayerJump()
        {
            if (Input.GetButtonDown("Jump"))
            {
                //myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                myBody.velocity = Vector2.up * jumpForce;
            }
        }
    
    private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Wall"))
            {             
                IsDead = true;
                audioSource.PlayOneShot(deathSound);
            }

        }

    private void AnimatePlayer()
    {
        if (IsDead == true)
        {
            anim.SetBool(DIE_ANIMATION, true);
            myBody.constraints = RigidbodyConstraints2D.FreezePositionY;           
        }
       
        if (myBody.velocity.y > 0)
            transform.eulerAngles = new Vector3(0f, 0f, 320);

        else
            transform.Rotate(0, 0, myBody.velocity.y/20);
            Debug.Log(transform.eulerAngles);
            if (transform.eulerAngles.z < 230 )
            {
                transform.eulerAngles = new Vector3(0f, 0f, 230);
                Debug.Log("iff");
            }        
    }

    private void Die()
    {          
        Destroy(gameObject);
        GameManager.instance.PlayerDied();        
    }
    
}
