using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleCollision : MonoBehaviour
{
    Rigidbody rb;

    Collecter collecter;

    [SerializeField] GameObject collectedsParent;

    Rigidbody collectedsRb;
    
    public float height;
    bool isCollected = false;
    private void Start() 
    {
        rb = GetComponent<Rigidbody>();
        collectedsParent =GameObject.Find("Collectibles");
    }

    private void OnCollisionEnter(Collision other)
    {   
        if(isCollected)
        {
            if(other.gameObject.CompareTag("Spinner"))
        {
            isCollected = false;
            rb.AddForce(Vector3.left * 500f,ForceMode.Force);
            transform.parent = collectedsParent.transform;
            this.gameObject.tag = "Collected";
            Debug.Log("SPİNNERA DEĞİLDİ");
            collecter.numOfAddedItems--;
            Debug.Log("Spinner'a çarptıktan sonraki number : "+collecter.numOfAddedItems);
            collecter.collectedList.Remove(this.gameObject);
            foreach (var collecteds in collecter.collectedList)
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
                collecter.AddNewStack(this.transform,this.gameObject);
                isCollected = true;
                Debug.Log("Player'a çarptıktan sonraki number : "+collecter.numOfAddedItems);
            }               
        }
    }

    void OnCollisionExit(Collision other)
    {
        if(other.gameObject.CompareTag("Spinner"))
            {
                Invoke("AfterTheColSpinner",1f);
            }
    }


    void AfterTheColSpinner()
    {
        foreach (var collecteds in collecter.collectedList)
            {
                collecteds.GetComponent<Rigidbody>().isKinematic = true;
            }
    }
     
}
