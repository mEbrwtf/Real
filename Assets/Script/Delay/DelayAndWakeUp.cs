using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayAndWakeUp : MonoBehaviour
{
    public GameObject Key;
    public Collider collider;
    // Start is called before the first frame update
    void Start()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(DelayedAction());
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
    private IEnumerator DelayedAction()
    {
        yield return new WaitForSeconds(0f);
        Key.SetActive(true);
        collider.enabled = true;

    }
}
