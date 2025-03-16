using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class Pig : MonoBehaviour
{
    public GameObject super;
    public GameObject hphp;
    public List<GameObject> que;
    public TextMeshProUGUI fui;
    public TextMeshProUGUI s;
    public TextMeshProUGUI time;
    public GameObject hp;
    public GameObject bad;
    public Rigidbody2D pigr;
    public Animator pa;
    public int tt = 20;
    public float tf;
    public int q;
    public bool fd;
    public int score;
    public float t;
    public static bool live;
    public float lo;
    public float force;
    public bool isground;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        q = 0;
        tf = 5;
        score = 0;
        t = 0.01f;
        fd = true;
        live = true;
        isground = true;
        fui.color = Color.red;
        fui.text = "jump and then jump(F):Done";
        hp.transform.localScale = new Vector3(0.14f, 0.2f, 0);
        hphp.transform.localScale = new Vector3(0, 0.1111f, 0);
        StartCoroutine(T());
        s.text = "score:" + score.ToString();
    }
    // Update is called once per frame
    IEnumerator T()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.01f);
            time.text = "time:" + t.ToString("F2");
            t += 0.01f;
        }
    }
    IEnumerator F()
    {
        fui.color = Color.gray;
        while (tf>0)
        {
            yield return new WaitForSeconds(0.01f);
            fui.text = "jump and then jump(F):" + tf.ToString("F2");
            tf -= 0.01f;
        }
        tf = 5;
        fui.color = Color.red;
        fui.text = "jump and then jump(F):Done";
        fd = true;
    }
    IEnumerator Ques(System.Action<bool> callback)
    {
        Time.timeScale = 0;
        bool right = false;
        int sv = Random.Range(0, que.Count);
        GameObject question = Instantiate(que[sv],new Vector3(transform.position.x,transform.position.y,1),Quaternion.identity);
        que.RemoveAt(sv);
        time.text = "";
        fui.text = "";
        s.text = "";
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                right = question.CompareTag("A");  
                break;
            }
            if (Input.GetKeyDown(KeyCode.B))
            {
                right = question.CompareTag("B");
                break;
            }
            if (Input.GetKeyDown(KeyCode.C))
            {
                right = question.CompareTag("C");
                break;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                right = question.CompareTag("D");
                break;
            }

            yield return null; 
        }
        Destroy(question);
        callback(right);
    }
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.F) && fd))
        {
            pigr.AddForce(Vector2.up * force, ForceMode2D.Impulse);
            fd = false;
            StartCoroutine(F());
        }
        if ((hp.transform.localScale.x <= 0 || transform.position.y<-10) && live)
        {
            pigr.constraints = RigidbodyConstraints2D.None;
            Instantiate(super, transform.position, Quaternion.identity);
            live = false;
        }
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && isground)
        {
            pigr.AddForce(Vector2.up * force, ForceMode2D.Impulse);
            pa.SetTrigger("jump");
            isground = false;
        }
        if(t >= tt)
        {
            score += 10;
            tt += 20;
            s.text = "score:" + score.ToString();
        }
        this.transform.position += new Vector3(speed*Time.deltaTime, 0, 0);
    }
    void Corrert(bool isCorrect)
    {
        if (isCorrect)
        {
            score += 2;
        }
        else
        {
            score -= 4;
        }
        s.text = "score:" + score.ToString();
        Time.timeScale = 1;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("nail"))
        {
            hphp.transform.localScale += new Vector3(0.94093f, 0, 0);
            q += 1;
            if (q == 3)
            {
                StartCoroutine(Ques(Corrert));
                q = 0;
                hphp.transform.localScale = new Vector3(0, 0.1111f, 0);
                fui.text = "jump and then jump(F):Done";
            }
            hp.transform.localScale -= new Vector3(lo, 0, 0);
        }
        if (collision.gameObject.CompareTag("road") && !isground)
        {
            pa.SetTrigger("down");
            isground = true;
        }
    }
    void OnTriggerEnter2D(Collider2D collider2)
    {
        if (collider2.gameObject.CompareTag("track"))
        {
            Instantiate(bad, new Vector3(collider2.gameObject.transform.position.x + 10, -2, 1), Quaternion.identity);
            Instantiate(collider2.gameObject, new Vector3(collider2.gameObject.transform.position.x + 10, 0, 1), Quaternion.identity);
        }
        
    }
}
