using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LifeElementUI : MonoBehaviour {

    private Image _image;
    public UnityEvent onSpriteChange;

    private void Awake() {
        _image = GetComponent<Image>();
    }

    public void SetSprite(Sprite sprite) {
        if (_image.sprite != sprite) {
            onSpriteChange?.Invoke();
            _image.sprite = sprite;
        }
    }
}
