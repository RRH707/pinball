using UnityEngine;
using System.Collections;

public class cameraMovement : MonoBehaviour
{   
    [SerializeField]
    private Transform[] _cameraPos;
    private int _indexPos = 0;
    private bool _isInPos = false;


    // Update is called once per frame
    void Update()
    {
        if(!_isInPos)
        {
            transform.position = Vector3.Lerp(transform.position, _cameraPos[_indexPos].position, Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, _cameraPos[_indexPos].rotation, Time.deltaTime);

            if (Vector3.Distance(transform.position, _cameraPos[_indexPos].position) < 0.1f && Vector3.Distance(transform.eulerAngles, _cameraPos[_indexPos].eulerAngles) < 0.1f)
            {
                _isInPos = true;
            }
        }
    }

    public void goToNextPos(int offSet = 1)
    {
        _isInPos = false;
        _indexPos = (int)Mathf.Repeat(_indexPos + offSet, _cameraPos.Length); 
    }


}
