using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    CharacterController characterController;
    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public float CoolDown = 3.0f;
    public float SceneCooldown = 0.3f;
    private float CurrentCooldown = 1.0f;
    private float CurrentSceneCooldown = 1.0f;
    private bool MoveNextUpdate = false;
    private bool MoveLeft = true;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        if(MoveNextUpdate)
        {
            print("moving from " + gameObject.transform.position);
            if(MoveLeft)
            {
                gameObject.transform.position = gameObject.transform.position + new Vector3(3.0f, 0.0f, 0.0f);// = new Vector3(-2.0f, 12.0f, 0.0f);
            }
            else
            {
                gameObject.transform.position = gameObject.transform.position + new Vector3(-3.0f, 0.0f, 0.0f);// = new Vector3(-2.0f, 12.0f, 0.0f);
            }
            MoveLeft = !MoveLeft;
            print("moving to " + gameObject.transform.position);
            CurrentCooldown = CoolDown;
            CurrentSceneCooldown = SceneCooldown;
            MoveNextUpdate = false;
            return;
        }
        if (CurrentCooldown > 0.0f)
        {
            CurrentCooldown -= Time.deltaTime;
//            return;

        }
        if (CurrentSceneCooldown > 0.0f)
        {
            CurrentSceneCooldown -= Time.deltaTime;
            return;
        }
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);// Input.GetAxis("Vertical"));
        if (characterController.isGrounded)
        {
            // We are grounded, so recalculate
            // move direction directly from axes
            moveDirection *= speed;

        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        moveDirection.y -= gravity * Time.deltaTime;

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "SideWall")
        {
            if (CurrentCooldown < 0.0f)
            {
                MoveNextUpdate = true;
                print("Player Collision");
                //               characterController.Move(new Vector3(9.0f, 0.0f, 0.0f));
//                print("moving from " + gameObject.transform.position);
//                gameObject.transform.position = gameObject.transform.position + new Vector3(9.0f, 0.0f, 0.0f);// = new Vector3(-2.0f, 12.0f, 0.0f);
//                print("moving to " + gameObject.transform.position);

            }
        }
//        print("Collider with " + collision.gameObject.tag);
    }
}
