using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class space : MonoBehaviour
{
    public float jumpforce = 10f;
    public GameObject ground;
    private Rigidbody rb;
    public float offset;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //We are going to jump in the Y axis
        offset=(transform.position.y-ground.transform.position.y)+1;
    }
    void Update()
    {
        if(transform.position.y-ground.transform.position.y<offset)
        {
            if (Input.GetButtonDown("Jump"))
            {
                rb.AddForce(Vector3.up * jumpforce);
                
            }
         }
        
    }
    
}