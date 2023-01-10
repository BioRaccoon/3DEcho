using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoorController : MonoBehaviour
{
    [SerializeField] private Animator myDoor = null;
    [SerializeField] private bool foward = false;
    [SerializeField] private bool backward = false;
    [SerializeField] private GameObject fowardCollider = null;
    [SerializeField] private GameObject backwardCollider = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (foward)
            {
                myDoor.Play("DoorOpenFoward", 0, 0.0f);
                gameObject.SetActive(false);
                Destroy(fowardCollider);
                Destroy(backwardCollider);
            }
            else if (backward)
            {
                myDoor.Play("DoorOpenBackward", 0, 0.0f);
                gameObject.SetActive(false);
                Destroy(fowardCollider);
                Destroy(backwardCollider);
            }
        }
    }

}
