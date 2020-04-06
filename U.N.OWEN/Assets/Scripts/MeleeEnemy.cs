using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    private GameObject player;
    public float step = 0.1f;
    public float maxDist = 10f;

    private int direction = -1;
    private int moves = 0;

    public bool getAttacked = false;
    public float bounceSpeed = 1f;

    public int hp = 1;
    //
    public Animator animator;
    
    //

    // Start is called before the first frame update
    void Start()
    {
        //
        animator = GetComponent<Animator>();
        //
        player = GameObject.FindGameObjectWithTag("Player");
      
    }

    // Update is called once per frame
    void Update()
    {
        

         animator.SetFloat("x",  player.transform.position.x - transform.position.x);
         animator.SetFloat("y",  player.transform.position.y - transform.position.y);
        //
        if (getAttacked == true) GetAttacked();
        else
        {
            float dist = Vector2.Distance(transform.position, player.transform.position);

            if (dist < maxDist) transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step / 5 * Time.deltaTime);
            else
            {
                moves += 1;
                transform.position = new Vector3(transform.position.x + direction * step * Time.deltaTime, transform.position.y, transform.position.z);

                if (moves >= 60)
                {
                    moves = 0;
                    direction = -direction;
                }
            }
        }

        Die();
    }


    void GetAttacked()
    {
        Debug.Log("Get Lost");
        int bounce_time = 0;

        while (bounce_time < 60)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, -bounceSpeed * Time.deltaTime);
            bounce_time += 1;
        }

        getAttacked = false;
    }

    void Die()
    {
        if (hp <= 0) Destroy(gameObject);
    }
}