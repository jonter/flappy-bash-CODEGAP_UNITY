using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeInput : MonoBehaviour
{
    PipeMover pm;
    // Start is called before the first frame update
    void Start()
    {
        pm = GetComponent<PipeMover>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            pm.Crush();
        if (Input.GetKeyDown(KeyCode.Space))
            pm.Crush();
        
    }
}
