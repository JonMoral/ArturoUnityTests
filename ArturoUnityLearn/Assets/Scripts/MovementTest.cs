using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTest : MonoBehaviour
{
    // Start is called before the first frame update

    public bool moveRight = true;
    public Transform targets;

    public Vector3 movementVector;
    public float vectorScalar;

    private void Awake() 
    {
        
    }

    void Start()
    {
        targets = this.gameObject.transform;
        movementVector = new Vector3(0.01f, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(moveRight)
        {
            targets.position += movementVector * vectorScalar;
            
            if (targets.position.x >= 1)
            {
                moveRight = false;
            }
        }
        if(!moveRight)
        {
            targets.position -= movementVector * vectorScalar;
            
            if (targets.position.x <= -1)
            {
                moveRight = true;
            }
        }
    }
}
