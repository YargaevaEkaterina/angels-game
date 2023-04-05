using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public Transform target;
    public float speed = 4f;
    private Vector3 _position;

    // Start is called before the first frame update
    void Start()
    {
      _position = target.InverseTransformPoint(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        var currentPosition = target.TransformPoint(_position);
        transform.position = Vector3.Lerp(transform.position, currentPosition, speed * Time.deltaTime);
        var currentRotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, currentRotation, speed * Time.deltaTime);
    }
}
