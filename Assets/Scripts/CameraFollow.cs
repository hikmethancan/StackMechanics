using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private Transform player;

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position,player.transform.position + offset,Time.deltaTime * 3);
    }
}
