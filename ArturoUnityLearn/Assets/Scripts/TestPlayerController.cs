using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TestPlayerController : MonoBehaviour
{
    private float _num;
    public Transform spawnPoint;
    // Start is called before the first frame update
    public Vector3 movementVector;
    public float vectorScalar = 1;
    public bool shoot = false;

    public List<Transform> balls;
    private Transform currentBall;
    private int currentIndex;

    public float disableTimer;
    private int previousIndex;

    [SerializeField] private CustomBoolean triggercheck;

    void Start()
    {
        movementVector = new Vector3(0, 0, 0.01f);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(triggercheck.wall)
        {
            shoot = false;
            Shooter();
        }

        MoveBall(currentBall);
    }

    void Shooter()
    {
        //Transform currentBall = ball;
        if (Input.GetKeyDown(KeyCode.Space))
        {   
            //StopAllCoroutines();
            previousIndex = currentIndex -1;
            if (previousIndex < 0)
                previousIndex = balls.Count -1;

            shoot = true;
            currentBall = balls[currentIndex];
            currentBall.position = spawnPoint.position;

            StartCoroutine(DisableBall());
            currentBall.gameObject.SetActive(true);

            if (currentIndex < balls.Count - 1)
            {
                currentIndex++; 
            }
            else
            {   
                currentIndex = 0;
            } 
            triggercheck.wall = false;
        }
        //if (currentBall == null)
    }

    void MoveBall (Transform b)
    {
        if (shoot)
            b.position += movementVector * vectorScalar;
    }

    IEnumerator DisableBall()
    {
        yield return new WaitForSeconds(disableTimer);
        balls[previousIndex].gameObject.SetActive(false);
    }

}
