using UnityEngine;
using System.Collections;

public class destroyCollider : MonoBehaviour
{
    public BallSpawner spawner;
    
    void OnTriggerEnter(Collider ball)
    {
        spawner.reloadBall();
        
    }
}
