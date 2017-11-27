using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Test : MonoBehaviour
{

    public float checkDelay = 0f;

    private float checkTimer = 0f;

    protected virtual void Simulate() { }
    protected virtual void Debug() { }
    protected abstract void Check();

    // Use this for initialization
    void Update()
    {
        // Simulate the script
        Simulate();

        checkTimer += Time.deltaTime;
        if (checkTimer >= checkDelay)
        {
            Check();
        }

        // Perform debugging
        Debug();
    }
}
