using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float FlapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;
    public AudioSource swoosh;
    public AudioSource dead;
    public int deadctr = 0;
    public AudioSource hit;
    public int collisionCtr = 0;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
 
    }

    // Update is called once per frame
    void Update()
    {
        logic.DisplayHighScore();
        if(Input.GetKeyDown(KeyCode.Space) == true && birdIsAlive == true)
        {
        myRigidBody.velocity = Vector2.up * FlapStrength;
            swoosh.Play();

        }
        if(transform.position.y >19  || transform.position.y < -19)
        {
            logic.gameOver();
            birdIsAlive = false;
            logic.SaveHighScore();
            if(deadctr == 0)
            {
            dead.Play();
                deadctr++;

            }
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        if(collisionCtr == 0)
        {
            hit.Play();
            collisionCtr++;
        }
        birdIsAlive = false;
        logic.SaveHighScore();
        if(deadctr == 0)
        {
        dead.Play();
            deadctr++;

        }
    }
}
