using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/*===============================================================
Product:    Action 2D Platformer
Developer:  Nihar
Company:    DeadW0Lf Games
Date:       02-02-2022 15:51:03
================================================================*/
namespace DFG.UI {

    public class UIScaleTextFont : MonoBehaviour {
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private float fontAnimationTime = 0.3f;
        [SerializeField] private float fontAnimationSize = 80;
        private float _baseFontSize;

        private void Awake() {
            _baseFontSize = text.fontSize;
        }

        public void PlayAnimation() {
            StopAllCoroutines();
            text.fontSize = _baseFontSize;
            StartCoroutine(AnimateText(fontAnimationTime)); 
        }

        private IEnumerator AnimateText(float animationTime) {
            float time = 0;
            float delta = fontAnimationSize - _baseFontSize;
            while (time < animationTime) {
                time += Time.deltaTime;
                float newFontSize = _baseFontSize + delta * (time / animationTime);
                text.fontSize = newFontSize;
                yield return null;
            }
            text.fontSize = _baseFontSize;
        }
    }
}
