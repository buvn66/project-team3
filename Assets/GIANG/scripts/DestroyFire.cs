using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFire : MonoBehaviour
{
    public float LifeTime = 2f;
    private void Start()
    {
        Destroy(this.gameObject, LifeTime);
    }
}
