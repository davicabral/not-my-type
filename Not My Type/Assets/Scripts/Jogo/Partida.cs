using UnityEngine;
using System.Collections;

public class Partida {
	
	public ArrayList rodadas = new ArrayList();

	public static bool forcouFimPartida = false;

	public static int CalcularPontuacao(Dificuldade d) {
		if(d == Dificuldade.Dificil) return ((12 + CalcularModificadorMidia(Jogo.dificuldadeDica)) - (Jogo.numeroPalpite * 2)  <= 0 ) ? 0 : (12 + CalcularModificadorMidia(Jogo.dificuldadeDica)) - (Jogo.numeroPalpite * 2) ;
		if(d == Dificuldade.Medio) return ((8  + CalcularModificadorMidia(Jogo.dificuldadeDica)) - (Jogo.numeroPalpite * 2) <= 0 ) ? 0 : (8 + CalcularModificadorMidia(Jogo.dificuldadeDica)) - (Jogo.numeroPalpite * 2);
		if(d == Dificuldade.Facil) return ((4  + CalcularModificadorMidia(Jogo.dificuldadeDica)) - (Jogo.numeroPalpite * 1) <= 0) ? 0 : (4 + CalcularModificadorMidia(Jogo.dificuldadeDica)) - (Jogo.numeroPalpite * 1);

		return 0;
	}

	public static int CalcularPontuacaoCliente(Dificuldade d, int numAcertos) {
		if(d == Dificuldade.Dificil) return numAcertos * 4 + CalcularModificadorMidiaCliente(Jogo.dificuldadeDica, numAcertos);
		if(d == Dificuldade.Medio) return numAcertos * 3 + CalcularModificadorMidiaCliente(Jogo.dificuldadeDica, numAcertos);
		if(d == Dificuldade.Facil) return numAcertos * 2 + CalcularModificadorMidiaCliente(Jogo.dificuldadeDica, numAcertos);

		return 0;
	}

	private static int CalcularModificadorMidia(Dica d) {
		if (d == Dica.MuitoFacil) {
			return 2;
		} else if (d == Dica.Facil) {
			return 4;
		} else if (d == Dica.Medio) {
			return 8;
		} else {
			return 16;
		}
	}

	private static int CalcularModificadorMidiaCliente(Dica d, int numAcertos) {
		if (d == Dica.MuitoFacil) {
			return numAcertos * 1;
		} else if (d == Dica.Facil) {
			return numAcertos * 2;
		} else if (d == Dica.Medio) {
			return numAcertos * 4;
		} else {
			return numAcertos * 8;
		}
	}
}



