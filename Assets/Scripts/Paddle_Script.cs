using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle_Script : MonoBehaviour
{
    public float paddleSpeed = 10f;
    public KeyCode moveUpKey, moveDownKey;

    public AudioSource hit;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // private float padSp = paddleSpeed * Time.deltaTime;
        if(Input.GetKey(moveUpKey))
        {
            // move paddle up
            Vector3 currPos     = transform.position;
            Vector3 newPos      = new Vector3(currPos.x, currPos.y + paddleSpeed * Time.deltaTime ,currPos.z);
            transform.position  = newPos;
        }
        if(Input.GetKey(moveDownKey))
        {
            // move paddle down
            Vector3 currPos     = transform.position;
            Vector3 newPos      = new Vector3(currPos.x, currPos.y - paddleSpeed * Time.deltaTime ,currPos.z);
            transform.position  = newPos;
        }
    }

    private void OnCollisionEnter(Collision other){
        if (name == "Paddle 1")
        {
            hit.panStereo = 1;
        }
        else if(name == "Paddle 2")
        {
            hit.panStereo = -1;
        }
        hit.Play();
    }
}
