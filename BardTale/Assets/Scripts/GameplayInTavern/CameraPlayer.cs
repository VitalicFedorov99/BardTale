

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Cinemachine;
using UnityEngine.InputSystem;
public class CameraPlayer : MonoBehaviour
{

    public float XMin { get => xMin; }
    public float XMax { get => xMax; }


    [Header("Setup")]
    [SerializeField] private Transform placeCamera;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private GameObject model;
    [Header("Rotate")]
    [SerializeField] private float mouseSens = 10f;
    [SerializeField] private float xMin = -50f;
    [SerializeField] private float xMax = 50f;
    private float xRotation = 0f;
    private float yRotation = 0f;


    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    private void Start()
    {
        Setup();
    }

    public Vector2 _look;

    public void OnLook(InputValue value)
    {
        _look = value.Get<Vector2>();
    }

    private void Update()
    {
        Rotate();

    }
    private void Setup()
    {
      //  virtualCamera.Follow = this.placeCamera;
      //  virtualCamera.LookAt = this.placeCamera;
        SwitchLayer();
    }



    private void Rotate()
    {
        float mouseX = _look.x * mouseSens * Time.deltaTime;
        float mouseY = _look.y * mouseSens * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, xMin, xMax);
        yRotation += mouseX;
        placeCamera.transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }

    private void SwitchLayer()
    {
        model.layer = 6;
        SetLayerAllChildren(model.transform, 6);

    }
    void SetLayerAllChildren(Transform root, int layer)
    {
        var children = root.GetComponentsInChildren<Transform>(includeInactive: true);
        foreach (var child in children)
        {
            child.gameObject.layer = layer;
        }
    }


}
