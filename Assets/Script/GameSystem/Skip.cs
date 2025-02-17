using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Skip : MonoBehaviour
{
    public GameObject Timeline;
    public GameObject Camera;
    public GameObject text;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Timeline.SetActive(false);
            Camera.SetActive(true);
            text.SetActive(false);
        }
    }
}

