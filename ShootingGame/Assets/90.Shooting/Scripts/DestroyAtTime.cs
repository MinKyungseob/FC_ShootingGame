using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAtTime : MonoBehaviour
{
    public float Time = 0.5f;
    void Start()
    {
        //time 시간이 경과한 후 자동으로 사라지게 됩니다.
        Destroy(gameObject, Time);
    }
}
