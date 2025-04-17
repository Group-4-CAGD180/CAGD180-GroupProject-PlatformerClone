/*
 * Author: Wade Lawler
 * Date Created: 4/3/25
 * Last Modified: 4/15/25
 * Description: This script handles player functionality, such as input,
 *              movement, respawning, etc.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // respawning variables
    // holds player lives
    public int lives = 3;
    public int fallDepth;
    private Vector3 startPosition;

    //total player score
    public float totalScore = 0;

    //jump force added when the player presses space
    public float jumpForce = 8f;

    //rigidbody which we will eventually add force to
    private new Rigidbody rigidbody;

    // speed for the player to move left and right
    public float speed = 10f;

    //Arms for the model
    public GameObject leftArm;
    public GameObject rightArm;

    //The player's camera
    public GameObject cameraCube;
    public int height;

    //The player's colors
    public Material green;
    public Material red;

    //The time player's spin attack will last
    public float spinTimer;
    public float spinCooldown;
    public bool canSpin = true;
    // If the player is spinning or not
    public bool isSpinning = false;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        rigidbody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {       

        SpaceJump();
        Move();
<<<<<<< HEAD
=======
        SpinAttack();
        StompBounce();
        if (isSpinning == true)
        {
            transform.Rotate(0, 3, 0);
        }
>>>>>>> 54e70b06d75510d943545fc425f874d485226b2f
    }

    /// <summary>
    /// Allows the player to jump using the space key. As long as it is touching the ground.
    /// </summary> 
    private void SpaceJump()
    {
        //handles jumping
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RaycastHit hit;
            //if the raycast returns true then an object has been hit and the player
            //is touching the floor
            //For Raycast(startPosition, RayDirection, output the object hit, maximumDistanceForTheRaycastToFire)
            if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.5f))
            {
                Debug.Log("Touching the ground");

                //adds an upwards velocity to the player object causing the player to jump up
                rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
            else
            {
                Debug.Log("Can't jump, not touching the ground");
            }
        }
    }

    /// <summary>
    /// This function handles player movement inputs and if the player falls
    /// off the level
    /// </summary>
    private void Move()
    {
        Vector3 add_position = Vector3.zero;

        //if the player inputs the a key, go left
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            add_position += Vector3.left * Time.deltaTime * speed;
        }

        //if the player inputs the d key, go right
        if (Input.GetKey("d"))
        {
            add_position += Vector3.right * Time.deltaTime * speed;
        }

        //if the player inputs the w key, go forward
        if (Input.GetKey("w"))
        {
            add_position += Vector3.forward * Time.deltaTime * speed;
        }

        //if the player inputs the w key, go forward
        if (Input.GetKey("s"))
        {
            add_position -= Vector3.forward * Time.deltaTime * speed;
        }

        //if the player inputs the e key, spin attack
        if (Input.GetKeyDown("e") && canSpin == true)
        {
            StartCoroutine(SpinAttack());
        }

        transform.position += add_position;

        if (transform.position.y < fallDepth)
        {
            Respawn();
        }
    }

    /// <summary>
    /// This function respawns the player upon being called
    /// </summary>
    private void Respawn()
    {
        transform.position = startPosition;
        lives--;
        //reset Camera
        Transform cameraTransform = cameraCube.GetComponent<Transform>();

        cameraTransform.position = new Vector3(0, height, 8);

        if (lives <= 0)
        {
            this.enabled = false;
            SceneManager.LoadScene(2);
        }
    }
<<<<<<< HEAD
=======
    //Applies force to the player upward when stomping on a Simple Enemy
    private void StompBounce()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 1f))
        {
            if (hit.collider.tag == "SimpleEnemy")
            {
                rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                print("StompExecuted");
            }
        }
    }


    /// <summary>
    /// This function handles player spin attack
    /// </summary>
       IEnumerator SpinAttack()
    {

        
        isSpinning = true;

        //move arms into position and spin
         Transform leftArmTransform = leftArm.GetComponent<Transform>();
        leftArmTransform.rotation = Quaternion.Euler(0, 0, -90);

        Transform rightArmTransform = rightArm.GetComponent<Transform>();
        rightArmTransform.rotation = Quaternion.Euler(0, 0, 90);

        //turn player red
        GetComponent<Renderer>().material = red;
            leftArm.GetComponent<Renderer>().material = red;
        rightArm.GetComponent<Renderer>().material = red;

        //wait for timer to end, then reset the player to default
        yield return new WaitForSeconds(spinTimer);
        isSpinning = false;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        //go back to default color
        GetComponent<Renderer>().material = green;
        leftArm.GetComponent<Renderer>().material = green;
        rightArm.GetComponent<Renderer>().material = green;
        //reset arms
        leftArmTransform.rotation = Quaternion.Euler(0, 0, -36);
        rightArmTransform.rotation = Quaternion.Euler(0, 0, 36);
        //start cooldown till player can spin again
        StartCoroutine(SpinCooldown());
    }

    /// <summary>
    /// This function prevents the player from spamming the spin button
    /// </summary>
    /// <returns></returns>
    IEnumerator SpinCooldown()
    {
        canSpin = false;
        yield return new WaitForSeconds(spinCooldown);
        canSpin = true;
    }



>>>>>>> 54e70b06d75510d943545fc425f874d485226b2f
    /// <summary>
    /// This function handles collisions with most objects in the game
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            //if the object colliding is tagged as "Coin"
           // totalScore += coinValue;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Spike")
        {
            //if the object colliding is tagged as "Spike", respawn
            Respawn();
        }
        else if (other.gameObject.tag == "SimpleEnemy")
        {
            //if the object colliding is tagged as "Enemy", respawn
            Respawn();
        }
        else if (other.gameObject.tag == "BulletBill")
        {
            Respawn();
        }
        else if (other.gameObject.tag == "Laser")
        {
         //   StartCoroutine(Stun());
        }
        else if (other.gameObject.tag == "UpCube")
        {

        }
        else if (other.gameObject.tag == "Portal")
        {
            //if the object colliding is tagged as "Portal", teleport player
            //to next area

            //restart the startPos to the spawnPoint position
          //  startPosition = other.gameObject.GetComponent<Portal>().spawnPoint.transform.position;
            //bring the player to the startPos
            transform.position = startPosition;
        }
    }
}
