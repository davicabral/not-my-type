using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class TelaPalpite : MonoBehaviour
{

	public Image avatar;

	public Toggle digitar;
	public Toggle escolher;

	public Toggle[] respostas;

	public Sprite[] avatarPictures;

	public InputField inputText;

	private string[] fontNames;

	private Jogador jogadorAtual;

	void Start ()
	{
		jogadorAtual = ((Rodada)Jogo.partida.rodadas [Jogo.rodadaAtual]).palpiteAtual;
		avatar.sprite = avatarPictures [jogadorAtual.fotoID];



		for (int i = 0; i < respostas.Length; i++) {
			respostas [i].GetComponentInChildren<Text> ().text = Jogo.opcoesDeResposta [i];
		}
	}

	public void DidTapContinueButton ()
	{
		string respostaCorreta = ((Rodada)Jogo.partida.rodadas [Jogo.rodadaAtual]).fonte.name.ToLower ();
		Dificuldade d = Fonte.DificuldadeFonte (((Rodada)Jogo.partida.rodadas [Jogo.rodadaAtual]).fonte.name);
		int pontuacao = Partida.CalcularPontuacao (d);
		Debug.Log ("Pontuação: " + pontuacao);
		if (digitar.isOn) {
			string respostaDigitada = inputText.text.ToLower ();
			if (respostaDigitada.Length > 0) {
				if (respostaDigitada.Equals (respostaCorreta)) {
					jogadorAtual.acertou = true;
					jogadorAtual.pontuacaoTotal += pontuacao + 4;
				}
				Jogo.numeroPalpite++;
				SceneManager.LoadScene ("TelaSelecionarDesigner");
			}
		} else {
			bool temUmaOpcaoMarcada = false;
			foreach (Toggle t in respostas) {
				if (t.isOn) {
					temUmaOpcaoMarcada = true;
					if (t.GetComponentInChildren<Text> ().text.ToLower ().Equals (respostaCorreta)) {
						jogadorAtual.acertou = true;
						jogadorAtual.pontuacaoTotal += pontuacao;
					}
				}
			}
			if (temUmaOpcaoMarcada) {
				Jogo.numeroPalpite++;
				SceneManager.LoadScene ("TelaSelecionarDesigner");
			}
		}
	}



}
