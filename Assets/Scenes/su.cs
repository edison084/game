using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class su : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(sup());
    }
    IEnumerator sup()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("in");
    }
}
