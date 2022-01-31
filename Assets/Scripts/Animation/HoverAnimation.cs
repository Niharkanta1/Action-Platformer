using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

/*===============================================================
Product:    Action 2D Platformer
Developer:  Nihar
Company:    DeadW0Lf Games
Date:       31-01-2022 23:00:58
================================================================*/

public class HoverAnimation : MonoBehaviour {
    [SerializeField] private float movementDistance = 0.5f;
    [SerializeField] private float animationDuration = 1;
    [SerializeField] private Ease animationEase;

    private void Start() {
        transform.DOMoveY(transform.position.y + movementDistance, animationDuration)
            .SetEase(animationEase)
            .SetLoops(-1, LoopType.Yoyo);
    }

    private void OnDisable() {
        DOTween.Kill(transform);
    }
}
