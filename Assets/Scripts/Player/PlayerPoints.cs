using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*===============================================================
Product:    Action 2D Platformer
Developer:  Nihar
Company:    DeadW0Lf Games
Date:       02-02-2022 14:06:34
================================================================*/

public class PlayerPoints : MonoBehaviour {

    public UnityEvent<int> onPointsValueChange;
    public UnityEvent onPickUpPoints;

    public int Points { get; private set; }

    private void Start() {
        onPointsValueChange?.Invoke(Points);
    }

    public void Add(int amount) {
        Points += amount;
        onPickUpPoints?.Invoke();
        onPointsValueChange?.Invoke(Points);
    }
    
}
