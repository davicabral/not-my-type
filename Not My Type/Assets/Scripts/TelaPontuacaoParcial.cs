using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class TelaPontuacaoParcial : MonoBehaviour
{

	public PointsRow[] rows;
	public Sprite[] avatarAcertou;
	public Sprite[] avatarErrou;
	private int numeroAcertos;
	private Jogador cliente;
	private PointsRow rowCliente;
	private Fonte fonteAtual;

	void Start ()
	{
		fonteAtual = ((Rodada)Jogo.partida.rodadas[Jogo.rodadaAtual]).fonte;
		for (int i = 0; i < 6; i++) {
			if (i < Jogo.jogadoresAtivos.Count) {
				
				Jogador j = (Jogador)Jogo.jogadoresAtivos [i];
				if (j.eCliente) {
					cliente = j;
					rowCliente = rows [i];
				}
				rows [i].pontuacao.text = j.pontuacaoTotal.ToString ();
				if (j.acertou) {
					rows [i].avatar.sprite = avatarAcertou [j.fotoID];
					numeroAcertos++;
				} else {
					rows [i].avatar.sprite = avatarErrou [j.fotoID];
				}
			} else {
				rows [i].gameObject.SetActive (false);
			}
		}

		CalcularPontuacaoCliente ();
	}

	void CalcularPontuacaoCliente ()
	{
		if (numeroAcertos > 0) {
			rowCliente.avatar.sprite = avatarAcertou[cliente.fotoID];
		} else {
			rowCliente.avatar.sprite = avatarAcertou[cliente.fotoID];
		}

		cliente.pontuacaoTotal += Partida.CalcularPontuacaoCliente(fonteAtual.dificuldade, numeroAcertos);
		rowCliente.pontuacao.text = cliente.pontuacaoTotal.ToString();
	}

	public void DidTapTerminarJogo() {
		Partida.forcouFimPartida = true;
		SceneManager.LoadScene("TelaPontuacaoFinal");
	}

	public void DidTapProximaRodada() {
		for(int i = 0; i < Jogo.jogadoresAtivos.Count; i++) {
			
			Jogador j = ((Jogador)Jogo.jogadoresAtivos[i]);
			j.pontuacaoRodada = 0;
			j.jaPalpitou = false;
			j.eCliente = false;
			j.acertou = false;
		}
		Rodada novaRodada = new Rodada();
		Jogo.partida.rodadas.Add(novaRodada);
		Jogo.rodadaAtual++;
		Jogo.numeroPalpite = 0;
		SceneManager.LoadScene("TelaSorteioCliente");
	}


}
