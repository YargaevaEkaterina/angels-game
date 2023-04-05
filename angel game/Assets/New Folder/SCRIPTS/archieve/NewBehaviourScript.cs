using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Animator anim;
    private Rigidbody RiBody;
    public float speed = 50f;
    public float rotspeed = 140f;
    public Transform groundChecker;
    public LayerMask groundLayer;
    public float offset;
    public GameObject ground;
    public float jumpForce = 2f;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        RiBody = GetComponent<Rigidbody>();
        offset=(transform.position.y-ground.transform.position.y)+1;
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

       
        Vector3 dirVec = new Vector3(h,0,v);
        if(dirVec.magnitude >Mathf.Abs (0.05f))
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dirVec), Time.deltaTime * rotspeed);
        anim.SetFloat("Blend", Vector3.ClampMagnitude(dirVec,1).magnitude);

        RiBody.velocity = Vector3.ClampMagnitude(dirVec,1) * speed;
        RiBody.angularVelocity = Vector3.zero;


        if(transform.position.y-ground.transform.position.y<offset)
            {
                if (Input.GetButtonDown("Jump"))
                {
                    anim.SetTrigger("jump");
                    Jump();
                }
            }
    
    }

    void Jump()
    {
                
                RiBody.AddForce(Vector3.up * jumpForce);    
    }
}
