using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Script : MonoBehaviour
{

    public float        speed = 1f;
    private Rigidbody   rb;
    private Vector3     startPos;
    private int         resetMultiplier = 1;
    

    public Color        altColor = Color.black;
    private Renderer    rend;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        rb = GetComponent<Rigidbody>();

        //Force
        rb.AddForce(transform.right * speed);
        rb.AddForce(transform.up * speed);

        rend = GetComponent<Renderer>();
        rend.material.color = altColor;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "LBound")
        {
            resetMultiplier = 1;
            Reset();
            // Debug.Log("I'm out of bounds!");
        }
        if (other.tag == "RBound")
        {
            resetMultiplier = -1;
            Reset();
        }
        // Reset Ball
        // Increase Score
    }
    private void Reset()
    {
        //Put Ball in the Middle
        transform.position = startPos;
        rb.velocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && rb.velocity == Vector3.zero)
        {
            rb.AddForce(transform.right * speed * resetMultiplier);
            rb.AddForce(transform.up * speed * resetMultiplier);
        }

    }
}
