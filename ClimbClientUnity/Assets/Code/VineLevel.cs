using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Holoville.HOTween;

public class VineLevel : MonoBehaviour {
    private List<GameObject> _vineSquares;

    void Awake() {
        _vineSquares = new List<GameObject>();
    }

    public void Grow(float scaleX) {
        GameObject square = UnityUtils.LoadResource<GameObject>("Prefabs/VineSquare", true);
        square.transform.parent = transform;
        square.transform.localPosition = Vector3.zero;
        _vineSquares.Add(square);

		square.transform.localScale = new Vector3(0.05f, 0.8f, 1.0f);

		HOTween.To(square.transform, 10, "localScale", new Vector3(scaleX, 1.0f, 1.0f));
    }
}
