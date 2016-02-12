using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class TelaEscolherParticipantes : MonoBehaviour {

	public Toggle[] characters;
	public GameObject errorPopup;

	void Awake() {
		foreach (Jogador j in Jogo.jogadoresAtivos) {
			characters[j.fotoID].isOn = true;
		}
	}

	public void DidTapContinueButton() {
		int numberOfPlayers = 0;
		Jogo.jogadores.Clear();
		Jogo.jogadoresAtivos.Clear();

		for (int i = 0; i < characters.Length; i++) {
			if (characters[i].isOn) {
				numberOfPlayers++;
			}
			Jogador j = new Jogador();
			j.fotoID = i;
			j.taJogando = characters[i].isOn;
			Jogo.jogadores.Add(j);

		}

		if (numberOfPlayers >= 3) {
			for (int i = 0; i < numberOfPlayers; i++) {
				Rodada r = new Rodada();
				Jogo.partida.rodadas.Add(r);
			}
			
			SceneManager.LoadScene("TelaSorteioCliente");
		} else {
			errorPopup.SetActive(true);
		}
	}
}
