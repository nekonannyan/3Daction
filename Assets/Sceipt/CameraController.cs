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
        diffY = transform.position.y - target.transform.position.y; // y���̍������v�Z
    }

    private void LateUpdate()
    {
        // ���݂̃J�����̈ʒu���擾
        Vector3 newPosition = transform.position;

        // y���݂̂�Ǐ]������
        newPosition.y = Mathf.Lerp(transform.position.y, target.transform.position.y + diffY, Time.deltaTime * followSpeed);

        // �J�����̈ʒu���X�V
        transform.position = newPosition;
    }
}
