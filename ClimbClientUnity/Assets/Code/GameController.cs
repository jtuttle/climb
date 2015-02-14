using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {
	private Vine _vine;
	private Ground _ground;

	private List<PlayerControl> _players;

	void Start() {
		_vine = GameObject.Find("Vine").GetComponent<Vine>();
		_ground = GameObject.Find("Ground").GetComponent<Ground>();

		_players = new List<PlayerControl>();
		_players.Add(GameObject.Find("Player 1").GetComponent<PlayerControl>());
		_players.Add(GameObject.Find("Player 2").GetComponent<PlayerControl>());
		_players.Add(GameObject.Find("Player 3").GetComponent<PlayerControl>());
		_players.Add(GameObject.Find("Player 4").GetComponent<PlayerControl>());
	}

	void Update() {
		if(Input.GetKeyDown(KeyCode.Space)) {
			_vine.Begin();
			_ground.Begin();
		}

		if(Input.GetKeyDown(KeyCode.R)) {
			_vine.Reset();
			_ground.Reset();

			for(int i = 0; i < _players.Count; i++) {
				PlayerControl player = _players[i];
				player.transform.position = new Vector3(-3 + (2 * i), -3, 0);
			}
		}
	}
}
