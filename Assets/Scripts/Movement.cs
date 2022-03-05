using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float horizontal;
    [SerializeField] private float speed;

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        
        transform.Translate(horizontal * speed * Time.deltaTime,0,speed * Time.deltaTime);
    }
}
