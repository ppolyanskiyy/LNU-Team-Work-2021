using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWall : MonoBehaviour
{
    private bool moveTime = false;
    public Transform endPoint;

    void Update()
    {
        if (moveTime == true && transform.position != endPoint.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPoint.position, Time.deltaTime);
        }
        else if (transform.position == endPoint.position)
        {
            Dest();
        }
    }
    public void Move()
    {
        moveTime = true;
    }
    public void Dest()
    {
        Destroy(gameObject);
    }
}
