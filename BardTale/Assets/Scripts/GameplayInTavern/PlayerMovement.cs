
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine.AI;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{





    public GameObject TargetCamera;
    [SerializeField] private float speed;
    Vector3 direction;
    Vector3 normDirection;
    public Vector2 _move;
    public Vector2 _look;
    private NavMeshAgent agent;
    private Animator animator;
    private CharacterController character;

    public void OnMove(InputValue value)
    {
        _move = value.Get<Vector2>();
    }



    private void Awake()
    {
        character = GetComponent<CharacterController>();
        //photonView = GetComponent<PhotonView>();
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        Setup();
    }

    private void Setup()
    {

        // CameraPlayer cameraPlayer = GetComponent<CameraPlayer>();
    }




    private void Update()
    {


        ManagePlayer();

    }




    private void ManagePlayer()
    {
        direction = _move;
        Move(direction);
    }
    private void Move(Vector3 direction)
    {
        if (direction.y == 0 && direction.x == 0)
        {
            animator.SetBool("Walk", false);
        }
        else
        {
            animator.SetBool("Walk", true);
            normDirection = new Vector3(direction.x, 0, direction.y);
            //Vector3 position = (transform.forward * _move.y * speed) + (transform.right * _move.x * speed * Time.deltaTime);
            //transform.position += position;
            agent.Move(transform.TransformDirection(normDirection) * speed * Time.deltaTime);
        }
    }
}




