using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SoundWaves : MonoBehaviour
{

    UnityEvent m_MyEvent = new UnityEvent();
    public GameObject objectName;
    private GameObject wave;
    Vector3 scaleChange = new Vector3(0.01f, 0.01f, 0.01f);

    // Start is called before the first frame update
    void Start()
    {
        //Add a listener to the new Event. Calls MyAction method when invoked
        m_MyEvent.AddListener(MyAction);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("q")){
            //Begin the action
            m_MyEvent.Invoke();
            
        }
    }

    public void MyAction()
    {
        //Output message to the console
        //Debug.Log("Do Stuff");
        wave = Instantiate(objectName, transform.position,objectName.transform.rotation);
        wave.transform.localScale=new Vector3(1,1,1);

        Debug.Log(wave.transform.localScale.y);


        // while(wave.transform.localScale.y < 10f){
        //     wave.transform.localScale += scaleChange;
        //     Debug.Log(wave.transform.localScale.y);
        // }

        // if (wave.transform.localScale.y >= 3f){
        //     Destroy(wave);
        // }
    }
}
