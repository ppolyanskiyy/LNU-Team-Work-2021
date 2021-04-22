using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWall : MonoBehaviour
{
    private bool moveTime = false;
    public Transform endPoint;

    public FlameThrower fire1;
    public FlameThrower fire4;
    public FlameThrower fire2;
    public FlameThrower fire3;

    void Update()
    {
        if (moveTime == true && transform.position != endPoint.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPoint.position, Time.deltaTime);
        }
        else if (transform.position == endPoint.position)
        {
            Dest();
            fire1.Nost(1000);
            fire2.Nost(1000);
            fire3.Nost(1000);
            fire4.Nost(1000);
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
