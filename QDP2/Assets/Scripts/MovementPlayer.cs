using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{

	public float moveSpeed;
	public Rigidbody rb;

    private float movex;
    private float movey;

    // Start is called before the first frame update
    void Start()
    {
        


    }

    // Update is called once per frame
    void FixedUpdate()
    {

        movex = Input.GetAxis("Horizontal");
        movey = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(movex * moveSpeed, movey * moveSpeed);

        //	Vector3 movement = new Vector3 (Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
        //	transform.position += movement * Time.deltaTime * moveSpeed;

        // need to make movement based upon physics system



        //	if (Input.GetKeyDown ("w"))
        //		{
        //			rb.velocity = new Vector3(0, moveSpeed , 0);
        //		}
        //	if (Input.GetKeyDown ("s"))
        //   {
        //		rb.velocity = new Vector3(0, -moveSpeed , 0);
        //	}
        //	if (Input.GetKeyDown ("d"))
        //	{
        //		rb.velocity = new Vector3(moveSpeed , 0, 0);
        //	}
        //	if (Input.GetKeyDown ("a"))
        //	{
        //		rb.velocity = new Vector3(-moveSpeed , 0, 0);
        //	}
    }
}
