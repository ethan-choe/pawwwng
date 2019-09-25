using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Script : MonoBehaviour
{

    public float        speed = 1f;
    private Rigidbody   rb;
    private Vector3     startPos;
    // private int         resetMultiplier = 1;
    private int         hDir = 1;
    private int         vDir = 1;
    private int         scorer = 0;

    // private Vector3     nF;
    public float        acceleration = 0;
    public float        maxSpeed = 400;
    private bool        spin;

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
        // nF = new Vector3(0.0f,200.0f,0.0f);
        if(other.tag == "LBound")
        {
            scorer = 1;
            // reset ball and increment score
            ScoreScript.S.UpdateScore(scorer);
            Reset();
        }
        else if(other.tag == "RBound")
        {
            scorer = 0;
            // reset ball and increment score
            ScoreScript.S.UpdateScore(scorer);
            Reset();
        }

        // spinning the ball
        else if(other.tag == "Player")
        {
            // Debug.Log(nF);
            // rb.AddForce(nF,ForceMode.Acceleration);
            spin = true;
        }

    }

    private void Update()
    {
        OnTriggerEnter();
        Debug.Log("Spin: "+ spin);
        if(spin == true)
        {
            transform.Translate(0, acceleration * Time.deltaTime, 0);
            if (acceleration < maxSpeed)
            {
                Debug.Log("Acceleration" + acceleration);
                acceleration *= 5;
            }
            else if (acceleration >= maxSpeed)
            {
                acceleration = 0;
                spin = false;
            }
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

        // Debug.Log(resetMultiplier);
        //Put Ball in the Middle
        transform.position = startPos;
        rb.velocity = Vector3.zero;
        spin = false;

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
