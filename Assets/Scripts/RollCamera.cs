using UnityEngine;

public class RollCamera : MonoBehaviour
{
    [SerializeField] private GameObject _camera;
    [SerializeField] private GameObject _camera3D;

    private bool _cameraROLL = true;

    private void Update()
    {
        CameraRoll();
    }

    private void CameraRoll()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_cameraROLL)
            {
                _camera.SetActive(false);
                _camera3D.SetActive(true);
                _cameraROLL = false;
            }
            else
            {
                _camera.SetActive(true);
                _camera3D.SetActive(false);
                _cameraROLL = true;
            }
        }
    }
}
