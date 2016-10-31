using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour
{

   public bool PauseGame = false;

    void Update()
    {

        if (PauseGame == false)
        {
            Time.timeScale = 1;
        }

        else
        {
            Time.timeScale = 0;
        }


        if (Input.GetKey(KeyCode.P))
        {
            if (PauseGame == true)
            {
                PauseGame = false;
            }

            else
            {
                PauseGame = true;
            }
        }


    }


}
