using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereGrow : MonoBehaviour
{

    private GameObject lightGameObject;
    private Light lightComp;

    // Start is called before the first frame update
    void Start()
    {
        // lightGameObject = new GameObject("The Light");

        // // Add the light component
        // lightComp = lightGameObject.AddComponent<Light>();

        // // Set color and position
        // lightComp.color = Color.white;

        // lightComp.intensity = 1;

        // // Set the position (or any transform property)
        // lightGameObject.transform.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        transform.localScale = Vector3.Lerp (transform.localScale, transform.localScale * 1.3f, Time.deltaTime * 10);
        //lightComp.range=transform.localScale.y;
        if(transform.localScale.y>=10f){
             Destroy(this.gameObject);
            //  Destroy(lightGameObject);
        }
        
    }
}
