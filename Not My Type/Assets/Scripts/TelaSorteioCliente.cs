using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TelaSorteioCliente : MonoBehaviour {

	[Header("Elementos de UI")]
	public Image textImage;
	public Button diceButton;
	public Sprite[] fotos;
	public Sprite textoSorteado;
	public Image clienteImage;
	public GameObject gameOnButton;


	void Start() {

	}

	public void SorteiaClientes() {
		if(Jogo.clientes.Count == 0) {
			ArrayList auxJogadores = (ArrayList)Jogo.jogadoresAtivos.Clone();
			RandomizeArray(auxJogadores);
			Jogo.clientes = new Queue(auxJogadores);
		}

		Jogador cliente = (Jogador)Jogo.clientes.Dequeue();
		diceButton.gameObject.SetActive(false);
		clienteImage.sprite = fotos[cliente.fotoID];
		clienteImage.gameObject.SetActive(true);
		gameOnButton.SetActive(true);

		cliente.eCliente = true;
		((Rodada)Jogo.partida.rodadas[Jogo.rodadaAtual]).cliente = cliente;
//
//		foreach(Jogador j in Jogo.jogadoresAtivos) {
//			if(j.fotoID != cliente.fotoID) {
//				
//			}
//		}
//			
	}

	void RandomizeArray(ArrayList arr)
	{
		for (var i = arr.Count - 1; i > 0; i--) {
			var r = Random.Range(0,i);
			var tmp = arr[i];
			arr[i] = arr[r];
			arr[r] = tmp;
		}
	}

}
