using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TutorialHandler : MonoBehaviour
{
    [SerializeField] private GameObject _tutorialWindow;
    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _text;

    [SerializeField] private List<TutorialContent> _contents;
    private int _contentId;

    private void Start()
    {
        UpdateContent();
        ServiceLocator.Instance.Get<SceneController>().SetPause(true);
    }

    private void UpdateContent()
    {
        if (_contentId < _contents.Count)
        {
            _image.sprite = _contents[_contentId].Sprite;
            _text.text= _contents[_contentId].Text;
            _contentId++;
        }
        else 
        {
            ServiceLocator.Instance.Get<SceneController>().SetPause(false);
            _tutorialWindow.gameObject.SetActive(false);
        }
    }

    public void OnButtonNextClick()
    {
        UpdateContent();
    }

}


[Serializable]
public struct TutorialContent
{
    public Sprite Sprite;

    [TextArea]
    public String Text;
}