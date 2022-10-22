using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TurnSettings : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TurnMethod(int turnSetting)
    {
        if (turnSetting == 0)
        {
            GetComponent<ActionBasedSnapTurnProvider>().enabled = true;
            GetComponent<ActionBasedContinuousMoveProvider>().enabled = false;
            GetComponent<ActionBasedContinuousTurnProvider>().enabled = false;
        }
        else if (turnSetting == 1)
        {
            GetComponent<ActionBasedSnapTurnProvider>().enabled = false;
            GetComponent<ActionBasedContinuousMoveProvider>().enabled = true;
            GetComponent<ActionBasedContinuousTurnProvider>().enabled = true;
        }
        else if (turnSetting == 2)
        {
            GetComponent<ActionBasedSnapTurnProvider>().enabled = false;
            GetComponent<ActionBasedContinuousMoveProvider>().enabled = false;
            GetComponent<ActionBasedContinuousTurnProvider>().enabled = false;
        }
    }
}
