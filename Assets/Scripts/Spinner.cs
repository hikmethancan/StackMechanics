
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] private float turningSpeed;

    private GameObject collectibles;

    private List<GameObject> collectedList;

    private void Start()
    {
        collectibles = GameObject.Find("Collectibles");
        collectedList = new List<GameObject>();
    }

    private void Update()
    {
        transform.Rotate(new Vector3(0,1,0) * Time.deltaTime * turningSpeed,Space.World);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Collected"))
        {
            collectedList = Collecter.collectedList;
            // Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            // rb.isKinematic = false;
            // rb.AddForce(Vector3.back * Time.deltaTime * 10f);
            Debug.Log("Spinnerdaki = height : " + Collecter.height);

            Collecter.height -= 0.3659867f* 2;
            collectedList.Remove(other.gameObject);
            Debug.Log("Spinnerdaki çıkartılmış  height : " + Collecter.height);
            
            other.gameObject.transform.parent = collectibles.transform;
            Debug.Log("Listedeki eleman sayısı : "+collectedList.Count);

            // foreach (var collected in collectedList)
            // {
            //     Debug.Log( collected.name);
            // }
        }
    }
}
