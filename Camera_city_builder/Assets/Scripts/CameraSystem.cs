using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour
{


    private void Update()
    {
        Vector3 inputDir = new Vector3(0, 0, 0);

        if (Input.GetKey(KeyCode.Z)) inputDir.z = +1f;
        if (Input.GetKey(KeyCode.S)) inputDir.z = -1f;
        if (Input.GetKey(KeyCode.Q)) inputDir.x = -1f;
        if (Input.GetKey(KeyCode.D)) inputDir.x = +1f;

        Vector3 moveDir = transform.forward * inputDir.z + transform.right * inputDir.x;

        float moveSpeed = 50f;
        transform.position += moveDir * moveSpeed * Time.deltaTime;
    }
}
