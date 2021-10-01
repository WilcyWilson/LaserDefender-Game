using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] float speedOfSpin = 1f;
    void Update()
    {
        transform.Rotate(0f, 0f, speedOfSpin * Time.deltaTime);
    }
}
