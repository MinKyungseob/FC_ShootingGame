using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAtTime : MonoBehaviour
{
    public float Time = 0.5f;
    void Start()
    {
        //time �ð��� ����� �� �ڵ����� ������� �˴ϴ�.
        Destroy(gameObject, Time);
    }
}
