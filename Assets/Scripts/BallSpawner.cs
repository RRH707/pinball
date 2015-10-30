using UnityEngine;
using System.Collections;

public class BallSpawner : MonoBehaviour
{
    public float force;
    public GameObject ballPrefab;
    private bool _start = false;
    private GameObject _ball;
    private int _spawnCounter;

    // Use this for initialization
    void Start()
    {
        loadBall();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            shootBall();
            _spawnCounter += 1;
        }

        if(_spawnCounter >= 3)
        {
            Application.LoadLevel(1);
        }
    }
    private void loadBall()
    {
       _ball = (GameObject)Instantiate(ballPrefab, this.transform.position, Quaternion.identity);
    }

    private void shootBall()
    {
        if (_start) return;

        _start = true;
       
        _ball.GetComponent<Rigidbody>().AddForce(0, force, 0);
    }

    public void reloadBall()
    {
        if (!_start) return;

        _start = false;
        Destroy(_ball, 1f);
        loadBall();

    }
}
