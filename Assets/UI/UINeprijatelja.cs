using UnityEngine;

// Add a UI Socket transform to your enemy
// Attack this script to the socket
// Link to a canvas prefab that contains NPC UI
public class UINeprijatelja : MonoBehaviour {

    [Tooltip("The UI canvas prefab")]
    [SerializeField] GameObject platnoNeprijatelja = null;

    Camera kamera;

    // Use this for initialization 
    void Start()
    {
        kamera = Camera.main;
        Instantiate(platnoNeprijatelja, transform.position, Quaternion.identity, transform);
    }

    // Update is called once per frame 
    void LateUpdate()
    {
        transform.LookAt(kamera.transform);
        transform.rotation = Quaternion.LookRotation(kamera.transform.forward);
    }
}