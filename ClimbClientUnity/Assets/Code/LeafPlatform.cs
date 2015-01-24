using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Holoville.HOTween;

public class LeafPlatform : MonoBehaviour {
    private List<GameObject> _leafSquares;
    
    void Awake() {
        _leafSquares = new List<GameObject>();
    }
    
    public void Grow(int width) {
        GameObject square = UnityUtils.LoadResource<GameObject>("Prefabs/LeafSquare", false);

		GameObject leafSquare = (GameObject)Instantiate(square);

		leafSquare.transform.parent = transform;
		leafSquare.transform.localScale = new Vector3(0.1f, 0.1f, 1.0f);

		TweenParms parms = new TweenParms();
		parms.Prop("localScale", new Vector3(width, 1.0f, 1.0f));
		parms.Ease(EaseType.EaseOutBounce);

		HOTween.To(leafSquare.transform, 1, parms);

		_leafSquares.Add(leafSquare);
    }
}
