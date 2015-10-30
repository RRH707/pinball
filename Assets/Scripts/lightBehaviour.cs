using UnityEngine;
using System.Collections;

public class lightBehaviour : MonoBehaviour
{
    private Color hitColor = new Color(1f, 0f, 0f);
    private Color _defaultColor;
    private bool _hit = false;
    private float _hitTimer = 0f;
    public Renderer[] _hitObjects;

    void Start()
    {
        foreach (Renderer R in _hitObjects)
        {
            _defaultColor = R.material.color;
        }
    }

    void OnCollisionEnter()
    {
        foreach (Renderer R in _hitObjects)
        {
            R.material.color = hitColor;
        }
        _hit = true;
    }

    void Update()
    {
        if (_hit)
        {
            _hitTimer += Time.deltaTime;
            if (_hitTimer >= 0.5f)
            {
                _hit = false;
                foreach (Renderer R in _hitObjects)
                {
                    R.material.color = _defaultColor;
                }
                _hitTimer = 0f;
            }
        }
    }
}
