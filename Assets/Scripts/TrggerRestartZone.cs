using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrggerRestartZone : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void ShowAdv();

    private Rigidbody rb;
    private Vector3 checkPoint;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "CheckPoint")
        {
            checkPoint = collision.gameObject.transform.position + new Vector3(0, 5, 0);
        }
    }

    void Update()
    {
        if (transform.position.y < 0)
        {
            ShowAdv();
            transform.position = checkPoint;
            transform.rotation = Quaternion.identity;
            rb.velocity = new Vector3(0, 0, 0);
        }
    }
}
