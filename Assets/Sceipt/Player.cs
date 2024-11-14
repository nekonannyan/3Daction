using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 startPos;         // �^�b�`�J�n�ʒu
    private Vector3 endPos;           // �^�b�`�I���ʒu
    private bool isDragging = false;  // �h���b�O�����ǂ���
    private Rigidbody rb;             // �L�����N�^�[��Rigidbody
    public Camera mainCamera;


    public float power = 0.5f;         // ��΂��͂̋����𒲐�����
    public float upwardMultiplier = 2f; // ������̗͂̔{��

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // ���C���J���������ݒ�̏ꍇ�A�����Őݒ�
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }

    void Update()
    {

        // �}�E�X�̍��{�^���������ꂽ��^�b�v�J�n
        if (Input.GetMouseButtonDown(0))
        {
            startPos = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, mainCamera.WorldToScreenPoint(transform.position).z));

            isDragging = true;
        }

        // �}�E�X���h���b�O����Ă����
        if (isDragging && Input.GetMouseButton(0))
        {
            // ��ʏ�ł̌��݂̈ʒu���擾
            Vector3 currentPos = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, mainCamera.WorldToScreenPoint(transform.position).z));
            Vector3 direction = startPos - currentPos; // ��������������v�Z

            // �I�u�W�F�N�g�̉�]���r�W���A�������邽�߁A�����L�����N�^�[�ɕ\������Ȃǂ̏����������ŉ\
        }

        // �}�E�X�̍��{�^���������ꂽ�Ƃ�
        if (isDragging && Input.GetMouseButtonUp(0))
        {
            endPos = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, mainCamera.WorldToScreenPoint(transform.position).z)); 
            isDragging = false;

            // ���������������ɗ͂�������
            Vector3 forceDirection = startPos - endPos;

            // ������̗͂���������
            forceDirection.y *= upwardMultiplier;

            rb.AddForce(forceDirection * power, ForceMode.Impulse);
        }
    }
}


