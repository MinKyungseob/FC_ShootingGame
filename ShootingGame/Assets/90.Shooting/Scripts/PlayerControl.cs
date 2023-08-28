using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //플레이어 비행체의 이동속도,
    public float Speed = 15.0f;
    //플레이어 게임 오브젝트의 트랜스폼 컴포넌트
    private Transform myTransform = null;
    //플레이어가 생성하게될 원본 총알 프리펩
    public GameObject BulletPrefab = null;

    void Start()
    {
        //트랜스폼 컴포넌트를 캐싱
        myTransform = GetComponent<Transform>();
        
    }

    void Update()
    {
        //-1 ~ 1 왼쪽 화살키(-1) 오른쪽 화살키(1)
        float axis = Input.GetAxis("Horizontal");
        //Debug.Log("Axis : " + axis);
        //매프레임당 이 게임 오브젝트가 우리가 원하는 속도와 방향으로 이동하는 양.
        Vector3 moveAmount = axis * Speed * -Vector3.right * Time.deltaTime;

        myTransform.Translate(moveAmount);

        //슈팅.
        //스페이스 키가 눌렸다면
        if(Input.GetKeyDown(KeyCode.Space)==true)
        {
            //총알 프리펩을 현재 내가 있는 위치에서 회전을 시키지 않은 상태로 인스턴시에이팅.
            Instantiate(BulletPrefab, myTransform.position, Quaternion.identity);
        }

    }
}
