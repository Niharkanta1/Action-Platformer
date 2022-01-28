using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class HealthUI : MonoBehaviour {

    private List<LifeElementUI> _healthImages;
    [SerializeField] private Sprite fullHealth, emptyHealth;
    [SerializeField] private LifeElementUI healthPrefab;

    public void Initialize(int maxHealth) {
        _healthImages = new List<LifeElementUI>();
        foreach (Transform child in transform) {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < maxHealth; i++) {
            var life = Instantiate(healthPrefab, transform, false);
            _healthImages.Add(life);
        }
    }

    public void SetHealth(int currentHealth) {
        for (int i = 0; i < _healthImages.Count; i++) {
            if (i < currentHealth) {
                _healthImages[i].SetSprite(fullHealth);
            } else {
                _healthImages[i].SetSprite(emptyHealth);
            }
        }
    }
}
