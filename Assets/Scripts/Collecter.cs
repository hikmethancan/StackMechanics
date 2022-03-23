
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Collecter : MonoBehaviour
{
    private GameObject player;
    private GameObject collectedObject;

    public static List<GameObject> collectedList;

    public float height;

    public  int numOfAddedItems = 0;

    private void Start()
    {
        numOfAddedItems = 0;
        height = transform.localPosition.y;
        collectedList = new List<GameObject>();
    }

    public void AddNewStack(Transform newStackPos)
    {
        newStackPos.DOJump(transform.position + new Vector3(-1.3f, .67f * numOfAddedItems, 0), 1.5f, 1, .4f).OnComplete(() =>
            {
                numOfAddedItems++;
                newStackPos.SetParent(transform, true);
                newStackPos.localPosition = new Vector3(0, .033f * numOfAddedItems, 0);
                newStackPos.localRotation = Quaternion.identity;

            });
    }

}
