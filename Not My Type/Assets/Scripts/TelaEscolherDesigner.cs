using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class TelaEscolherDesigner : MonoBehaviour {

	public Sprite[] designers;
	public Sprite[] designerDesabilitado;
	public Sprite[] designerRespondido;

	public Button[] buttons;

	public GameObject popup;

	// Use this for initialization
	void Awake () {
		for(int i = 0; i < 6; i++) {
			if(i < Jogo.jogadoresAtivos.Count) {
				int id = ((Jogador)Jogo.jogadoresAtivos[i]).fotoID;
				buttons[i].gameObject.GetComponent<SelecionarDesignerPalpite>().id = id;

				if(((Rodada)Jogo.partida.rodadas[Jogo.rodadaAtual]).cliente.fotoID == id) {
					buttons[i].image.sprite = designerDesabilitado[id];
					buttons[i].interactable = false;
				} else if (((Jogador) Jogo.jogadoresAtivos[i]).jaPalpitou) {
					buttons[i].image.sprite = designerRespondido[id];
					buttons[i].interactable = false;
				} else {
					buttons[i].image.sprite = designers[id];
				}
			} else {
				buttons[i].gameObject.SetActive(false);
			}
		}
	}
	
	// Update is called once per frame
	public void DidTapContinueButton () {
		for(int i = 0; i < buttons.Length; i++) {
			if (buttons[i].IsActive() && buttons[i].IsInteractable()) {
				popup.SetActive(true);
				return;
			}
		}
		if(Jogo.rodadaAtual < Jogo.jogadoresAtivos.Count -1) {
			SceneManager.LoadScene("TelaPontuacaoParcial");
		} else {
			SceneManager.LoadScene("TelaPontuacaoFinal");
		}

	}
}
