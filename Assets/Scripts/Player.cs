using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]private float movSpeed = 7;
    [SerializeField] private GameInput gameInput;

    private bool isWalking;

    private void Update()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        float rotateSpeed = 10f;
        float moveDistance = Time.deltaTime * rotateSpeed;
        float playerRadius = 0.7f;
        float playerHeight = 2f;
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDir, moveDistance);

        if(!canMove)
        {
            Vector3 moveDirX = new Vector3(moveDir.x, 0, 0);
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirX, moveDistance);

            if(canMove)
            {
                moveDir = moveDirX.normalized;
            } else
            {
                Vector3 moveDirZ = new Vector3(moveDir.x, 0, 0);
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirZ, moveDistance);

                if (canMove)
                {
                    moveDir = moveDirZ.normalized;
                }
            }
        }

        if (canMove) transform.position += moveDir * Time.deltaTime * movSpeed;

        isWalking = moveDir != Vector3.zero;

        transform.forward = Vector3.Slerp(transform.forward, moveDir, moveDistance);
    }

    public bool IsWalking()
    {
        return isWalking;
    }
}
