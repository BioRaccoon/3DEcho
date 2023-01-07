using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoorController : MonoBehaviour
{
    [SerializeField] private Animator myDoor = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
          myDoor.Play("DoorOpenFoward", 0, 0.0f);
          gameObject.SetActive(false);
        }
    }

}
