using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathdraw : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] listPoint;
    public int startAt = 0;
    public int DirectionMove = 0;
    public void OnDrawGizmos()
    {
        if (listPoint.Length >= 2)
        {
            for (int i = 1; i < listPoint.Length; i++)
            {
                Gizmos.DrawLine(listPoint[i - 1].position, listPoint[i].position);
            }
        }
        else
        {
            return;
        }

    }
    public Transform getPointAt(int p)
    {
        return listPoint[p];
    }
    public Transform getPointNext()
    {
        if (startAt == 0)
        {
            DirectionMove = 1;
        }
        else if (startAt == listPoint.Length - 1)
        {
            DirectionMove = -1;
        }
        startAt += DirectionMove;
        return listPoint[startAt];
    }
}
