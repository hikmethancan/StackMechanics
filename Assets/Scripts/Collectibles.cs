using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    Rigidbody rb;

    Collecter collecter;

    [SerializeField] GameObject collectedsParent;
    
    public float height;
    bool isCollected = false;
    private void Start() 
    {
        rb = GetComponent<Rigidbody>();
        collectedsParent =GameObject.Find("Collectibles");
    }


GameObject yolPrefab;
    private void OnCollisionEnter(Collision other)
    {   
        
        if(isCollected)
        {
            if(other.gameObject.CompareTag("Spinner"))
        {
           collecter.numOfAddedItems--;
            foreach (var collecteds in Collecter.collectedList)
            {
                collecteds.GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = transform;
            }
        }
        return;
        }

        if (other.gameObject.CompareTag("Player"))
        {
                 collecter = other.gameObject.GetComponent<Collecter>();
                if(other.gameObject.TryGetComponent(out collecter))
                {
                    rb.isKinematic = true;
                    collecter.AddNewStack(this.transform);
                    isCollected = true;
                    
                }               
        }
    }
}
