using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCutScene : MonoBehaviour
{
    public GameObject CutSceneCamera;
    public GameObject MainCamera;
    // Start is called before the first frame update
    void Start()
    {
        MainCamera.SetActive(false);
        CutSceneCamera.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) // Example: Check on button press
        {
            MainCamera.SetActive(true);
            CutSceneCamera.SetActive(false);
        }
    }
}