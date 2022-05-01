// Aditya
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneSwitch : MonoBehaviour
{
    int runnerPosition;

    /* runner positions
     * 0. Left
     * 1. Mid(default)
     * 2. Right
     */


    // Start is called before the first frame update
    void Start()
    {
        runnerPosition = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // Press D to move Right
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (runnerPosition < 2)
            {
                // moves position by 4
                transform.position = new Vector3(transform.position.x + 4.0f, transform.position.y, transform.position.z);
                //transform.Translate(4, 0, 0);
                runnerPosition++;
            }
        }

        // Press A to move Left
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (runnerPosition > 0)
            {
                // moves position by 4
                transform.position = new Vector3(transform.position.x - 4.0f, transform.position.y, transform.position.z);
                //transform.Translate(4, 0, 0);
                runnerPosition--;
            }
        }

    }
}
