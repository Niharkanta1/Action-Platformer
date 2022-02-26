using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

/*===============================================================
Product:    Action 2D Platformer
Developer:  Nihar
Company:    DeadW0Lf Games
Date:       05-02-2022 22:09:15
================================================================*/
namespace DWG.UI {

    public class UIShakeElement : MonoBehaviour {
        public RectTransform element;

        [Header("Shake Animation Settings:")] 
        public float animationTime = 0.5f, shakeStrength = 90, randomness = 90;

        public int vibrato = 90;
        public bool fadeOut = true;
        public float delayBetweenShakes = 3;

        private Sequence _sequence;

        private void Start() {
            if (element.GetComponent<Button>().interactable == false) return;
            _sequence = DOTween.Sequence()
                .Append(element.DOShakeRotation(animationTime, shakeStrength, vibrato, randomness, fadeOut));
            _sequence.SetLoops(-1, LoopType.Restart);
            _sequence.AppendInterval(delayBetweenShakes);
            _sequence.Play();
        }

        private void OnDestroy() {
            _sequence.Kill();
        }
    }
}
