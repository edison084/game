using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skyfollow : MonoBehaviour
{
    public GameObject pig;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(pig.transform.position.x, 1, 2);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(pig.transform.position.x, 1, 2);
    }
}
