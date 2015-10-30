using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class scoreManager : MonoBehaviour
{
    public static scoreManager singleton;
    [SerializeField]
    public int  _score = 0;
    private int _currentScoreIndex = 0;
    [SerializeField]
    private Text _scoreIndicator;
    [SerializeField]
    private cameraMovement _camera;


    void Start()
    {
        singleton = this;
        applyScore();
    }

    void applyScore()
    {
        _scoreIndicator.text = "Score: " + _score.ToString();
        int newIndex = (int)Mathf.Floor(_score / 500f);
        if(newIndex != _currentScoreIndex)
        {
            
            _currentScoreIndex = newIndex;
            _camera.goToNextPos();
     
            
        }
    }

    public void addScore(int points)
    {
        _score += points;
        applyScore();
    }

    
   
            

}
