using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Script : MonoBehaviour
{

    public float        speed = 1f;
    private Rigidbody   rb;
    private Vector3     startPos;
    private int         resetMultiplier = 1;
    private int         hDir = 1;
    private int         vDir = 1;
    private int         scorer = 0;

    public Vector3         nF;

    // public AudioSource hit;    

    public Color        altColor = Color.black;
    private Renderer    rend;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        rb = GetComponent<Rigidbody>();

        rend = GetComponent<Renderer>();
        rend.material.color = altColor;

        StartCoroutine("Launch");
    }

    // public void Update() {
    //     if(Input.GetKeyDown(KeyCode.Space))
    //     {
    //         hit.Play();
    //     }
    // }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "LBound")
        {
            scorer = 1;
        }
        else if(other.tag == "RBound")
        {
            scorer = 0;
        }
        // else
        // {
        //     if (other.tag == "Player")
        //     {
        //         hit.Play();
        //     }
        // }

        // reset ball and increment score
        ScoreScript.S.UpdateScore(scorer);
        Reset();
    }
    private void Spin (Collider other)
    {
        nF = new Vector3(0.0f,2.0f,0.0f)
        if(other.tag == "Player")
        {
            rb.AddForce(nF,ForceMode.Acceleration);
        }
    }
    private void Reset()
    {
        if (scorer == 0)
        {
            // increment score
        }
        else if (scorer == 1)
        {
            // increment score
        }

        hDir = Mathf.RoundToInt(Random.Range(-1f,1f));
        if (hDir == 0) hDir = -1;

        vDir = Mathf.RoundToInt(Random.Range(-1f,1f));
        if (vDir == 0) vDir = -1;

        Debug.Log(resetMultiplier);
        //Put Ball in the Middle
        transform.position = startPos;
        rb.velocity = Vector3.zero;

        StartCoroutine("Launch");
    }

    public IEnumerator Launch() 
    {
        yield return new WaitForSeconds(2);

        rb.AddForce(transform.right * speed * hDir);
        rb.AddForce(transform.up * speed * vDir);

        yield return null;
    }
}
