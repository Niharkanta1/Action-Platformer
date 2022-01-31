using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening.Core.Easing;
using UnityEngine;
using WeaponSystem;

/*===============================================================
Product:    Action 2D Platformer
Developer:  Nihar
Company:    DeadW0Lf Games
Date:       31-01-2022 15:49:19
================================================================*/

public class HittableTempImmortality : MonoBehaviour, IHittable {

    public Collider2D[] colliders = Array.Empty<Collider2D>();
    public SpriteRenderer spriteRenderer;
    public float immortalityTime = 1;
    public float flashDelay = 0.1f;
    [Range(0, 1)] public float flashAlpha = 0.5f;

    [Header("Debug: ")] public bool isImmortal = false;

    private void Awake() {
        if (colliders.Length == 0) {
            colliders = GetComponents<Collider2D>();
        }
    }

    public void GetHit(GameObject agentGameObject, int weaponDamage) {
        if(this.enabled == false) return;
        ToggleColliders(false); // Disable collider 
        StartCoroutine(ResetColliders()); // Reset Collider after immortal time
        StartCoroutine(Flash(flashAlpha)); // Flash the Sprite 
    }

    private void ToggleColliders(bool val) {
        isImmortal = !val;
        foreach (var col in colliders) {
            col.enabled = val;
        }
    }

    private IEnumerator Flash(float alpha) {
        alpha = Mathf.Clamp01(alpha);
        ChangeSpriteRendererColorAlpha(alpha);
        yield return new WaitForSeconds(flashDelay);
        StartCoroutine(Flash(alpha < 1 ? 1 : flashAlpha));
    }

    private IEnumerator ResetColliders() {
        yield return new WaitForSeconds(immortalityTime);
        StopAllCoroutines();
        ToggleColliders(true);
        ChangeSpriteRendererColorAlpha(1);  
    }

    private void ChangeSpriteRendererColorAlpha(float alpha) {
        var c = spriteRenderer.color;
        c.a = alpha;
        spriteRenderer.color = c;
    }   
}
