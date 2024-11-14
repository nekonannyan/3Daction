using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 diff;
    private GameObject target;
    private float followSpeed = 5.0f;
    private float diffY;

    private void Start()
    {
        target = GameObject.Find("player");
        diff = transform.position - this.transform.position;
        diffY = transform.position.y - target.transform.position.y; // y軸の差分を計算
    }

    private void LateUpdate()
    {
        // 現在のカメラの位置を取得
        Vector3 newPosition = transform.position;

        // y軸のみを追従させる
        newPosition.y = Mathf.Lerp(transform.position.y, target.transform.position.y + diffY, Time.deltaTime * followSpeed);

        // カメラの位置を更新
        transform.position = newPosition;
    }
}
