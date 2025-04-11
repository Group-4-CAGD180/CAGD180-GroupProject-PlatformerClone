/*
 * Author: Wade Lawler
 * Date Created: 4/11/25
 * Last Modified: 4/11/25
 * Description: This script handles the moving of the camera
 * vertically depending on the platform heights
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeightCube : MonoBehaviour
{
    public GameObject cameraCube;

    public int Height;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Transform cameraTransform = cameraCube.GetComponent<Transform>();

            cameraTransform.position = new Vector3(0, Height, 8);
        }
    }
}
