using System.Collections.Generic;
using UnityEngine;

public class SnakeComponent : MonoBehaviour
{
    [SerializeField] private List<Transform> _tails;
    [SerializeField] private float _bonesDistance;
    [SerializeField] private GameObject _bonePrefab;
    [SerializeField, Range(0f, 20f)] private float _speedSnake;
    [SerializeField, Range(0f, 5f)] private float _speddSnakeAdd; 
    [SerializeField, Range(0f, 400f)] private float _rotateSnake;

    private float _angel;
    private float _sqrDistance;


    private void Start()
    {
        
    }
    private void Update()
    {
        MoveSnake(transform.position + _speedSnake * Time.deltaTime * transform.forward);
        RotateSnake();
    }

    private void MoveSnake(Vector3 newPosition)
    {
        _sqrDistance = _bonesDistance * _bonesDistance;
        Vector3 previosPosition = transform.position;
        foreach (var bone in _tails)
        {
            if ((bone.position - previosPosition).sqrMagnitude > _sqrDistance)
            {
                (previosPosition, bone.position) = (bone.position, previosPosition);
            }
            else { break; }
        }

        transform.position = newPosition;
    }
    private void RotateSnake()
    {
        _angel = Input.GetAxis("Horizontal") * _rotateSnake * Time.deltaTime;
        transform.Rotate(0f, _angel, 0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Apple"))
        {
            Destroy(collision.gameObject);
            var bone = Instantiate(_bonePrefab, transform.position, Quaternion.identity);
            _tails.Add(bone.transform);
            _speedSnake += _speddSnakeAdd;
        }
    }
}
