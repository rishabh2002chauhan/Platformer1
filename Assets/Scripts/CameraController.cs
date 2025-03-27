using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float speed;
    private float currPosX;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private Transform player;
    [SerializeField] private float cameraSpeed, aheadDistance;
    private float lookahead;

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currPosX, transform.position.y, transform.position.z), ref velocity, speed);

        transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
        lookahead = Mathf.Lerp(lookahead, (aheadDistance * player.localScale.x), Time.deltaTime * cameraSpeed);
    }

    public void MoveToNewRoom(Transform newRoom)
    {
        currPosX = newRoom.position.x;
    }
}
