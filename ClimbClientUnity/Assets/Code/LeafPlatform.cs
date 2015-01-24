using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LeafPlatform : MonoBehaviour {
    private List<GameObject> _leafSquares;
    
    void Awake() {
        _leafSquares = new List<GameObject>();
    }
    
    public void Grow(int width) {
        GameObject square = UnityUtils.LoadResource<GameObject>("Prefabs/LeafSquare", false);


        for
        
        square.transform.parent = transform;
        square.transform.localPosition = Vector3.zero;
        _leafSquares.Add(square);
    }
}
