using System.Collections;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public class Yandex : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void ReclamaData();

    [DllImport("__Internal")]
    private static extern void Hello();

    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private RawImage _photo;

    private void Start()
    {
        ReclamaData();
        Hello();
    }  

    public void SetName(string name) => _nameText.text = name;
    public void SetPhoto(string url) => StartCoroutine(DownloadImage(url));

    IEnumerator DownloadImage(string mediaUrl)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(mediaUrl);
        yield return request.SendWebRequest();
        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            Debug.Log(request.error);
        else
            _photo.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
    }
}