
using System;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] private float turningSpeed;

    private void Update()
    {
        transform.Rotate(new Vector3(0,1,0) * Time.deltaTime * turningSpeed,Space.World);
    }

}
