using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraToPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    public Image alien;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown ("a"))
        {
            alien.transform.localScale = new Vector3 (1, 1, 1);
        }

        if (Input.GetKeyDown("d"))
        {
            alien.transform.localScale = new Vector3 (-1, 1, 1);
         }
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
