using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class MemButton : MonoBehaviour
{
    [Header ("VideoMem")]
    public VideoClip _videoMem;

    [Header("Settings")]
    [SerializeField] private bool _videoImage = false; //��������� �������� �����
    [SerializeField] private long _frameVideoImage = 1; //���� �������� �����

    [Header("VideoRender")]
    public RenderTexture _videoRender;
    public RawImage _rawImage;
    private VideoPlayer _videoPlayer;

    
    void Start()
    {
        //_rawImage = GetComponent<RawImage>();
        _videoRender = Instantiate(_videoRender);  //��������� �������������� ������������ ������ �����
        _videoPlayer = GetComponent<VideoPlayer>();
        _rawImage.texture = _videoRender;
        _videoPlayer.clip = _videoMem;
        _videoPlayer.targetTexture = _videoRender;
        if (_videoImage)
        {
            _videoPlayer.frame = _frameVideoImage;
            _videoPlayer.playOnAwake = true;
            _videoPlayer.Pause();
        }
            
    }

    public void _PlayVideo()
    {
        _videoPlayer.Play();
    }

    private void OnValidate()
    {
        if (_videoImage)
        {
            if(_videoPlayer != null)
                _videoPlayer.frame = _frameVideoImage;
        }
    }
}
