using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kretanje : MonoBehaviour {

    [SerializeField] float hodajKreciStaniRadijus = 0.2f;
    [SerializeField] float napadniKreciStaniRadijus = 5f;
    UnityEngine.AI.NavMeshAgent agent;
    BacanjeZraka bacanjeZraka;
    Vector3 trenutnaPozicijaKursora, tockaKlika;
    bool jeUDirektnomKretanju = false;
    float brzina = 5.0f;
    float brzinaRotacije = 5.0f;

    // Use this for initialization
    void Start () {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        bacanjeZraka = Camera.main.GetComponent<BacanjeZraka>();
        trenutnaPozicijaKursora = transform.position;

    }

    private void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.G)) //stisni G za prebacivanje na upravljanje s tipkovnicom
        {
            jeUDirektnomKretanju = !jeUDirektnomKretanju;
            trenutnaPozicijaKursora = transform.position;
        }

        if (jeUDirektnomKretanju)
        {
            agent.ResetPath();
            ProcesuirajDirektnoKretanje();
        }
        else
        {
            ProcesuirajKretanjeMisem();
        }
    }

    private void ProcesuirajDirektnoKretanje()
    {

        if (Input.GetKey(KeyCode.W))
        {
            GetComponent<Animator>().SetInteger("Move", 1);
            this.transform.Translate(Vector3.forward * Time.deltaTime * brzina);
        }
        else
        {
            GetComponent<Animator>().SetInteger("Move", 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Rotate(Vector3.up, (-1)*brzinaRotacije);
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Rotate(Vector3.up, brzinaRotacije);
        }

    }

    private void ProcesuirajKretanjeMisem()
    {
        if (agent.remainingDistance == 0)
        {
            this.GetComponent<Animator>().SetInteger("Move", 0);
            agent.velocity = Vector3.zero;
        }

        if (Input.GetMouseButtonDown(0))
        {
            tockaKlika = bacanjeZraka.udara.point;
            switch (bacanjeZraka.udaraSloj)
            {
                case Sloj.Prohodno:
                    trenutnaPozicijaKursora = SkratiDestinaciju(tockaKlika, hodajKreciStaniRadijus);
                    GetComponent<Animator>().SetInteger("Move", 1);
                    agent.destination = trenutnaPozicijaKursora;
                    agent.speed = 5f;
                    break;
                case Sloj.Neprijatelj:
                    trenutnaPozicijaKursora = SkratiDestinaciju(tockaKlika, napadniKreciStaniRadijus);
                    GetComponent<Animator>().SetInteger("Move", 1);
                    agent.destination = trenutnaPozicijaKursora;
                    agent.speed = 5f;
                    break;
                default:
                    print("Neocekivani sloj");
                    return;

            }
        }
    }

    Vector3 SkratiDestinaciju(Vector3 destinacija, float skracenje)
    {
        Vector3 vektorRedukcije = (destinacija - transform.position).normalized * skracenje;
        return destinacija - vektorRedukcije;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawLine(transform.position, trenutnaPozicijaKursora);
        Gizmos.DrawSphere(trenutnaPozicijaKursora, 0.1f);
        Gizmos.DrawSphere(tockaKlika, 0.15f);

        //attack range
        //Gizmos.color = new Color(255f, 0f, 0, .5f);
        //Gizmos.DrawWireSphere(transform.position, napadniKreciStaniRadijus);
    }

}
