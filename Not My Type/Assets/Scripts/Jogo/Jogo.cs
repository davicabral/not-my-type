using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Jogo {

	public static ArrayList jogadores = new ArrayList();

	public static ArrayList jogadoresAtivos {
		get {
			ArrayList aux = new ArrayList();
			for (int i = 0; i < jogadores.Count; i++) {
				Jogador j = (Jogador)jogadores[i];
				if (j.taJogando) {
					aux.Add(j);
				}
			}
			return aux;
		}
	}

	public static Queue clientes = new Queue();

	public static Partida partida = new Partida();

	public static int rodadaAtual;

	public static string[] opcoesDeResposta;

	public static int numeroPalpite;

	public static Dica dificuldadeDica;

}
