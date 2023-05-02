using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
public class ThirdPersonController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float turnSpeed = 10f;
    private NavMeshAgent agent;
    private Rigidbody rb;
    private Animator animator;
    float mouseX;
    float mouseY;

    [SerializeField] private GameObject followTransform;
    [SerializeField] private Transform start;
    public float rotationPower = 3f;
    public float rotationLerp = 0.5f;
    public Quaternion nextRotation;
    public Vector3 nextPosition;
    public float speed = 1f;
    public float aimValue;
    public Vector2 _move;
    public Vector2 _look;

    [SerializeField] private float xMin = -50f;
    [SerializeField] private float xMax = 50f;
    private float xRotation = 0f;
    private float yRotation = 0f;

    [SerializeField] private float mouseSens = 10f;
    [SerializeField] private bool isUseStair = false;
    private Vector3 pointStair= new Vector3();
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        agent=GetComponent<NavMeshAgent>();
        //transform.position = start.position;
        animator = GetComponent<Animator>();


    }


    public void OnMove(InputValue value)
    {
        _move = value.Get<Vector2>();
    }

    public void OnLook(InputValue value)
    {
        _look = value.Get<Vector2>();
    }

    /* private void Update()
     {
         #region Player Based Rotation
         /*
                 //Move the player based on the X input on the controller
                 //transform.rotation *= Quaternion.AngleAxis(_look.x * rotationPower, Vector3.up);

                 #endregion

                 #region Follow Transform Rotation

                 //Rotate the Follow Target transform based on the input
                 followTransform.transform.rotation *= Quaternion.AngleAxis(_look.x * rotationPower, Vector3.up);

                 #endregion

                 #region Vertical Rotation
                 followTransform.transform.rotation *= Quaternion.AngleAxis(_look.y * rotationPower, Vector3.right);

                 var angles = followTransform.transform.localEulerAngles;
                 angles.z = 0;

                 var angle = followTransform.transform.localEulerAngles.x;

                 //Clamp the Up/Down rotation
                 if (angle > 180 && angle < 340)
                 {
                     angles.x = 340;
                 }
                 else if (angle < 180 && angle > 40)
                 {
                     angles.x = 40;
                 }


                 followTransform.transform.localEulerAngles = angles;

         #endregion
         float mouseX = _look.x * mouseSens * Time.deltaTime;
         float mouseY = _look.y * mouseSens * Time.deltaTime;

         xRotation -= mouseY;
         xRotation = Mathf.Clamp(xRotation, xMin, xMax);
         yRotation += mouseX;


         transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
        // playerMovement.SetRotate(xRotation);
         transform.Rotate(Vector3.up * mouseX);

         nextRotation = Quaternion.Lerp(followTransform.transform.rotation, nextRotation, Time.deltaTime * rotationLerp);

         if (_move.x == 0 && _move.y == 0)
         {
             nextPosition = transform.position;

             if (aimValue == 1)
             {
                 //Set the player rotation based on the look transform
                 transform.rotation = Quaternion.Euler(0, followTransform.transform.rotation.eulerAngles.y, 0);
                 //reset the y rotation of the look transform
              //   followTransform.transform.localEulerAngles = new Vector3(angles.x, 0, 0);
             }

             return;
         }
         float moveSpeed = speed / 100f;
         Vector3 position = (transform.forward * _move.y * moveSpeed) + (transform.right * _move.x * moveSpeed);
         nextPosition = transform.position + position;


         //Set the player rotation based on the look transform
        // transform.rotation = Quaternion.Euler(0, followTransform.transform.rotation.eulerAngles.y, 0);
         //reset the y rotation of the look transform
       //  followTransform.transform.localEulerAngles = new Vector3(angles.x, 0, 0);
     }
     */

    public void UseStair(Vector3 position )
    {
        agent.SetDestination(position);
        isUseStair = true;
    }

    public bool GetUseStair() => isUseStair; 
   


    private void FixedUpdate()
    {
        // Получаем входные данные по горизонтальной и вертикальной оси
        float horizontal = _move.x;
        float vertical = _move.y;

        // Передвигаем персонажа вперед/назад
        // Vector3 movement = transform.forward * vertical * moveSpeed;
        //  rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
        Vector3 position = (transform.forward * _move.y * moveSpeed * Time.fixedDeltaTime);
        transform.position += position;
        if (_move.y != 0|| isUseStair)
        {
            animator.SetBool("Walk", true);
        }
        else
        {
            animator.SetBool("Walk", false);
        }
        CheckStair();
        // Поворачиваем персонажа влево/вправо
        Quaternion turn = Quaternion.Euler(0f, horizontal * turnSpeed, 0f);
        rb.MoveRotation(rb.rotation * turn);
    }

    private void CheckStair()
    {
        if (isUseStair)
        {
            if (Vector3.Distance(transform.position, pointStair) < 1) 
            {
                isUseStair = false;
            }
        }
    }



}
