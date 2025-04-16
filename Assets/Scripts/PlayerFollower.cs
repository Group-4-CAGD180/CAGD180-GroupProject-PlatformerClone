using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    public int speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
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
    }
}
