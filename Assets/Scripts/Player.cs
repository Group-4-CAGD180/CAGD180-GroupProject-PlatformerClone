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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
