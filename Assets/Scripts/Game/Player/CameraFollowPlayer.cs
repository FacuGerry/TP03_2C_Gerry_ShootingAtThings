using UnityEngine;
using UnityEngine.InputSystem;

public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField] private PlayerDataSO _data;
    [SerializeField] private Transform _cameraPos;
    [SerializeField] private Rigidbody _player;

    private float _yaw;
    private float _pitch;

    private void Start()
    {
        transform.position = _cameraPos.position;
    }

    private void Update()
    {
        LookAround();
    }

    private void LateUpdate()
    {
        FollowPlayer();
    }

    private void FollowPlayer() => transform.position = Vector3.Lerp(transform.position, _cameraPos.position, _data.cameraFollowSpeed * Time.deltaTime);

    private void LookAround()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        transform.Rotate(Vector3.up, mouseX * _data.rotationSpeedHor * Time.deltaTime);

        _yaw += mouseX * _data.rotationSpeedHor * Time.deltaTime;
        _pitch -= mouseY * _data.rotationSpeedVer * Time.deltaTime;

        _pitch = Mathf.Clamp(_pitch, _data.rotationMinVer, _data.rotationMaxVer);

        transform.localRotation = Quaternion.Euler(_pitch, _yaw, 0f);
        _player.MoveRotation(Quaternion.Euler(0f, _yaw, 0f));
    }
}