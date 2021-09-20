using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    public float moveSpeed = 5;
    public float jumpForce = 5;
    //private float x, z;
    public Rigidbody player;
    private bool isJumping = false;

    Vector3 fall = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
            transform.position += (Time.deltaTime * moveSpeed * transform.right);

        if (Input.GetKey(KeyCode.A))
            transform.position += (Time.deltaTime * moveSpeed * -transform.right);

        if (Input.GetKey(KeyCode.W))
            transform.position += (Time.deltaTime * moveSpeed * transform.forward);

        if (Input.GetKey(KeyCode.S))
            transform.position += (Time.deltaTime * moveSpeed * -transform.forward);

        if (!isJumping && Input.GetKeyDown(KeyCode.Space)) isJumping = true;

    }

    void FixedUpdate()
    {
        if (isJumping)
        {
            player.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isJumping = false;
        }
    }
}
