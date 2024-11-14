using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 startPos;         // タッチ開始位置
    private Vector3 endPos;           // タッチ終了位置
    private bool isDragging = false;  // ドラッグ中かどうか
    private Rigidbody rb;             // キャラクターのRigidbody
    public Camera mainCamera;


    public float power = 0.5f;         // 飛ばす力の強さを調整する
    public float upwardMultiplier = 2f; // 上方向の力の倍率

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // メインカメラが未設定の場合、自動で設定
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }

    void Update()
    {

        // マウスの左ボタンが押されたらタップ開始
        if (Input.GetMouseButtonDown(0))
        {
            startPos = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, mainCamera.WorldToScreenPoint(transform.position).z));

            isDragging = true;
        }

        // マウスがドラッグされている間
        if (isDragging && Input.GetMouseButton(0))
        {
            // 画面上での現在の位置を取得
            Vector3 currentPos = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, mainCamera.WorldToScreenPoint(transform.position).z));
            Vector3 direction = startPos - currentPos; // 引っ張り方向を計算

            // オブジェクトの回転をビジュアル化するため、矢印をキャラクターに表示するなどの処理もここで可能
        }

        // マウスの左ボタンが離されたとき
        if (isDragging && Input.GetMouseButtonUp(0))
        {
            endPos = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, mainCamera.WorldToScreenPoint(transform.position).z)); 
            isDragging = false;

            // 引っ張った方向に力を加える
            Vector3 forceDirection = startPos - endPos;

            // 上方向の力を強くする
            forceDirection.y *= upwardMultiplier;

            rb.AddForce(forceDirection * power, ForceMode.Impulse);
        }
    }
}


