using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float dirHorizontal, dirVertical;
    public float speed = 5f;

    public Animator anim;
    //Edited
    private Vector2 direction;
    private Vector2 moveVelocity;
    private Rigidbody2D rb;
    //
    public static bool playerLocked = false;

    private int playerDirection = 0;

    public GameObject Bullet;

    private bool isWalking = false;
    public AudioSource walkSound;
    public GameObject gunSound;

    private int attackDelay = 0;

    // Start is called before the first frame update
    void Start()
    {
        //Edited
        direction = Vector2.zero;//face forward.
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) playerDirection = 1;
        else if (Input.GetKeyDown(KeyCode.D)) playerDirection = 2;
        else if (Input.GetKeyDown(KeyCode.S)) playerDirection = 3;
        else if (Input.GetKeyDown(KeyCode.A)) playerDirection = 4;


        if (playerLocked == false)
        {
            dirHorizontal = Input.GetAxisRaw("Horizontal");
            dirVertical = Input.GetAxisRaw("Vertical");
            Vector2 moveInput = new Vector2(dirHorizontal, dirVertical);
            moveVelocity = moveInput * speed;

            if (dirVertical == 1)
            {
                direction = Vector2.up;
            }
            else if (dirVertical == -1)
            {
                direction = Vector2.down;
            }
            else if (dirHorizontal == 1)
            {
                direction = Vector2.right;
            }
            else if (dirHorizontal == -1)
            {
                direction = Vector2.left;
            }
            else
            {
                direction = Vector2.zero;
            }

            PlayerAttack();
            WalkSound();
        }

        //Edited
        if (direction.x != 0 || direction.y != 0)
        {
            AnimateMovement(direction);
        }
        else
        {//set back to layer 0
            anim.SetLayerWeight(2, 0);
            anim.SetLayerWeight(1, 0);
            anim.SetLayerWeight(0, 1);

        }
        //
    }
    //
    public void AnimateMovement(Vector2 direction)
    {
        //we have three layers!
        //standing, walking and stay home

        anim.SetLayerWeight(1, 1);//first 1 for layer 1, second for weight 1
                                  //animator.SetLayerWeight(0, 0);
        anim.SetLayerWeight(2, 0);

        anim.SetFloat("x", direction.x);
        anim.SetFloat("y", direction.y);

    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);

    }
    //
    void PlayerAttack()
    {
        if (Input.GetMouseButtonDown(0) && attackDelay == 0)
        {
            // Instantiate a bullet
            GameObject created_bullet = Instantiate(Bullet, gameObject.transform.position, Quaternion.identity) as GameObject;
            created_bullet.GetComponent<Bullet>().direction = playerDirection;

            if (!gunSound.GetComponent<AudioSource>().isPlaying)
            {
                gunSound.GetComponent<AudioSource>().Play();
            }

            attackDelay += 1;
        }

        if (attackDelay > 0) attackDelay += 1;
        if (attackDelay >= 80)
        {
            attackDelay = 0;
        }
    }

    void WalkSound()
    {
        isWalking = (dirHorizontal != 0 || dirVertical != 0);

        if (isWalking)
        {
            if (!walkSound.isPlaying)
            {
                walkSound.Play();
            }
        }
        else walkSound.Stop();
    }
}

