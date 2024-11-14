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

    public GameObject centerTarget; // �J��������]����^�[�Q�b�g�I�u�W�F�N�g
    public float distance = 5.0f; // �^�[�Q�b�g����̋���
    private Vector3 offset; // �^�[�Q�b�g����̃I�t�Z�b�g

    private void Start()
    {
        target = GameObject.Find("player");
        diffY = transform.position.y - target.transform.position.y; // y���̍������v�Z
        wantRotation = transform.rotation.eulerAngles.y;
        if (centerTarget == null)
        {
            Debug.LogError("�^�[�Q�b�g�I�u�W�F�N�g���ݒ肳��Ă��܂���B");
            return;
        }

        // �^�[�Q�b�g����̏����I�t�Z�b�g���v�Z
        offset = transform.position - centerTarget.transform.position;

    }

    void Update()
    {
        // ���E�̃L�[���͂ŃL�����N�^�[��90�x���񂷂�
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
        // �^�[�Q�b�g����ɃJ������Y���Ŏw��p�x��]
        Quaternion rotation = Quaternion.Euler(0, angle, 0);
        Vector3 newPosition = rotation * offset; // �I�t�Z�b�g�ɉ�]��K�p

        // �V�����ʒu�ɃJ�������ړ�
        transform.position = centerTarget.transform.position + newPosition;

        // �J��������Ƀ^�[�Q�b�g������悤�ɐݒ�
        transform.LookAt(centerTarget.transform);
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
