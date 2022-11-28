using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChrctrController : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _speed = 6.0f;
    [SerializeField] private float _sideSpeed = 2.0f;
    [SerializeField] private float _deadZoneRotation = 10.0f;

    private Rigidbody _player;

    // Start is called before the first frame update
    void Start()
    {
        _player = GetComponent<Rigidbody>();
    }

    // Update is called once per frame 
    void Update()
    {
        Vector3 dir = _player.velocity;

        if (_camera.transform.rotation.eulerAngles.z > _deadZoneRotation
            && _camera.transform.rotation.eulerAngles.z <= 180)
        {
            dir.x = _camera.transform.rotation.eulerAngles.z * -1 * Time.deltaTime * _sideSpeed;
        }
        if (_camera.transform.rotation.eulerAngles.z > 180
            && _camera.transform.rotation.eulerAngles.z <= 360 - _deadZoneRotation)
        {
            dir.x = (360 - _camera.transform.rotation.eulerAngles.z) * Time.deltaTime * _sideSpeed;
        }

        dir.x = Input.GetAxis("Horizontal") * _sideSpeed;
        dir.z = _speed;
        _player.velocity = dir;
    }
}
