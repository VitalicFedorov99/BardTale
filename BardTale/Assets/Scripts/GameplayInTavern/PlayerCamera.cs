using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform target; // ������� ������ (������ �����)
    public float distance = 5.0f; // ���������� ������ �� ����
    public float height = 2.0f; // ������ ������ ��� �����
    public float smoothSpeed = 0.5f; // �������� �������� ������

    private float mouseX, mouseY;

    [SerializeField] private float mouseSens = 10f;

    private float xRotation = 0f;
    private float yRotation = 0f;
    [SerializeField] private float xMin = -50f;
    [SerializeField] private float xMax = 50f;
    private void LateUpdate()
    {
        Rotate();
        // �������� ������� ��������� ������
        /*     Vector3 currentRotation = transform.eulerAngles;

             // �������� ��������� ����
             mouseX += Input.GetAxis("Mouse X");
             mouseY -= Input.GetAxis("Mouse Y");

             // ������������ ������������ ���� ������ �� -80 �� 80 ��������
             mouseY = Mathf.Clamp(mouseY, -80f, 80f);

             // ������������ ������ � ������������ � ���������� ����
             Quaternion rotation = Quaternion.Euler(mouseY, mouseX, 0);

             // ��������� ����� ������� ������
             Vector3 position = target.position - (rotation * Vector3.forward * distance + new Vector3(0, -height, 0));

             // ������ ������������ ������ � ����� �������
             transform.position = Vector3.Lerp(transform.position, position, smoothSpeed);
             transform.rotation = Quaternion.Lerp(transform.rotation, rotation, smoothSpeed);


             float mouseX = Input.GetAxis("Horizontal") * mouseSens * Time.deltaTime;
             float mouseY = Input.GetAxis("Vertical") * mouseSens * Time.deltaTime;

             xRotation -= mouseY;
             xRotation = Mathf.Clamp(xRotation, xMin, xMax);
             yRotation += mouseX;


             placeCamera.transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
             transform.Rotate(Vector3.up * mouseX);*/
    }


    private void Rotate()
    {
        float mouseX = Input.GetAxis("Horizontal") * mouseSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Vertical") * mouseSens * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, xMin, xMax);
        yRotation += mouseX;


        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
       // playerMovement.SetRotate(xRotation);
        transform.Rotate(Vector3.up * mouseX);
    }

}
