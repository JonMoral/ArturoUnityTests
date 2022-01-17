using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnterManager : MonoBehaviour
{

    [SerializeField] private CustomBoolean triggerCheck;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other) 
    {
        Debug.Log("Collided with wall");
        triggerCheck.wall = true;
    }
}
