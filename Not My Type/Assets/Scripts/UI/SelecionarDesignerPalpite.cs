using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SelecionarDesignerPalpite : MonoBehaviour
{

	public int id;


	void Start ()
	{
		GetComponent<Button> ().onClick.AddListener (() => {
			for (int i = 0; i < Jogo.jogadoresAtivos.Count; i++) {
				if (id == ((Jogador)Jogo.jogadoresAtivos [i]).fotoID) {
					((Jogador)Jogo.jogadoresAtivos [i]).jaPalpitou = true;
					((Rodada)Jogo.partida.rodadas [Jogo.rodadaAtual]).palpiteAtual = ((Jogador)Jogo.jogadoresAtivos [i]);
					SceneManager.LoadScene ("TelaPalpite");
				}
			}
		}); 
	}

}
