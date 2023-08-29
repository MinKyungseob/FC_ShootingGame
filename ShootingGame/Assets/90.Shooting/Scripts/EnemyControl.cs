using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public float EnemySpeed = 50.0f;

    private Transform myTransform = null;

    public GameObject Explosion = null;
    void Start()
    {
        myTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveAmount = EnemySpeed * Vector3.back * Time.deltaTime;
        myTransform.Translate(moveAmount);
        if(myTransform.position.y<-50.0f)
        {
            InitPosition();
        }
    }
    
    //나의 충돌체 영역에 트리거 설정이 된 충돌체가 부딪혔다면 발생되는 함수
    private void OnTriggerEnter(Collider other)
    {
        //총알에 맞았다면
        if(other.tag=="Bullet")
        {
            MainControl.Score += 100;
            Instantiate(Explosion, myTransform.position, Quaternion.identity);
            InitPosition();
            Destroy(other.gameObject);
            //Destroy(gameObject);
        }
    }
    /// <summary>
    /// 내 위치를 초기화
    /// </summary>
    void InitPosition()
    {
        myTransform.position = new Vector3(Random.Range(-60.0f, 60.0f), 50.0f, 0.0f);       //x 축값은 -60~60 사이, y축값은 50, z축값은 0으로
    }
}
