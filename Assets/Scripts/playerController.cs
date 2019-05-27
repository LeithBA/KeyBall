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
    public Color color;
    public GameObject otherPlayer;
    Rigidbody rb;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        destination = agent.destination;
        anim = GetComponent<Animator>();
        ballrb = ball.GetComponent<Rigidbody>();
        rb = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        InputCheck();
        // Update destination if the target moves one unit
        if (target != null)
        {


            if (Vector3.Distance(destination, target.position) > 2.0f)
            {
                //anim.SetBool("running", true);
                destination = target.position;
                agent.destination = destination;
            }


            //Debug.Log(Vector3.Distance(destination, this.transform.position));
            if (Vector3.Distance(destination, this.transform.position) > 2.0f)
            {
                anim.SetBool("running", true);
                rb.freezeRotation = false;
                rb.constraints = RigidbodyConstraints.None;
            }
            else
            {
                anim.SetBool("running", false);
                rb.constraints = RigidbodyConstraints.FreezeRotationX |
                                        RigidbodyConstraints.FreezeRotationY |
                                        RigidbodyConstraints.FreezeRotationZ |
                                        RigidbodyConstraints.FreezePositionX | 
                                        RigidbodyConstraints.FreezePositionY | 
                                        RigidbodyConstraints.FreezePositionZ;
            }
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

                if (Vector3.Distance(this.transform.position, key.position) < 7)
                {
                    ParticleSystem.MainModule newMain = PS.main;
                    newMain.startColor = color;
                    key.GetChild(0).GetComponent<ParticleSystem>().Play();
                    target = key;
                }
                else if (Vector3.Distance(this.transform.position, key.position) >= 7 &&
                         Vector3.Distance(otherPlayer.transform.position, key.position) >= 7)
                {
                    ParticleSystem.MainModule newMain = PS.main;
                    newMain.startColor = Color.white;
                    key.GetChild(0).GetComponent<ParticleSystem>().Play();
                }
            }
        }
    }
}