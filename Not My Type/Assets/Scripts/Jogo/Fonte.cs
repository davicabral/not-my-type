using UnityEngine;
using System.Collections;

public class Fonte
{

	public string name;
	public Dificuldade dificuldade;



	private static string[] todasFontes = {
		"Helvetica",
		"Walkway",
		"Comic Sans",
		"Frutiger",
		"Futura",
		"Jokerman",
		"Gill Sans",
		"Trajan",
		"Rosewood",
		"Bodoni",
		"Rockwell",
		"Stencil",
		"Times New Roman",
		"Courier",
		"Old English",
		"Garamond",
		"Bebas",
		"Papyrus",
		"League Gothic",
		"Lavanderia"
	};


	public static Fonte fontWithName (string nome)
	{
		Fonte f = new Fonte ();
		f.name = nome;
		f.dificuldade = DificuldadeFonte (nome);

		return f;
	}

	public static string[] ItensResposta (string resposta)
	{
		int op1 = 0;
		int op2 = 0;
		int op3 = 0;

		bool saoDiferentes = false;
		while (!saoDiferentes) {
			op1 = Random.Range (0, Fonte.todasFontes.Length);
			op2 = Random.Range (0, Fonte.todasFontes.Length);
			op3 = Random.Range (0, Fonte.todasFontes.Length);

			saoDiferentes = op1 != op2 && op1 != op3 && op2 != op3 && !Fonte.todasFontes [op1].Equals (resposta) && !Fonte.todasFontes [op2].Equals (resposta) && !Fonte.todasFontes [op3].Equals (resposta);
		}	

		string[] retorno = { resposta, Fonte.todasFontes [op1], Fonte.todasFontes [op2], Fonte.todasFontes [op3] };
		Fonte.RandomizeArray (retorno);
		Fonte.RandomizeArray (retorno);
		return retorno;


	}

	public static Dificuldade DificuldadeFonte (string nome)
	{
		if (nome.Equals ("Helvetica") ||
		    nome.Equals ("Frutiger") ||
		    nome.Equals ("Gill Sans") ||
		    nome.Equals ("Bodoni") ||
		    nome.Equals ("Times New Roman") ||
		    nome.Equals ("Garamond")) {

			return Dificuldade.Dificil;
		} else if (nome.Equals ("Walkway") ||
		           nome.Equals ("Futura") ||
		           nome.Equals ("Trajan") ||
		           nome.Equals ("Rockwell") ||
		           nome.Equals ("Courier") ||
		           nome.Equals ("Bebas") ||
		           nome.Equals ("League Gothic")) {

			return Dificuldade.Medio;
		} else {
			return Dificuldade.Facil;
		}
	}

	private static void RandomizeArray (string[] arr)
	{
		for (var i = arr.Length - 1; i > 0; i--) {
			var r = Random.Range (0, i);
			var tmp = arr [i];
			arr [i] = arr [r];
			arr [r] = tmp;
		}
	}
}

public enum Dificuldade
{
	Facil,
	Medio,
	Dificil};

