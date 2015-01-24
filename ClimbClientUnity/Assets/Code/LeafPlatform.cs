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

		List<GameObject> grassTiles = new List<GameObject>();
				for (int i = 1; i <= 5; i++) 
					grassTiles.Add (UnityUtils.LoadResource<GameObject> ("Prefabs/GrassTile" + i, false));


		float startX = -(width * 0.5f) / 2;
		
		for(int i = 0; i < width; i++) {
			int tile = Random.Range(1, 5);
			GameObject leafSquare = (GameObject)Instantiate(grassTiles[tile]);
			
			leafSquare.transform.parent = transform;
			leafSquare.transform.localScale = new Vector3(1.0f, 0.5f, 1.0f);
			leafSquare.transform.localPosition = new Vector2(startX + i * 0.5f, 0);
			
			_leafSquares.Add(leafSquare);
		}

//		List<GameObject> grassTiles = new List<GameObject>();
//		for (int i = 1; i < 5; i++) 
//			grassTiles.Add (UnityUtils.LoadResource<GameObject> ("Prefabs/GrassTile" + i, false));
//
//		int tile = Random.Range(1, 5);
//
//			            
//		GameObject leafSquare = (GameObject)Instantiate(grassTiles[tile]);
//
//		leafSquare.transform.parent = transform;
//		leafSquare.transform.localScale = new Vector3(0.1f, 0.1f, 1.0f);
//
//		TweenParms parms = new TweenParms();
//		parms.Prop("localScale", new Vector3(width, 1.0f, 1.0f));
//		parms.Ease(EaseType.EaseOutBounce);
//
//		HOTween.To(leafSquare.transform, 1, parms);
//
//		_leafSquares.Add(leafSquare);
    }
}
