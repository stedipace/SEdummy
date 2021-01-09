using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatioPlaybyDistance : MonoBehaviour
{

    public Animator myLovelyAnimator;
    public float activationDistance;

    public Transform amazingPlayaTransform;

    public GameObject myLilLight;
    // Start is called before the first frame update
    void Start()
    {
        myLovelyAnimator.GetComponent<Animator>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
         if (amazingPlayaTransform)
        {
            float dist = Vector3.Distance(amazingPlayaTransform.position, transform.position);




            if(dist<=activationDistance)
            {
                myLovelyAnimator.SetBool("isClose",true);
                myLilLight.SetActive(true);
                
               
                

                

                }else if(dist>activationDistance)
                { myLovelyAnimator.SetBool("isClose",false); myLilLight.SetActive(false);}





           
        }
        
    }
}
