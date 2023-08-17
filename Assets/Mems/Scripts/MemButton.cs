using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class MemButton : MonoBehaviour
{
    [Header ("VideoMem")]
    public VideoClip _videoMem;

    [Header("Settings")]
    [SerializeField] private bool _videoImage = false; //включение картинки видео
    [SerializeField] private long _frameVideoImage = 1; //кадр картинки видео
    [SerializeField] private long _startFramePlay = 1; //с какого кадра воспроизводится видео если 0 воспроизводит с кадра ккартинки

    [Header("VideoRender")]
    public RenderTexture _videoRender;
    public RawImage _rawImage;
    private VideoPlayer _videoPlayer;

    
    private void Awake()
    {
        //_rawImage = GetComponent<RawImage>();
        _videoRender = Instantiate(_videoRender);  //Позволяет воспроизводить одновременно разные видео
        _videoPlayer = GetComponent<VideoPlayer>();
        _rawImage.texture = _videoRender;
        _videoPlayer.clip = _videoMem;
        _videoPlayer.targetTexture = _videoRender;
    }

    private void OnEnable()
    {
        if (_videoImage)
        {
            _videoPlayer.frame = _frameVideoImage;
            _videoPlayer.playOnAwake = true;
            _videoPlayer.Pause();
        }
    }
    private void Start()
    {

    }

    public void _PlayVideo()
    {
        Debug.Log("Play " + gameObject.name);
        if(_startFramePlay > 0)
            _videoPlayer.frame = _startFramePlay;

        _videoPlayer.Play();
    }

    private void OnValidate()
    {
        if (_videoImage)
        {
            if(_videoPlayer != null)
            {
                _videoPlayer.frame = _frameVideoImage;
            }      
        }
    }
}
