using UnityEngine;

public class CameraManager : MonoBehaviour
{
    Transform player;
    public float Speed = 0.125f;
    public Vector3 offset;
    Vector3 CameraPos;
    private void Start()
    {
        Camera.main.backgroundColor = ItemManager.instance.color;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void LateUpdate()
    {
        CameraPos = player.position + offset;
        Vector3 Position = Vector3.Lerp(transform.position, CameraPos, Speed);
        transform.position = Position;
    }
}