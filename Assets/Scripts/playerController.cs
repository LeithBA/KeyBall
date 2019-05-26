using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(NavMeshAgent))]
public class playerController : MonoBehaviour
{
    Transform target;
    Vector3 destination;
    NavMeshAgent agent;
    public GameObject keys;
    Animator anim;
    public GameObject ball;
    Rigidbody ballrb;
    public float force, upforce;
    public Color color;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        destination = agent.destination;
        anim = GetComponent<Animator>();
        ballrb = ball.GetComponent<Rigidbody>();
    }

    void Update()
    {
        InputCheck();
        // Update destination if the target moves one unit
        if (target != null)
        {


            if (Vector3.Distance(destination, target.position) > 2.0f)
            {
                anim.SetBool("running", true);
                destination = target.position;
                agent.destination = destination;
            }


            Debug.Log(Vector3.Distance(destination, this.transform.position));
            if (Vector3.Distance(destination, this.transform.position) > 2.0f)
                anim.SetBool("running", true);
            else
                anim.SetBool("running", false);
        }
    }

    void InputCheck()
    {
        foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(vKey) && keys.transform.Find(vKey.ToString()) != null)
            {
                Transform key = keys.transform.Find(vKey.ToString());
                ParticleSystem PS = key.GetChild(0).GetComponent<ParticleSystem>();

                if (Vector3.Distance(this.transform.position, key.position) < 10)
                {
                    ParticleSystem.MainModule newMain = PS.main;
                    newMain.startColor = color;
                    key.GetChild(0).GetComponent<ParticleSystem>().Play();
                    target = key;
                }
            }
        }
    }

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject == ball)
        {
            ballrb.AddExplosionForce(force, this.transform.position, 10, upforce, ForceMode.Impulse);
        }
    }
}