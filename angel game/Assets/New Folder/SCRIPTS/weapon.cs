using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

   public class weapon : MonoBehaviour 
   {

    public Transform bullet;
    public int BulletForce = 5000;
    public int Magaz = 30;
    public AudioClip Fire;
    public AudioClip Reload;
    public AudioSource asor; 
    private Rigidbody rigidb; 


    void Start () {
        asor = GetComponent<AudioSource>();
        
    }

    void Update () {
     if(Input.GetMouseButtonDown(0)&Magaz>0){
      Transform BulletInstance = (Transform) Instantiate (bullet, GameObject.Find ("spawn").transform.position, Quaternion.identity);
      BulletInstance.GetComponent<Rigidbody>().AddForce (transform.forward * BulletForce);
      Magaz = Magaz - 1;
      asor.PlayOneShot(Fire);
      asor.PlayOneShot(Reload);
     }
     if(Input.GetKeyDown(KeyCode.R)){
      Magaz = 7;
     }
    }
   }
