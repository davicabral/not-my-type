using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TelaSorteioDinamica : MonoBehaviour {

	public Sprite[] textosDinamicas;
	public Sprite[] iconesDinamicas;

	public Image imageTexto;
	public Image imageDinamica;

	// Use this for initialization
	void Awake () {
		int randomNumber = Random.Range(0,textosDinamicas.Length);
		Jogo.dificuldadeDica = DificuldadeDica(randomNumber);

		imageTexto.sprite = textosDinamicas[randomNumber];
		imageDinamica.sprite = iconesDinamicas[randomNumber];

		((Rodada)Jogo.partida.rodadas[Jogo.rodadaAtual]).dica = Rodada.DicaFromInt(randomNumber);
	}

	Dica DificuldadeDica (int id) {
		if(id == 4) {
			return Dica.MuitoFacil;
		} else if(id == 1 || id == 2) {
			return Dica.Facil;
		} else if (id == 3) {
			return Dica.Medio;
		} else {
			return Dica.Dificil;
		}
	}

}

public enum Dica {
	MuitoFacil,
	Facil,
	Medio,
	Dificil
};
