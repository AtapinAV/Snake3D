using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SnakeComponent : MonoBehaviour
{
    [SerializeField] private List<Transform> _tails;
    [SerializeField] private List<Transform> _spawnApple;
    [SerializeField] private float _bonesDistance;
    [SerializeField] private GameObject _bonePrefab;
    [SerializeField] private GameObject _applePrefab;
    [SerializeField, Range(0f, 20f)] private float _speedSnake;
    [SerializeField, Range(0f, 5f)] private float _speddSnakeAdd; 
    [SerializeField, Range(0f, 500f)] private float _rotateSnake;
    [SerializeField] private AudioSource _clip;
    [SerializeField] private Transform _bodyPos;
    [SerializeField] private UnityEvent _onEat;

    private float _angel;
    private float _sqrDistance;

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
            var spawn = Random.Range(0, _spawnApple.Count);
            Destroy(collision.gameObject);
            var bone = Instantiate(_bonePrefab, _bodyPos.transform.position, Quaternion.identity);           
            _tails.Add(bone.transform);            
            Instantiate(_applePrefab, _spawnApple[spawn].transform.position, Quaternion.identity);
            _speedSnake += _speddSnakeAdd;
            _onEat?.Invoke();
        }
        if (collision.gameObject.CompareTag("Body"))
        {
            _clip.Play();
            _speedSnake = 0f;
            _rotateSnake = 0f;
            StartCoroutine(NewGame());
        }
    }

    private IEnumerator NewGame()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Level1");
    }
}
