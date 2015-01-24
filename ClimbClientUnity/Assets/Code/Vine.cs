using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Vine : MonoBehaviour {
    private bool _grow = false;

    private List<VineLevel> _vineLevels;

	void Awake() {
        _vineLevels = new List<VineLevel>();

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
        float sample = (Mathf.PerlinNoise(_vineLevels.Count / 10.0f, 0) - 0.5f) * 10.0f;

        VineLevel lastLevel = _vineLevels[_vineLevels.Count - 1];
        Vector3 oldPos = lastLevel.transform.localPosition;

        GameObject newLevelGo = UnityUtils.LoadResource<GameObject>("Prefabs/VineLevel", true);
        newLevelGo.transform.parent = transform;
        newLevelGo.transform.localPosition = new Vector3(sample, oldPos.y + 1, 0);

        VineLevel newLevel = newLevelGo.GetComponent<VineLevel>();

        _vineLevels.Add(newLevel);

        newLevel.Grow();
    }
}
