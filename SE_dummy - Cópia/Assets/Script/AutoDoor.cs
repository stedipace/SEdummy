using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDoor : MonoBehaviour
{
    public Transform playar;
    public Animator myAnim;

    // Start is called before the first frame update
    void Start()
    {
            playar = GameObject.FindGameObjectWithTag ("Player").transform;
            myAnim=GetComponent<Animator>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
         float dist = Vector3.Distance(playar.position, transform.position);
            //print("Distance to other: " + dist);

            if(dist>=2)
            {
                    myAnim.SetBool("OPENDOOR",false);
                    
            }

               if(dist<=1.5f)
            {
                     myAnim.SetBool("OPENDOOR",true);
                  

                    }


        
    }
}
