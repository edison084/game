using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nailC : MonoBehaviour
{
    public Rigidbody2D nail;
    public int r;
    public float waitTime;
    public float speed;
    public float f = 10;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(S());
    }
    IEnumerator S()
    {
        r = Random.Range(1,11);
        waitTime = Random.Range(1f, 2f);
        if (r == 1)
        {
            yield return new WaitForSeconds(waitTime);
            nail.AddForce(Vector3.up * f, ForceMode2D.Impulse);
        }
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
