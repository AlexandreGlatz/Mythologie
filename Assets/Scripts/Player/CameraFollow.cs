using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform player;

    [Range(0f, 1f)]
    public float Smooth;
    private float offSetY;
    private float offSetX;
    public float initOffSetY;
    public float initOffSetX;

    Vector3 shakeTarget;
    float shakeEnd;
    bool isShaking;
    public bool lowerCam = false;

    void FixedUpdate()
    {

        var playerPositon = player.position;

        if (isShaking)
        {
            if (shakeEnd < Time.time)
            {
                isShaking = false;
            }
            playerPositon.y += offSetY;
            playerPositon.x += offSetX;
            playerPositon -= shakeTarget;
            var moveVector = Vector3.Lerp(playerPositon, transform.position, .92f);
            moveVector.z = -10;
            gameObject.transform.position = moveVector;
        }
        else
        {
            if (lowerCam)
            {
                offSetX = 5f;
                offSetY = -3f;
            }
            else
            {
                offSetX = initOffSetX;
                offSetY = initOffSetY;
            }
            playerPositon.y += offSetY;
            playerPositon.x += offSetX;
            var moveVector = Vector3.Lerp(playerPositon, transform.position, Smooth);
            moveVector.z = -10;
            gameObject.transform.position = moveVector;
        }

    }
    public void ShakeCamera(float x, float y, float duration)
    {
        shakeTarget = new Vector3(x, y);
        isShaking = true;
        shakeEnd = Time.time + duration;
    }

}