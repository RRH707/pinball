using UnityEngine;
using System.Collections;

public class dropTargetBehaviour : MonoBehaviour
{
    private bool _isDown = false;
    private bool _isMoving = false;
    private Vector3 _spawnPoint;
    private Vector3 _targetPoint;
    private float _idleTimer = 0f;
    [SerializeField]
    private float _maxIdleTime = 1f;
    [SerializeField]
    private float _downMovement = -5;

    void Start()
    {
        _spawnPoint = transform.position;
        _targetPoint = _spawnPoint + new Vector3(0, 0, _downMovement);
    }

    void OnCollisionEnter()
    {
        dropDown();
    }

    void dropDown()
    {
        if (_isDown) return;
        _isDown = true;
        _isMoving = true;
    }

    void goUp()
    {
        if (!_isDown) return;
        _isDown = false;
        _isMoving = true;
    }

    void Update()
    {
        if (_isMoving)
        {
            if (_isDown)
            {
                transform.position = Vector3.Lerp(transform.position, _targetPoint, Time.deltaTime);
                if (Vector3.Distance(transform.position, _targetPoint) < 0.1f)
                {
                    _isMoving = false;
                }
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, _spawnPoint, Time.deltaTime);
                if(Vector3.Distance(transform.position, _spawnPoint) < 0.1f)
                {
                    _isMoving = false;
                }
            }
        }
        else if (_isDown)
        {
            _idleTimer += Time.deltaTime;

            if (_idleTimer >= _maxIdleTime)
            {
                goUp();
            }
        }


    }
}
