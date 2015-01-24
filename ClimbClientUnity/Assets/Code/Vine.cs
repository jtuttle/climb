using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Vine : MonoBehaviour {
    private int _platformCount = 5;

    private List<VineLevel> _vineLevels;
    private List<LeafPlatform> _leafPlatforms;

	private VineLevel _lastLevel;
	private int _firstLevelIndex;
	private int _firstPlatformIndex;

	private bool _move = false;

	void Awake() {
        _vineLevels = new List<VineLevel>();
        _leafPlatforms = new List<LeafPlatform>();

		while(_lastLevel == null || _lastLevel.transform.position.y < Camera.main.orthographicSize - 2)
			Grow();

		_firstLevelIndex = 0;
		_firstPlatformIndex = 0;
	}
	
	void Update () {
		if(Input.GetKey(KeyCode.Space))
			_move = true;

		if(!_move) return;

		transform.position -= new Vector3(0, 0.02f);

		if(_lastLevel.transform.position.y < Camera.main.orthographicSize - 2)
			Grow();

		if(_vineLevels[_firstLevelIndex].transform.position.y < -Camera.main.orthographicSize - 1) {
			VineLevel firstLevel = _vineLevels[_firstLevelIndex];

			Destroy(firstLevel.gameObject);
			_vineLevels[_firstLevelIndex] = null;

			_firstLevelIndex++;
		}
		
		if(_leafPlatforms[_firstPlatformIndex].transform.position.y < -Camera.main.orthographicSize - 1) {
			LeafPlatform firstPlatform = _leafPlatforms[_firstPlatformIndex];

			Destroy(firstPlatform.gameObject);
			_leafPlatforms[_firstPlatformIndex] = null;

            _firstPlatformIndex++;
        }
    }
    
    private void Grow() {
        float positionSample = (Mathf.PerlinNoise(_vineLevels.Count / 10.0f, 0) - 0.5f) * 5.0f;
		float scaleSample = Mathf.PerlinNoise((_vineLevels.Count + 200) / 10.0f, 0) * 3.0f;

		Vector3 oldPos = (_lastLevel == null ? new Vector3(0, 0) : _lastLevel.transform.localPosition);

        GameObject newLevelGo = UnityUtils.LoadResource<GameObject>("Prefabs/VineLevel", true);
        newLevelGo.transform.parent = transform;
        newLevelGo.transform.localPosition = new Vector3(positionSample, oldPos.y + 0.5f, 0);
		newLevelGo.transform.localScale = new Vector3(scaleSample, 0.5f, 1.0f);

        VineLevel newLevel = newLevelGo.GetComponent<VineLevel>();

        _vineLevels.Add(newLevel);
		_lastLevel = newLevel;

        newLevel.Grow(scaleSample);

        if(--_platformCount == 0) {
            GrowPlatform(newLevelGo.transform.localPosition.y);
            _platformCount = 5;
        }
    }

    private void GrowPlatform(float vineHeight) {
		float position = Random.Range(-4.0f, 4.0f);
		int blocks = Random.Range(3, 10);

        GameObject leafPlatformGo = UnityUtils.LoadResource<GameObject>("Prefabs/LeafPlatform", true);
        leafPlatformGo.transform.parent = transform;
		leafPlatformGo.transform.localPosition = new Vector2(position, vineHeight);

		LeafPlatform leafPlatform = leafPlatformGo.GetComponent<LeafPlatform>();
		leafPlatform.Grow(blocks);

		_leafPlatforms.Add(leafPlatform);
    }
}
