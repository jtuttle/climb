using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Vine : MonoBehaviour {
    private List<VineLevel> _vineLevels;
    private List<LeafPlatform> _leafPlatforms;

    private VineLevel _lastLevel;
    private int _firstLevelIndex;
    private int _firstPlatformIndex;

    private int _nextPlatform;

    private bool _move = false;
    private bool _left = false;

    void Awake() {
		Reset();
    }

    void Update () {
        if(!_move) return;

		transform.position -= new Vector3(0, 0.4f) * Time.deltaTime;

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

	public void Begin() {
		_move = true;
	}

	public void Stop() {
		_move = false;
	}

	public void Reset() {
		_move = false;

		if(_vineLevels != null) {
			foreach(VineLevel level in _vineLevels) {
				if(level != null)
					GameObject.Destroy(level.gameObject);
			}
		}
		
		if(_leafPlatforms != null) {
			foreach(LeafPlatform platform in _leafPlatforms) {
				if(platform != null)
					GameObject.Destroy(platform.gameObject);
			}
		}
		
		_vineLevels = new List<VineLevel>();
		_leafPlatforms = new List<LeafPlatform>();
		
		_firstLevelIndex = 0;
		_firstPlatformIndex = 0;
		_lastLevel = null;
		
		_nextPlatform = Random.Range(2, 5);

		transform.position = new Vector3(0, -4, 0);

		while(_lastLevel == null || _lastLevel.transform.position.y < Camera.main.orthographicSize - 2)
			Grow();
	}
    
    private void Grow() {
        float positionXSample = (Mathf.PerlinNoise(_vineLevels.Count / 10.0f, 0) - 0.5f) * 4.0f;
        float scaleSample = Mathf.Max(2.0f, Mathf.PerlinNoise((_vineLevels.Count + 200) / 10.0f, 0) * 4.0f);

        Vector3 oldPos = (_lastLevel == null ? new Vector3(0, 0) : _lastLevel.transform.localPosition);

        GameObject newLevelGo = UnityUtils.LoadResource<GameObject>("Prefabs/VineLevel", true);
        newLevelGo.transform.parent = transform;
        newLevelGo.transform.localPosition = new Vector3(positionXSample, oldPos.y + 0.5f, 0);
        newLevelGo.transform.localScale = new Vector3(scaleSample, 0.5f, 1.0f);

        VineLevel newLevel = newLevelGo.GetComponent<VineLevel>();

        _vineLevels.Add(newLevel);
        _lastLevel = newLevel;

        newLevel.Grow(scaleSample);

        if(--_nextPlatform == 0) {
            GrowPlatform(newLevelGo.transform.localPosition.y);
            _nextPlatform = Random.Range(3, 5);
        }
    }

    private void GrowPlatform(float vineHeight) {
        float position;
        
        if(_left)
            position = Random.Range(-4.0f, -1.5f);
        else
            position = Random.Range(1.5f, 4.0f);
        
        _left = !_left;
        
        int blocks = Random.Range(3, 8);
        
        GameObject leafPlatformGo = UnityUtils.LoadResource<GameObject>("Prefabs/LeafPlatform", true);
        leafPlatformGo.transform.parent = transform;
        
        LeafPlatform leafPlatform = leafPlatformGo.GetComponent<LeafPlatform>();
		leafPlatform.Grow(blocks);
		
//		float platformTilt = Random.Range(-10.0f, 10.0f);
		
		leafPlatformGo.transform.localPosition = new Vector2(position, vineHeight);
//		leafPlatformGo.transform.localEulerAngles = new Vector3(0, 0, platformTilt);
		
		_leafPlatforms.Add(leafPlatform);
	}
}
