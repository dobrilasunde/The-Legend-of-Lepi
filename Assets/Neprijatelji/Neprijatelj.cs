using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neprijatelj : MonoBehaviour {

    [SerializeField] float punZivot = 100f;
    [SerializeField] float radijusNapada = 4f;

    float trenutnoZivota = 100f;

    GameObject igrac = null;
    UnityEngine.AI.NavMeshAgent agent;

    public float postotakZivota
    {
        get
        {
            return trenutnoZivota / punZivot;
        }

    }

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        igrac = GameObject.FindGameObjectWithTag("Player");    
    }

    void Update()
    {
        float udaljenostDoIgraca = Vector3.Distance(igrac.transform.position, transform.position);
        if(udaljenostDoIgraca <= radijusNapada)
        {

            Vector3 direction = (igrac.transform.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
            GetComponent<Animator>().SetInteger("Move", 1);
            agent.destination = igrac.transform.position;
            agent.speed = 5f;
        }
        else
        {
            GetComponent<Animator>().SetInteger("Move", 0);
            agent.destination = transform.position;
        }
    }
}
