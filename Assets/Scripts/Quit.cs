/* Shaw Eva
* 6/12/24 
*Quits the scene :)*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quit : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit(); //Quits the game (only works in build)
    }
}
