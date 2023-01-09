using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereGrow : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.localScale = Vector3.Lerp (transform.localScale, transform.localScale * 1.3f, Time.deltaTime * 10);
        if(transform.localScale.y>=10f){
             Destroy(this.gameObject);
        }
        
    }
}
