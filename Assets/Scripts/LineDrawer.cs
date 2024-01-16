using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawer : MonoBehaviour
{
    [SerializeField] private GameObject _linePrefab;
    [SerializeField] private GameObject _player;
    [Space]
    [SerializeField] private GameObject _line;
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private List<Vector2> _playerPos;
    // Start is called before the first frame update
    void Start()
    {
        CreateLine(_player.transform.position);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        UpdateLine(_player.transform.position);
    }

    void CreateLine(Vector3 playerPosition)
    {
        _line = Instantiate(_linePrefab,Vector3.zero,Quaternion.identity);
        _lineRenderer = _line.GetComponent<LineRenderer>();
        _playerPos.Clear();
        _playerPos.Add(Camera.main.ScreenToWorldPoint(playerPosition));
        _playerPos.Add(Camera.main.ScreenToWorldPoint(playerPosition));
        _lineRenderer.SetPosition(0, _playerPos[0]);
        _lineRenderer.SetPosition(1, _playerPos[1]);
    }

    void UpdateLine(Vector3 playerPosition)
    {
        if (_line != null)
        {
            _playerPos.Add(Camera.main.ScreenToWorldPoint(playerPosition));
            _lineRenderer.positionCount++;
            _lineRenderer.SetPosition(_lineRenderer.positionCount - 1, playerPosition);
        }
    }
}
