using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloScript : MonoBehaviour
{
    Rigidbody body;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        Debug.Log("Starting...");
    }

    // Update is called once per frame
    void Update()
    {
        int onUnitSphere = 10;
        Vector3 randDir = Random.onUnitSphere;
        body.AddForce(new Vector3(randDir.x, 0, randDir.y));
        //transform.position = Mathf.
        //transform.position = new Vector3(Mathf.Sin(Time.time) * 5.0f, Mathf.Sin(Time.time) * -3.0f, Mathf.Sin(Time.time) * 2.0f);

    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
    }
}
