using UnityEngine;

public class LevelUP : MonoBehaviour
{
    [SerializeField] private MenuManager _menuManager;
    [SerializeField] private GameObject _cub4;
    [SerializeField] private GameObject _cub5;
    [SerializeField] private GameObject _cub6;
    [SerializeField] private GameObject _cub7;
    private void Update()
    {
        AddCub(_cub4, 10);
        AddCub(_cub5, 20);
        AddCub(_cub6, 30);
        AddCub(_cub7, 40);
    }
    private void AddCub(GameObject gameObject, int score )
    {
        if (_menuManager.Score >= score) gameObject.SetActive( true );
        else gameObject.SetActive( false );
    }
}
