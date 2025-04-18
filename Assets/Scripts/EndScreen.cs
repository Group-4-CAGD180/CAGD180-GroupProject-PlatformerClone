/*
 * Author: Wade Lawler
 * Date: 4/17/25
 * Last Modified: 4/17/25
 * Description: This script handles all the functionality of
 * the end screen, namely button prompts.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    /// <summary>
    /// This function will be called to load 
    /// the main game scene when the play button is clicked.
    /// </summary>
    public void PlayButtonPressed(int buildIndex)
    {
        print("Button was clicked");

        SceneManager.LoadScene(buildIndex);
    }

    /// <summary>
    /// This function will be called to quit
    /// the game when the quit button is pressed
    /// </summary>
    public void QuitButtonPressed()
    {
        print("Quit Game");
        Application.Quit();
    }
}
