using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPlatForm : MonoBehaviour
{
    public AudioSource elevator;
    MoveingPlatForm platForm;
    private void Start()
    {
        platForm = GetComponent<MoveingPlatForm>();
    }

    private void OnTriggerEnter(Collider other)
    {
        /*if (other.CompareTag("Player"))
        {
            Debug.Log("Player Inside");
            platForm.canMove = true;
        }*/
    }
    void Update()
    {
        if (Input.GetButtonDown("Use"))
        {
            platForm.canMove = true;
            elevator.Play();
        }


    }
}