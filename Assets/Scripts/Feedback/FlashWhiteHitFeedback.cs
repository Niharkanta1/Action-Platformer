using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*===============================================================
Product:    Action 2D Platformer
Developer:  Nihar
Company:    DeadW0Lf Games
Date:       31-01-2022 15:11:17
================================================================*/

public class FlashWhiteHitFeedback : MonoBehaviour {

    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float feedbackTime = 0.1f;

    public void PlayFeedback() {
        if(spriteRenderer == null || spriteRenderer.material.HasProperty("_MakeSolidColor") == false) 
            return;
        ToggleMaterial(1);
        StopAllCoroutines();
        StartCoroutine(ResetColor());
    }

    private IEnumerator ResetColor() {
        yield return new WaitForSeconds(feedbackTime);
        ToggleMaterial(0);
    }

    private void ToggleMaterial(int value) {
        value = Mathf.Clamp(value, 0, 1);
        spriteRenderer.material.SetInt("_MakeSolidColor", value);
    }
    
    
}
