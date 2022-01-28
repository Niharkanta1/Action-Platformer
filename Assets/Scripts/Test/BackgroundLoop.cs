using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Currently not working as expected.
public class BackgroundLoop : MonoBehaviour {

    public GameObject[] levels;
    private Camera mainCamera;
    private Vector2 screenBounds;
    public float choke = 0.25f;

    private void Start() {
        mainCamera = gameObject.GetComponent<Camera>();
        screenBounds =
            mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        foreach (var obj in levels) {
            LoadChildObjects(obj);
        }
    }

    private void LoadChildObjects(GameObject obj) {
        float objectWidth = obj.GetComponent<SpriteRenderer>().bounds.size.x - choke;
        int childNeeded = (int) Mathf.Ceil(screenBounds.x * 2 / objectWidth);
        GameObject clone = Instantiate(obj);
        for (int i = 0; i <= childNeeded; i++) {
            GameObject c = Instantiate(clone);
            c.transform.SetParent(obj.transform);
            c.transform.position = new Vector3(objectWidth * i, obj.transform.position.y, obj.transform.position.z);
            obj.name = obj.name + i;
        }
        Destroy(clone);
        Destroy(obj.GetComponent<SpriteRenderer>());
    }

    private void LateUpdate() {
        foreach (var obj in levels) {
            repositionChildObjects(obj);
        }
    }

    private void repositionChildObjects(GameObject obj) {
        Transform[] children = obj.GetComponentsInChildren<Transform>();
        if (children.Length > 1) {
            GameObject firstChild = children[1].gameObject;
            GameObject lastChild = children[children.Length - 1].gameObject;
            float halfObjectWidth = lastChild.GetComponent<SpriteRenderer>().bounds.extents.x - choke;
            if (transform.position.x + screenBounds.x > lastChild.transform.position.x + halfObjectWidth) {
                firstChild.transform.SetAsLastSibling();
                firstChild.transform.position = new Vector3(lastChild.transform.position.x + halfObjectWidth * 2,
                    lastChild.transform.position.y, lastChild.transform.position.z);
            } else if (transform.position.x + screenBounds.x > lastChild.transform.position.x - halfObjectWidth) {
                lastChild.transform.SetAsFirstSibling();
                lastChild.transform.position = new Vector3(firstChild.transform.position.x - halfObjectWidth * 2,
                    firstChild.transform.position.y, firstChild.transform.position.z);
            }
        }
    }
}
