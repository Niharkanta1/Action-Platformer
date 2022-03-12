using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

/*===============================================================
Product:    Action 2D Platformer
Developer:  Nihar
Company:    DeadW0Lf Games
Date:       31-01-2022 21:10:58
================================================================*/
namespace DWG.UI {
    
    public class UIScaleElement : MonoBehaviour {
        
        [SerializeField] private RectTransform element;
        [SerializeField] private float animationEndScale;
        [SerializeField] private float animationTime;
        [SerializeField] private bool playConstantly;
        
        private float _baseScaleValue;
        private Vector3 _baseScale, _endScale;
        private Sequence _sequence;

        private void Start() {
            _baseScale = element.localScale;
            // Its a temporary UI bug fix while transitioning to next level.
            if (_baseScale.magnitude <= 0) {
                _baseScale = Vector3.one; 
            }
            _endScale = Vector3.one * animationEndScale;

            if (!playConstantly) return;
            _sequence = DOTween.Sequence()
                .Append(element.DOScale(_baseScale, animationTime))
                .Append(element.DOScale(_endScale, animationTime));
            _sequence.SetLoops(-1, LoopType.Yoyo);
            _sequence.Play();
        }

        public void PlayAnimation() {
            StopAllCoroutines();
            element.localScale = _baseScale;
            StartCoroutine(ScaleImage(true));
        }

        private IEnumerator ScaleImage(bool scaleUp) {
            float time = 0;
            while (time < animationTime) {
                time += Time.deltaTime;
                float value = time / animationTime;
                Vector3 currentScale;
                if (scaleUp) {
                    currentScale = _baseScale + value * (_endScale - _baseScale);
                } else {
                    currentScale = _endScale - value * (_endScale - _baseScale);
                }

                element.localScale = currentScale;
                yield return null;
            }

            element.localScale = scaleUp ? _endScale : _baseScale;
            if (playConstantly || scaleUp)
                StartCoroutine(ScaleImage(!scaleUp));
        }

        private void OnDestroy() {
            _sequence?.Kill();
        }
    }
}

