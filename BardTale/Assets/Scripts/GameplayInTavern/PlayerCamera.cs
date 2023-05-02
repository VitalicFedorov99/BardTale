using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform target; // целевой объект (обычно игрок)
    public float distance = 5.0f; // рассто€ние камеры от цели
    public float height = 2.0f; // высота камеры над целью
    public float smoothSpeed = 0.5f; // скорость поворота камеры

    private float mouseX, mouseY;

    [SerializeField] private float mouseSens = 10f;

    private float xRotation = 0f;
    private float yRotation = 0f;
    [SerializeField] private float xMin = -50f;
    [SerializeField] private float xMax = 50f;
    private void LateUpdate()
    {
        Rotate();
        // ѕолучаем текущее положение камеры
        /*     Vector3 currentRotation = transform.eulerAngles;

             // ѕолучаем положение мыши
             mouseX += Input.GetAxis("Mouse X");
             mouseY -= Input.GetAxis("Mouse Y");

             // ќграничиваем вертикальный угол обзора от -80 до 80 градусов
             mouseY = Mathf.Clamp(mouseY, -80f, 80f);

             // ѕоворачиваем камеру в соответствии с положением мыши
             Quaternion rotation = Quaternion.Euler(mouseY, mouseX, 0);

             // ¬ычисл€ем новую позицию камеры
             Vector3 position = target.position - (rotation * Vector3.forward * distance + new Vector3(0, -height, 0));

             // ѕлавно поворачиваем камеру к новой позиции
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
