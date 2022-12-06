using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    [SerializeField] private bool useEdgeScrolling = false;

    private bool dragPanMoveActive;
    private Vector2 lastMousePosition;

    private void Update()
    {
        Vector3 inputDir = new Vector3(0, 0, 0);

        if (Input.GetKey(KeyCode.Z)) inputDir.z = +1f;
        if (Input.GetKey(KeyCode.S)) inputDir.z = -1f;
        if (Input.GetKey(KeyCode.Q)) inputDir.x = -1f;
        if (Input.GetKey(KeyCode.D)) inputDir.x = +1f;


        if (useEdgeScrolling)
        {
            int edgeScrollSize = 20;

            if (Input.mousePosition.x < edgeScrollSize)
            {
                inputDir.x = -1f;
            }
            if (Input.mousePosition.y < edgeScrollSize)
            {
                inputDir.z = -1f;
            }
            if (Input.mousePosition.x > Screen.width - edgeScrollSize)
            {
                inputDir.x = +1f;
            }
            if (Input.mousePosition.y > Screen.height - edgeScrollSize)
            {
                inputDir.z = +1f;
            }
        }


        if (Input.GetMouseButtonDown(1))
        {
            dragPanMoveActive = true;
            lastMousePosition = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(1))
        {
            dragPanMoveActive = false;
        }

        if (dragPanMoveActive)
        {
            Vector2 mouseMovementDelta = (Vector2)Input.mousePosition - lastMousePosition;

            float dragPanSpeed = 0.3f;
            inputDir.x = mouseMovementDelta.x * dragPanSpeed;
            inputDir.z = mouseMovementDelta.y * dragPanSpeed;

            lastMousePosition = Input.mousePosition;
        }


        Vector3 moveDir = transform.forward * inputDir.z + transform.right * inputDir.x;

        float moveSpeed = 50f;
        transform.position += moveDir * moveSpeed * Time.deltaTime;

        float rotateDir = 0f;
        if (Input.GetKey(KeyCode.A)) rotateDir = +1f;
        if (Input.GetKey(KeyCode.E)) rotateDir = -1f;

        float rotateSpeed = 100f;
        transform.eulerAngles += new Vector3(0, rotateDir * rotateSpeed * Time.deltaTime, 0);
    }
}
