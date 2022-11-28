using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private List<Transform> _segments;
    [SerializeField] private List<Transform> _surround;
    [SerializeField] private float _minDistance = 35.0f;
    [SerializeField] private Transform _player;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform lastObj = _segments[_segments.Count - 1];
        float distance = Vector3.Distance(lastObj.position, _player.position);

        if (distance < _minDistance)
        {
            Transform firstObj = _segments[0];
            Transform firstObjSurround = _surround[0];
            firstObj.position = lastObj.position;

            Vector3 offset = lastObj.GetComponent<Collider>().bounds.extents + firstObj.GetComponent<Collider>().bounds.extents;
            firstObj.position += Vector3.forward * offset.z;
            firstObjSurround.position = firstObj.position;

            _segments.Remove(firstObj);
            _segments.Add(firstObj);
            _surround.Remove(firstObjSurround);
            _surround.Add(firstObjSurround);
        }
    }
}
