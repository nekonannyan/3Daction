using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraController : MonoBehaviour
{
    private GameObject target;
    private float followSpeed = 5.0f;
    private float diffY;

    float wantRotation;

    public GameObject centerTarget; // カメラが回転するターゲットオブジェクト
    public float distance = 5.0f; // ターゲットからの距離
    private Vector3 offset; // ターゲットからのオフセット

    private void Start()
    {
        target = GameObject.Find("player");
        diffY = transform.position.y - target.transform.position.y; // y軸の差分を計算
        wantRotation = transform.rotation.eulerAngles.y;
        if (centerTarget == null)
        {
            Debug.LogError("ターゲットオブジェクトが設定されていません。");
            return;
        }

        // ターゲットからの初期オフセットを計算
        offset = transform.position - centerTarget.transform.position;

    }

    void Update()
    {
        // 左右のキー入力でキャラクターを90度旋回する
        if (Input.GetKeyDown(KeyCode.A))
        {
            wantRotation += 90f;
            RotateCameraAroundTarget(wantRotation);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            wantRotation -= 90;
            RotateCameraAroundTarget(wantRotation);
        }
    }

    void RotateCameraAroundTarget(float angle)
    {
        // ターゲットを基準にカメラをY軸で指定角度回転
        Quaternion rotation = Quaternion.Euler(0, angle, 0);
        Vector3 newPosition = rotation * offset; // オフセットに回転を適用

        // 新しい位置にカメラを移動
        transform.position = centerTarget.transform.position + newPosition;

        // カメラが常にターゲットを見るように設定
        transform.LookAt(centerTarget.transform);
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
