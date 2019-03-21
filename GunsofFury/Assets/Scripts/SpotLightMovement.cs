using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotLightMovement : MonoBehaviour
{
    private Vector3 pos1 = new Vector3(-1, 1.2f, -10.1f);
    private Vector3 pos2 = new Vector3(2, 1.2f, -10.1f);
    public float speed = 1f;

    void Update()
    {
        transform.position = Vector3.Lerp(pos1, pos2, (Mathf.Sin(speed * Time.time) + 1.0f) / 2.0f);
    }
}
