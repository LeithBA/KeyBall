using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    public gameManager GM;
    Vector3 startPosition;
    Rigidbody rb;
    public float kickForce, upKickForce;
    public ParticleSystem goalEffect;
    AudioSource goalSound;

    void Start()
    {
        startPosition = this.transform.position;
        rb = GetComponent<Rigidbody>();
        goalSound = goalEffect.gameObject.GetComponent<AudioSource>();
    }


    void Update()
    {
        checkIfGoal();
    }

    void checkIfGoal()
    {
        if (this.transform.position.z >= 11.5f)
        {
            goalEffect.transform.position = this.transform.position;
            goalEffect.Play();
            goalSound.Play();

            GM.redPoints++;
            GM.updateScore();

            checkIfGameover();
        }

        else if (this.transform.position.z <= -21)
        {
            goalEffect.transform.position = this.transform.position;
            goalEffect.Play();
            goalSound.Play();

            GM.bluePoints++;
            GM.updateScore();

            checkIfGameover();
        }
    }

    void checkIfGameover()
    {
        if (GM.time > 0)
        {
            this.transform.position = startPosition;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        else
        {
            Destroy(this.gameObject);
            GM.gameOver();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            rb.AddExplosionForce(kickForce, other.transform.position, 10, upKickForce, ForceMode.Impulse);
        }
    }
}