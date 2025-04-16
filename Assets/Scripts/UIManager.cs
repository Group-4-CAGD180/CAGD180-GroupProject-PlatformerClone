/*
 * Name: Wade Lawler
 * Date: 4/15/25
 * Last Modified: 4/15/25
 * Description: This script handles all the Ui within the game, such as score
 *              and player lives
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{

    public Player playerMove;
    public TMP_Text scoreText;
    public TMP_Text livesText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + playerMove.totalScore;
        livesText.text = "lives: " + playerMove.lives;
    }
}

