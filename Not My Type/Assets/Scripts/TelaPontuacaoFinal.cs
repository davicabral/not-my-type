using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class TelaPontuacaoFinal : MonoBehaviour
{

	public PointsRow[] rows;
	public Sprite[] avatarAcertou;
	public Sprite[] avatarErrou;
	public Sprite[] avatarVenceu;
	public Image avatarVencedor;


	private int numeroAcertos;
	private Jogador cliente;
	private PointsRow rowCliente;
	private Fonte fonteAtual;

	void Start ()
	{
		fonteAtual = ((Rodada)Jogo.partida.rodadas [Jogo.rodadaAtual]).fonte;
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
		DefineVencedor();
	}

	void CalcularPontuacaoCliente ()
	{
		if (numeroAcertos > 0) {
			
			if(!Partida.forcouFimPartida) {
				cliente.pontuacaoTotal += Partida.CalcularPontuacaoCliente (fonteAtual.dificuldade, numeroAcertos);
			}
			rowCliente.avatar.sprite = avatarAcertou [cliente.fotoID];
			rowCliente.pontuacao.text = cliente.pontuacaoTotal.ToString ();
		}
	}

	void DefineVencedor ()
	{
		int indiceVencedor = 0;
		int maiorPontuacao = 0;
		for (int i = 0; i < Jogo.jogadoresAtivos.Count; i++) {
			Jogador j = ((Jogador)Jogo.jogadoresAtivos [i]);
			if (j.pontuacaoTotal > maiorPontuacao) {
				maiorPontuacao = j.pontuacaoTotal;
				indiceVencedor = j.fotoID;
			}
		}

		avatarVencedor.sprite = avatarVenceu[indiceVencedor];
	}

	public void DidTapNovoJogo ()
	{
		Jogo.jogadores = new ArrayList();
		Jogo.clientes = new Queue();
		Jogo.partida = new Partida();
		Jogo.partida.rodadas = new ArrayList();
		Jogo.rodadaAtual = 0;
		Jogo.numeroPalpite = 0;


		SceneManager.LoadScene ("TelaInicio");	
	}
}
