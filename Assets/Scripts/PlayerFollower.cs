using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    public Player playerObj;
    public bool isSpinning;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        isSpinning = playerObj.isSpinning;
        if (isSpinning == true) {
            Vector3 currentPosition = transform.position;
            currentPosition.z = -12;
        }
    }

}