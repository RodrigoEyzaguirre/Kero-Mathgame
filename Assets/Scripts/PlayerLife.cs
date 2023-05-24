using UnityEngine;
using System.Collections;

public class PlayerLife : MonoBehaviour {

    GameObject[] heartBG = new GameObject[3];
    GameObject[] heart = new GameObject[3];
    GameObject heartUI;
    GameObject hearts;
	public int hp=3;

	public static bool dead;
	public static bool hurt;
	int currentHP;

	public GameManager gameManager;

	void Start () {
		hurt = false;
		dead = false;
		currentHP = hp;
        hearts = GameObject.Find("HeartBG");
        heartUI = hearts.transform.parent.gameObject;

        heartBG[0] = hearts;
        heart[0] = heartBG[0].transform.GetChild(0).gameObject;

        for (int i=1; i<hp; i++) {
            heartBG [i] = Instantiate(hearts, heartUI.transform);
            heart[i] = heartBG[i].transform.GetChild(0).gameObject;
		}

		//controller= GetComponent<PlayerController>();

	}

	public void Hurt () {
		currentHP--;
        heart[currentHP].SetActive(false);
		if (currentHP <=0)
			Kill ();
	}

	void Kill () {
		if (!dead) {
			//controller.enabled=false;
			for (int i=currentHP-1; i>=0; i--) 
				heart[i].SetActive(false);
			currentHP = 0;
			dead = true;
			gameManager.Lose();
		}
	}
}