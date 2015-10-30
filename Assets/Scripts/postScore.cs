using UnityEngine;
using System.Collections;

public class postScore : MonoBehaviour
{
    private string _url = "http://localhost/yolo/HighScore/highScore.php";
    private string _name = "Name";
    private int _score = scoreManager.singleton._score;
   
    

    IEnumerator post()
    {
        _url += "?score=" + _score.ToString() + "&name=" + _name.ToString();
        WWW postScore = new WWW(_url);
        yield return postScore;
    }

    void OnGUI()
    {
        _name = GUI.TextField(new Rect(Screen.width / 2, Screen.height / 2, 100, 20), _name);

        if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2, 200, 20), "Post"))
        {
            post();
        }
    }
    
    // Update is called once per frame
    void Update()
    {

    }
}
