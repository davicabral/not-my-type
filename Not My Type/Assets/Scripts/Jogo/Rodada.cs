using UnityEngine;
using System.Collections;

public class Rodada {

	public Jogador cliente;
	public Jogador palpiteAtual;
	public Dica dica;
	public Fonte fonte;
	public int numeroPalpite;

	public enum Dica {
		ImagemLocal = 0,
		ImagemPessoa,
		Mimica,
		Musica,
		Video
	};

	public static Dica DicaFromInt(int n) {
		switch (n) {
		case 0:
			return Dica.ImagemLocal;
			break;
		case 1:
			return Dica.ImagemPessoa;
			break;
		case 2:
			return Dica.Mimica;
			break;
		case 3:
			return Dica.Musica;
			break;
		case 4:
			return Dica.Video;
			break;
		default:
			return Dica.ImagemLocal;
			break;
		}
	}
}
