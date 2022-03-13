using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundfollwPath : MonoBehaviour
{
    public Pathdraw ThePath;
    public float moveSpeed = 2f;
    private Transform _targetPoint;
    // Start is called before the first frame update
    void Start()
    {
        if (ThePath == null)
        {
            return;
        }
        transform.position=ThePath.getPointAt(0).position;
        _targetPoint = ThePath.getPointNext();
    }

    // Update is called once per frame
    void Update()
    {
        if (ThePath == null)
        {
            return;
        }
        transform.position = Vector3.MoveTowards(transform.position, _targetPoint.position, moveSpeed * Time.deltaTime);
        //tính khoảng cách
        var distaintTarget=(transform.position-_targetPoint.position).sqrMagnitude;
        if(distaintTarget < 0.1f)
        {
            _targetPoint = ThePath.getPointNext();
        }
    }
}
