using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TelaCronometro : MonoBehaviour {

	public Text timer;
	public Image textoFimTempo;
	public Image textoMinuto;
	public Image cronometroImage;
	public Button proximoButton;

	public Sprite cronometroParado;
	public Sprite cronometroContando;
	public Sprite tempoIniciado;

	private bool taContando;
	private bool terminou = false;
	private float tempoInicial = 59;


	// Update is called once per frame
	void Update () {
		if(taContando && !terminou) {
			tempoInicial -= Time.deltaTime;

			timer.text = (tempoInicial < 9.5) ? "00:0" + Mathf.Round(tempoInicial) : "00:" + Mathf.Round(tempoInicial);

			if (tempoInicial <= 0) {
				terminou = true;
				proximoButton.gameObject.SetActive(true);
				cronometroImage.sprite = cronometroParado;
				textoMinuto.gameObject.SetActive(false);
				textoFimTempo.gameObject.SetActive(true);
			}
		}
			
	}

	public  void IniciarCronometro() {
		if(!taContando) {
			taContando = true;
			cronometroImage.sprite = cronometroContando;
			textoMinuto.sprite = tempoIniciado;
		}
	}
}
