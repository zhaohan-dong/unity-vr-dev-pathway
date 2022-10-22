using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotebookHinge : MonoBehaviour
{
    public GameObject Cover;
    private HingeJoint myHinge;

    // Start is called before the first frame update
    void Start()
    {
        var myHinge = Cover.GetComponent<HingeJoint>();
        myHinge.useMotor = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OpenBook()
    {
        myHinge.useMotor = true;
    }

    public void CloseBook()
    {
        myHinge.useMotor = false;
    }
}
