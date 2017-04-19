using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace com.MyCompany.MyGame{

	public class Launcher : Photon.PunBehaviour {

		#region Public Variables
		public PhotonLogLevel Loglevel = PhotonLogLevel.Informational;

		/// <summary>
		/// The maximum number of players per room. When a room is full, it can't be joined by new players, and so new room will be created.
		/// </summary>   
		[Tooltip("The maximum number of players per room. When a room is full, it can't be joined by new players, and so new room will be created")]
		public byte MaxPlayersPerRoom = 4;

		public Text feedbackText;
		#endregion


		bool isConnecting;
		string _gameVersion = "1";

		void Awake(){
			PhotonNetwork.autoJoinLobby = false;
			PhotonNetwork.automaticallySyncScene = true;
			PhotonNetwork.logLevel = PhotonLogLevel.ErrorsOnly;

		}

		// Use this for initialization
		void Start () {
			//Connect();
		}


		public void Connect(){
			isConnecting = true;

			if (PhotonNetwork.connected) {
				LogFeedback ("Joining Room...");
				PhotonNetwork.JoinRandomRoom ();
			} else {

				LogFeedback ("Connecting...");
				PhotonNetwork.ConnectUsingSettings (_gameVersion);
			}
		}


		void LogFeedback(string message){
			if (feedbackText == null) {
				return;
			}
			feedbackText.text += System.Environment.NewLine + message;
		
		}

		#region

		public override void OnConnectedToMaster(){
			Debug.Log ("DemoAnimator/Launcher: OnConnectedToMaster() was called by PUN");
			LogFeedback ("Region: " + PhotonNetwork.networkingPeer.CloudRegion);

			if(isConnecting){
				LogFeedback ("Connected to Master -> try to Join Random Room");
				PhotonNetwork.JoinRandomRoom ();
				
			}
		}

		public override void OnDisconnectedFromPhoton(){
			Debug.LogWarning("DemoAnimator/Launcher: OnDisconnectedFromPhoton() was called by PUN");        
		}

		public override void OnPhotonRandomJoinFailed (object[] codeAndMsg)
		{
			Debug.Log("DemoAnimator/Launcher:OnPhotonRandomJoinFailed() was called by PUN. No random room available, so we create one.\nCalling: PhotonNetwork.CreateRoom(null, new RoomOptions() {maxPlayers = 4}, null);");

			// #Critical: we failed to join a random room, maybe none exists or they are all full. No worries, we create a new room.
			PhotonNetwork.CreateRoom(null, new RoomOptions() { maxPlayers = MaxPlayersPerRoom }, null);
		}

		public override void OnJoinedRoom()
		{
			Debug.Log("DemoAnimator/Launcher: OnJoinedRoom() called by PUN. Now this client is in a room.");
			PhotonNetwork.LoadLevel ("Game");
		}

		#endregion


	}

}
