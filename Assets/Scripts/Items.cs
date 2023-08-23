using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Items : MonoBehaviour
{
    float timer = 3;
    public void Selection()
    {
        Destroy(gameObject);
    }
    private void FixedUpdate()
    {
        if(timer > 0) timer -= Time.deltaTime;
        if(timer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
