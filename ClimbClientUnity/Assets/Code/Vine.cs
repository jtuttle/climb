using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Vine : MonoBehaviour {
    private bool _grow = false;

    private int _platformCount = 5;

    private List<VineLevel> _vineLevels;

    private List<LeafPlatform> _leafPlatforms;

	void Awake() {
        _vineLevels = new List<VineLevel>();
        _leafPlatforms = new List<LeafPlatform>();

        GameObject newLevel = UnityUtils.LoadResource<GameObject>("Prefabs/VineLevel", true);
        _vineLevels.Add(newLevel.GetComponent<VineLevel>());
	}
	
	void Update () {
        if(Input.GetKey(KeyCode.Space)) {
            if(!_grow) {
                _grow = true;
                Grow();
            }
        } else {
            _grow = false;
        }
	}

    private void Grow() {
        float sample = (Mathf.PerlinNoise(_vineLevels.Count / 10.0f, 0) - 0.5f) * 5.0f;

        VineLevel lastLevel = _vineLevels[_vineLevels.Count - 1];
        Vector3 oldPos = lastLevel.transform.localPosition;

        GameObject newLevelGo = UnityUtils.LoadResource<GameObject>("Prefabs/VineLevel", true);
        newLevelGo.transform.parent = transform;
        newLevelGo.transform.localPosition = new Vector3(sample, oldPos.y + 0.5f, 0);

        VineLevel newLevel = newLevelGo.GetComponent<VineLevel>();

        _vineLevels.Add(newLevel);

        newLevel.Grow();

        if(--_platformCount == 0) {
            GrowPlatform(newLevelGo.transform.localPosition.y);
            _platformCount = 5;
        }
    }


    private void GrowPlatform(float vineHeight) {
		float position = Random.Range(-10.0f, 10.0f);
		int blocks = Random.Range(3, 8);

        GameObject leafPlatformGo = UnityUtils.LoadResource<GameObject>("Prefabs/LeafPlatform", true);
        leafPlatformGo.transform.parent = transform;
		leafPlatformGo.transform.localPosition = new Vector2(0, vineHeight);

		LeafPlatform leafPlatform = leafPlatformGo.GetComponent<LeafPlatform>();
		leafPlatform.Grow(blocks);
    }
}
