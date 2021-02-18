using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    float speed;
    [HideInInspector]
    public bool ShouldRotate = false;
    // Update is called once per frame
    void FixedUpdate()
    {
        if(ShouldRotate)
        transform.Rotate(0, 0, 20 * speed * Time.deltaTime);
    }
}
