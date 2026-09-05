using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMove : MonoBehaviour
{
    [SerializeField] private float _floorSpeed;
    [SerializeField] private float _speenSpeed;
    private void Update()
    {
        transform.Translate(Vector3.up * _floorSpeed * Time.deltaTime);
        // 만약에 _floorSpeed 10이면
        // 1초에 초당 10칸을 정확하게 갈것이고
        
        // Time.deltaTime이 없다면
        // 1프레임당 10칸을 갈것
        
        // 실행 결과
        // Time.deltaTime을 곱했을 때 1초에 10칸을 간다
        
        // Time.deltaTime이 없을 땐 조오오올라 빠르게 가는게 맞았다.
        Rigidbody.Rotate(Vector3.right * _speenSpeed * Time.deltaTime);
    }
    
}
