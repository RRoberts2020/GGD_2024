using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audience : MonoBehaviour
{
    [HideInInspector] public float jumpForce = 1f;
    private new Rigidbody rigidbody;

    public bool happy;

    private int TimeUntilJump;

    void Awake()
    {
        happy = true;

        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (happy == true)
        {
            StartCoroutine(JumpHappy());
        }

        if (happy == false)
        {
            StopCoroutine(JumpHappy());
        }

    }
    
    IEnumerator JumpHappy()
    {
        TimeUntilJump = Random.Range(1, 5);

        yield return new WaitForSeconds(TimeUntilJump);

        //Jump up
        rigidbody.AddForce(Vector3.up * jumpForce * Time.deltaTime, ForceMode.Impulse);

        yield return new WaitForSeconds(1);

        //Come back down
        rigidbody.AddForce(Vector3.down * jumpForce * Time.deltaTime, ForceMode.Impulse);
    }


}
