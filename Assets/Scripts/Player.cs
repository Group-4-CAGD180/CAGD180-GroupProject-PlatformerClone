/*
 * Author: Wade Lawler
 * Date Created: 4/3/25
 * Last Modified: 4/3/25
 * Description: This script handles player functionality, such as input,
 *              movement, respawning, etc.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // respawning variables
    // holds player lives
    public int lives = 3;
    public int fallDepth;
    private Vector3 startPosition;

    //jump force added when the player presses space
    public float jumpForce = 8f;

    //rigidbody which we will eventually add force to
    private Rigidbody rigidbody;

    // speed for the player to move left and right
    public float speed = 10f;


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
        if (Input.GetKey("a"))
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

        transform.position += add_position;

        if (transform.position.y < fallDepth)
        {
            
        }
    }
}
