
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    Rigidbody2D rigidBody;
    public bool DoneDropping { get; private set; }

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.simulated = false;
        DoneDropping = false;
    }

    public void SimulateFruit()
    {
        rigidBody.simulated = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DoneDropping = true;
    }
}