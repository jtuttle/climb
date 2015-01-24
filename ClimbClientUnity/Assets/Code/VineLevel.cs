using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VineLevel : MonoBehaviour {
    private List<GameObject> _vineSquares;

    void Awake() {
        _vineSquares = new List<GameObject>();
    }

    public void Grow() {
        GameObject square = UnityUtils.LoadResource<GameObject>("Prefabs/VineSquare", true);
        square.transform.parent = transform;
        square.transform.localPosition = Vector3.zero;
        _vineSquares.Add(square);
    }
}
