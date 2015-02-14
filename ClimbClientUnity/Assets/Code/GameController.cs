using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {
	private Vine _vine;
	private Ground _ground;

	private List<PlayerControl> _players;

	private string _victorName;

	private GUIStyle _instructStyle;
	private GUIStyle _victorStyle;

	void Start() {
		_vine = GameObject.Find("Vine").GetComponent<Vine>();
		_ground = GameObject.Find("Ground").GetComponent<Ground>();

		_players = new List<PlayerControl>();
		_players.Add(GameObject.Find("Player 1").GetComponent<PlayerControl>());
		_players.Add(GameObject.Find("Player 2").GetComponent<PlayerControl>());
		_players.Add(GameObject.Find("Player 3").GetComponent<PlayerControl>());
		_players.Add(GameObject.Find("Player 4").GetComponent<PlayerControl>());

		_instructStyle = new GUIStyle();
		_instructStyle.fontStyle = FontStyle.Bold;
		_instructStyle.normal.textColor = Color.white;

		_victorStyle = new GUIStyle();
		_victorStyle.fontSize = 28;
		_victorStyle.fontStyle = FontStyle.Bold;
		_victorStyle.alignment = TextAnchor.MiddleCenter;
		_victorStyle.normal.textColor = Color.white;
	}

	void Update() {
		if(_victorName == null && Input.GetKeyDown(KeyCode.Space)) {
			_vine.Begin();
			_ground.Begin();
		}

		if(Input.GetKeyDown(KeyCode.R)) {
			_vine.Reset();
			_ground.Reset();

			for(int i = 0; i < _players.Count; i++)
				_players[i].Reset();

			_victorName = null;
		}

		if(_victorName == null && CheckVictory()) {
			_vine.Stop();
			_ground.Stop();
		}
	}

	void OnGUI() {
		GUI.Label(new Rect(Screen.width - 100, 10, 100, 20), "Keyboard", _instructStyle);
		GUI.Label(new Rect(Screen.width - 100, 30, 100, 20), "Space = Start", _instructStyle);
		GUI.Label(new Rect(Screen.width - 100, 50, 100, 20), "R = Reset", _instructStyle);

		GUI.Label(new Rect(10, 10, 100, 20), "Gamepad", _instructStyle);
		GUI.Label(new Rect(10, 30, 100, 20), "Left Stick = Move", _instructStyle);
		GUI.Label(new Rect(10, 50, 100, 20), "A = Jump", _instructStyle);

		if(_victorName != null) {
			int width = 250;
			Rect rect = new Rect((Screen.width - width) / 2, 10, width, 50);

			GUI.Label(rect, _victorName + " wins!", _victorStyle);
		}
	}

	private bool CheckVictory() {
		PlayerControl alive = null;
		int aliveCount = 0;

		for(int i = 0; i < _players.Count; i++) {
			PlayerControl player = _players[i];

			if(!player.IsDead() && player.transform.position.y < -4.5f)
				player.Die();

			if(!player.IsDead()) {
				alive = player;
				aliveCount++;
			}
        }

		if(aliveCount == 1) {
			_victorName = alive.name;
		} else if(aliveCount == 0) {
			_victorName = "Nobody";
		}

		return _victorName != null;
	}
}
