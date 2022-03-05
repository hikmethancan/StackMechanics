
using System.Collections.Generic;
using UnityEngine;

public class Collecter : MonoBehaviour
{
    private GameObject player;
    private GameObject collectedObject;

    public static List<GameObject> collectedList ;

    public static float height = 0.911000013f;

    private void Start()
    {
        player = GameObject.Find("JohnLemon");
        Debug.Log(player.name);
        collectedList = new List<GameObject>();
    }
    private void Update()
    {
        gameObject.transform.localPosition = new Vector3(-0.0379f,0.911000013f,0.717000067f);
        Debug.Log("Toplanan obje listesi : "+collectedList.Count);
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Collectible"))
        {
            collectedObject = other.gameObject;
            collectedList.Add(other.gameObject);
            height += 0.3659867f* 2;
            Debug.Log("Collecterdaki height : " + height);
            
            collectedObject.tag = "Collected";
            collectedObject.transform.parent = player.transform;
            collectedObject.transform.localPosition = new Vector3(transform.localPosition.x,height,transform.localPosition.z);
            Debug.Log("Toplanan objenin yüksekliği"+collectedObject.transform.localPosition.y);
        }
    }

    // private void OnTriggerEnter(Collider other)
    // {
    //     if (other.gameObject.CompareTag("Collectible"))
    //     {
    //         collectedObject = other.gameObject;
    //         collectedList.Add(other.gameObject);
    //         height += 0.61283f;
    //         Debug.Log("Collecterdaki height : " + height);
    //         
    //         collectedObject.tag = "Collected";
    //         collectedObject.transform.parent = player.transform;
    //         collectedObject.transform.localPosition = new Vector3(transform.localPosition.x,height,transform.localPosition.z);
    //         // collectedObject.GetComponent<Rigidbody>().isKinematic = false;
    //         Debug.Log("Toplanan objenin yüksekliği"+collectedObject.transform.localPosition.y);
    //     }
    // }
}
