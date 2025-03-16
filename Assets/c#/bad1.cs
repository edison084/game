using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bad1 : MonoBehaviour
{
    public GameObject nail;
    public int pr;
    public float sspeed;
    // Start is called before the first frame update
    void Start()
    {
        float n = Random.Range(-5f, 5f);
        this.transform.localScale = new Vector2(0.6f, 0.5f);
        Instantiate(nail, new Vector3(transform.position.x + n, -0.8f, 1), Quaternion.identity);
        Destroy(gameObject, 5f);
        StartCoroutine(Sm());
    }
    IEnumerator Sm()
    {
        pr = Random.Range(0, 3);
        if (pr == 0)
        {
            while (true)
            {
                this.transform.localScale -= new Vector3(sspeed, 0, 0);
                yield return new WaitForSeconds(0.1f);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!Pig.live)
        {
            Destroy(gameObject);
        }
    }
}
