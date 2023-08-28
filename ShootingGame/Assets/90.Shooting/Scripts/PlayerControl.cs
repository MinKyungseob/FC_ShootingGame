using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //�÷��̾� ����ü�� �̵��ӵ�,
    public float Speed = 15.0f;
    //�÷��̾� ���� ������Ʈ�� Ʈ������ ������Ʈ
    private Transform myTransform = null;
    //�÷��̾ �����ϰԵ� ���� �Ѿ� ������
    public GameObject BulletPrefab = null;

    void Start()
    {
        //Ʈ������ ������Ʈ�� ĳ��
        myTransform = GetComponent<Transform>();
        
    }

    void Update()
    {
        //-1 ~ 1 ���� ȭ��Ű(-1) ������ ȭ��Ű(1)
        float axis = Input.GetAxis("Horizontal");
        //Debug.Log("Axis : " + axis);
        //�������Ӵ� �� ���� ������Ʈ�� �츮�� ���ϴ� �ӵ��� �������� �̵��ϴ� ��.
        Vector3 moveAmount = axis * Speed * -Vector3.right * Time.deltaTime;

        myTransform.Translate(moveAmount);

        //����.
        //�����̽� Ű�� ���ȴٸ�
        if(Input.GetKeyDown(KeyCode.Space)==true)
        {
            //�Ѿ� �������� ���� ���� �ִ� ��ġ���� ȸ���� ��Ű�� ���� ���·� �ν��Ͻÿ�����.
            Instantiate(BulletPrefab, myTransform.position, Quaternion.identity);
        }

    }
}
