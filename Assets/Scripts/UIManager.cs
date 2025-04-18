/*
 * Name: Wade Lawler
 * Date: 4/15/25
 * Last Modified: 4/17/25
 * Description: This script handles all the Ui within the game, such as Wumpa Fruit count
 *              and player lives
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{

    public Player player;
    public TMP_Text wumpaText;
    public TMP_Text livesText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        wumpaText.text = "Wumpa fruit: " + player.totalWumpaCount;
        livesText.text = "Lives: " + player.lives;
    }
}

