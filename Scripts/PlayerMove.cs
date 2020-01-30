using UnityEngine;

public class PlayerMove : MonoBehaviour {

    CharacterController characterController;
    public float walkSpeed; 

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }
    void Update()
    {
        MovePlayer();
    }
    void MovePlayer()
    {
        float Horiz = Input.GetAxis("Horizontal");
        float Vert = Input.GetAxis("Vertical");

        Vector3 moveDirSide = transform.right * Horiz * walkSpeed;
        Vector3 moveDirForward = transform.forward * Vert * walkSpeed;
        characterController.SimpleMove(moveDirSide);
        characterController.SimpleMove(moveDirForward);
    }

   
}
