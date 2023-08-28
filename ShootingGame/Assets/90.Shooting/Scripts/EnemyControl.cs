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
    
    //���� �浹ü ������ Ʈ���� ������ �� �浹ü�� �ε����ٸ� �߻��Ǵ� �Լ�
    private void OnTriggerEnter(Collider other)
    {
        //�Ѿ˿� �¾Ҵٸ�
        if(other.tag=="Bullet")
        {
            Instantiate(Explosion, myTransform.position, Quaternion.identity);
            InitPosition();
            Destroy(other.gameObject);
            //Destroy(gameObject);
        }
    }
    /// <summary>
    /// �� ��ġ�� �ʱ�ȭ
    /// </summary>
    void InitPosition()
    {
        myTransform.position = new Vector3(Random.Range(-60.0f, 60.0f), 50.0f, 0.0f);       //x �ప�� -60~60 ����, y�ప�� 50, z�ప�� 0����
    }
}