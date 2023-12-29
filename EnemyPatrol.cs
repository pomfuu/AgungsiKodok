using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Transform[] patrolPoints;
    private int currentPoint;

    public float moveSpeed;
    public float timeAtPoints;
    private float waitCounter;
    private Animator anim;
    public EnemyController theEC;
    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform t in patrolPoints)
        {
            t.SetParent(null);
        }
        waitCounter = timeAtPoints;
        anim = GetComponent<Animator>();
        anim.SetBool("isMoving", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (theEC.isDefeated == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, patrolPoints[currentPoint].position, moveSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, patrolPoints[currentPoint].position) < .001f)
            {
                waitCounter -= Time.deltaTime;
                anim.SetBool("isMoving", false);
                if (waitCounter <= 0)
                {
                    currentPoint++;
                    if (currentPoint >= patrolPoints.Length)
                    {
                        currentPoint = 0;
                    }
                    waitCounter = timeAtPoints;
                    anim.SetBool("isMoving", true);
                    if (transform.position.x < patrolPoints[currentPoint].position.x)
                    {
                        transform.localScale = new Vector3(-1f, 1f, 1f);
                    }
                    else
                    {
                        transform.localScale = Vector3.one;
                    }
                }
            }
        }
    }
}
