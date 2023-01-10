using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuScript : MonoBehaviour
{
    private GameObject menu; 
    private bool active = false;

    // Start is called before the first frame update
    void Start()
    {
        menu = GameObject.Find("PauseMenu");
        menu.SetActive(active);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("p") && active == false)
        {
            Time.timeScale = 0;
            menu.SetActive(true);
            active = true;
        }
        else if (Input.GetKeyDown("p") && active == true)
        {
            Time.timeScale = 1;
            menu.SetActive(false);
            active = false;
        }
    }
}
