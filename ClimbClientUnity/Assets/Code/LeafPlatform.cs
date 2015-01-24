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

		float startX = -(width * 0.5f) / 2;

		for(int i = 0; i < width; i++) {
			GameObject leafSquare = (GameObject)Instantiate(square);

			leafSquare.transform.parent = transform;
			leafSquare.transform.localPosition = new Vector2(startX + i * 0.5f, 0);

			_leafSquares.Add(leafSquare);
		}
    }
}
