﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class LogInManager : MonoBehaviour {

	public GameObject guiTextLogIn;   // ログインテキスト
	public GameObject guiTextSignUp;  // 新規登録テキスト

	// ログイン画面のときtrue, 新規登録画面のときfalse
	private bool isLogIn;

	// ボタンが押されると対応する変数がtrueになる
	public bool logInButton;
	public bool signUpMenuButton;
	public bool signUpButton;
	public bool backButton;

	// テキストボックスで入力される文字列を格納
	public string id;
	public string pw;
	public string mail;

	void Start () {

		FindObjectOfType<UserAuth>().logOut();

		// ゲームオブジェクトを検索し取得する
		//guiTextLogIn  = GameObject.Find ("LogInSet");
		//guiTextSignUp = GameObject.Find ("SignUpSet");  

		isLogIn = true;
		guiTextSignUp.SetActive (false);
		guiTextLogIn.SetActive (true);

		//boolの初期化
		logInButton = false;
		signUpButton = false;
		signUpMenuButton = false;
		backButton = false;

	}

	void OnGUI () {

		// ログイン画面 
		if( isLogIn ){

			drawLogInMenu();

			// ログインボタンが押されたら
			if( logInButton )
				FindObjectOfType<UserAuth>().logIn( id, pw );

			// 新規登録画面に移動するボタンが押されたら
			if( signUpMenuButton )
				isLogIn = false;
		}

		// 新規登録画面
		else {

			drawSignUpMenu();  

			// 新規登録ボタンが押されたら
			if( signUpButton )
				FindObjectOfType<UserAuth>().signUp( id, mail, pw );

			// 戻るボタンが押されたら
			if( backButton )
				isLogIn = true;
		}

		// currentPlayerを毎フレーム監視し、ログインが完了したら
		if( FindObjectOfType<UserAuth>().currentPlayer() != null )
			SceneManager.LoadScene("Map");

	}

	private void drawLogInMenu()
	{
		// テキスト切り替え
		guiTextSignUp.SetActive (false);
		guiTextLogIn.SetActive (true);

		// テキストボックスの設置と入力値の取得
		GUI.skin.textField.fontSize = 20;
		int txtW = 150, txtH = 40;
		id = GUI.TextField     (new Rect(Screen.width*1/2, Screen.height*1/3 - txtH*1/2, txtW, txtH), id);
		pw = GUI.PasswordField (new Rect(Screen.width*1/2, Screen.height*1/2 - txtH*1/2, txtW, txtH), pw, '*');

		// ボタンの設置
		int btnW = 180, btnH = 50;
		GUI.skin.button.fontSize = 20;
		logInButton      = GUI.Button( new Rect(Screen.width*1/4 - btnW*1/2, Screen.height*3/4 - btnH*1/2, btnW, btnH), "Log In" );
		signUpMenuButton = GUI.Button( new Rect(Screen.width*3/4 - btnW*1/2, Screen.height*3/4 - btnH*1/2, btnW, btnH), "Sign Up" );

	}

	private void drawSignUpMenu()
	{
		// テキスト切り替え
		guiTextLogIn.SetActive (false);
		guiTextSignUp.SetActive (true);

		// テキストボックスの設置と入力値の取得
		int txtW = 150, txtH = 35;
		GUI.skin.textField.fontSize = 20;
		id = GUI.TextField     (new Rect(Screen.width*1/2, Screen.height*1/4 - txtH*1/2, txtW, txtH), id);
		pw = GUI.PasswordField (new Rect(Screen.width*1/2, Screen.height*2/5 - txtH*1/2, txtW, txtH), pw, '*');
		mail = GUI.TextField   (new Rect(Screen.width*1/2, Screen.height*11/20 - txtH*1/2, txtW, txtH), mail);

		// ボタンの設置
		int btnW = 180, btnH = 50;
		GUI.skin.button.fontSize = 20;
		signUpButton = GUI.Button( new Rect(Screen.width*1/4 - btnW*1/2, Screen.height*3/4 - btnH*1/2, btnW, btnH), "Sign Up" );
		backButton   = GUI.Button( new Rect(Screen.width*3/4 - btnW*1/2, Screen.height*3/4 - btnH*1/2, btnW, btnH), "Back" ); 
	}

}