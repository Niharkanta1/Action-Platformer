using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ScoreUI : MonoBehaviour {

    private TextMeshProUGUI pointsText;
    public UnityEvent onTextChange;

    private void Awake() {
        pointsText = GetComponentInChildren<TextMeshProUGUI>();
    }
    
    public void SetPoints(int value) {
        pointsText.SetText(value.ToString());
        onTextChange?.Invoke();
    }
}
