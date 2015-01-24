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
        VineLevel lastLevel = _vineLevels[_vineLevels.Count - 1];

        GameObject newLevelGo = UnityUtils.LoadResource<GameObject>("Prefabs/VineLevel", true);
        newLevelGo.transform.parent = transform;
        newLevelGo.transform.localPosition = lastLevel.transform.localPosition + new Vector3(0, 1, 0);

        VineLevel newLevel = newLevelGo.GetComponent<VineLevel>();

        _vineLevels.Add(newLevel);

        newLevel.Grow();
    }
}
