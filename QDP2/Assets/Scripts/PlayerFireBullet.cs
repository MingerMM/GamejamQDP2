using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireBullet : MonoBehaviour
{
    public GameObject Character;

    public GameObject BulletToRight, BulletToLeft;
    public GameObject BigBulletToRight, BigBulletToLeft;
    Vector2 BulletPosition;
    public float fireRate = 0.5f;
    float nextFire = 0.0f;

    private bool firingBullet2;

    bool facingRight = false;
    bool facingLeft = true;

    private float freezeForSeconds;
    private float timeToWait = 3.0f;

    public Rigidbody rb;

    public AudioSource AudioFire;
    public AudioSource AudioFireBig;

    // Start is called before the first frame update
    void Start()
    {
        freezeForSeconds = 0.0f;
        firingBullet2 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown("d")) && (facingLeft == true)) //(Character.transform.rotation.eulerAngles.z == 90f))  //faced naar links, wil naar rechts
        {
            Rotate(180f);
            facingRight = true;
            facingLeft = false;
            Debug.Log("turning right");
        }
        if ((Input.GetKeyDown("a")) && (facingRight == true)) //(Character.transform.rotation.eulerAngles.z == -90f)) //faced naar rechts, wil naar links
        {
            Rotate(180f);
            facingLeft = true;
            facingRight = false;
            Debug.Log("turning left");
        }


        if (Input.GetKeyDown(KeyCode.Mouse0) && (Time.time > nextFire) && (firingBullet2 == false))  //ready for fire
        {
            nextFire = Time.time + fireRate;
            fireType1();
        }

        if (Input.GetKeyDown(KeyCode.Mouse1) && (Time.time > nextFire) && (firingBullet2 == false))  //ready for fire
        {
            nextFire = Time.time + fireRate;
            firingBullet2 = true;

            StartCoroutine(fireType2());
            //freezeForSeconds = 0.0f;
        }
    }

    void fireType1()
    {
        BulletPosition = transform.position;

        //bullet rechts of links schieten
        if (facingRight)
        {
            BulletPosition += new Vector2(+1.5f, -0.1f);  //spawn plek bullets
            Instantiate(BulletToRight, BulletPosition, Quaternion.identity);   //instantiate = klonen
        }
        if (facingLeft)
        {
            BulletPosition += new Vector2(-1.5f, -0.1f);
            Instantiate(BulletToLeft, BulletPosition, Quaternion.identity);
        }

        AudioFire.Play(0);
    }

    IEnumerator fireType2()
    {
        //freezeForSeconds = .0f;

        AudioFireBig.Play(0);

        rb.constraints = RigidbodyConstraints.FreezeAll;

        yield return new WaitForSeconds(timeToWait);

        rb.constraints = RigidbodyConstraints.None;

        //waiting werkt wel voor kogels

        BulletPosition = transform.position;

        //bullet rechts of links schieten
        if (facingRight)
        {
            BulletPosition += new Vector2(+1.5f, -0.1f);  //spawn plek bullets
            Instantiate(BigBulletToRight, BulletPosition, Quaternion.identity);   //instantiate = klonen
        }
        if (facingLeft)
        {
            BulletPosition += new Vector2(-1.5f, -0.1f);
            Instantiate(BigBulletToLeft, BulletPosition, Quaternion.identity);
        }

        firingBullet2 = false;
    }

    void Rotate(float r)
    {
        transform.Rotate(transform.forward * r);
    }
}