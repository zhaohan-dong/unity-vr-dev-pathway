using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReticleSquare : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * 10 * Time.deltaTime, Space.World);
    }
}
