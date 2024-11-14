using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FollowCamera : MonoBehaviour
{
    public Transform Player;
    public Vector3 offset;

    void Update()
    {
        transform.position = Player.position + offset;
    }
}