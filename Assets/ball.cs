using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    public gameManager GM;
    Vector3 startPosition;
    Rigidbody rb;
    public ParticleSystem goalEffect;

    void Start()
    {
        startPosition = this.transform.position;
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        if (this.transform.position.z >= 11.5f)
        {
            goalEffect.transform.position = this.transform.position;
            goalEffect.Play();

            GM.redPoints++;
            GM.updateScore();

			if (GM.time > 0)
            {
                this.transform.position = startPosition;
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
			else 
				Destroy(this.gameObject);
        }
        else if (this.transform.position.z <= -21)
        {
            goalEffect.transform.position = this.transform.position;
            goalEffect.Play();

            GM.bluePoints++;
            GM.updateScore();

            if (GM.time > 0)
            {
                this.transform.position = startPosition;
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
            else
                Destroy(this.gameObject);
        }
    }
}
