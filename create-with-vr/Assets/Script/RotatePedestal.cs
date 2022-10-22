using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePedestal : MonoBehaviour
{
    private Transform trans;
    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Rotate(float rotation)
    {
        trans.eulerAngles = new Vector3(0, rotation, 0);
    }
}
