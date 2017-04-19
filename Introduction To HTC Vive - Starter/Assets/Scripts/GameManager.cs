// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Launcher.cs" company="Exit Games GmbH">
//   Part of: Photon Unity Networking Demos
// </copyright>
// <summary>
//  Used in "PUN Basic tutorial" to handle typical game management requirements
// </summary>
// <author>developer@exitgames.com</author>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections;

using UnityEngine;
using UnityEngine.SceneManagement; 

namespace com.MyCompany.MyGame
{
	/// <summary>
	/// Game manager.
	/// Connects and watch Photon Status, Instantiate Player
	/// Deals with quiting the room and the game
	/// Deals with level loading (outside the in room synchronization)
	/// </summary>
	public class GameManager : Photon.MonoBehaviour {

		#region Public Variables

		static public GameManager Instance;

		[Tooltip("The prefab to use for representing the player")]
		public GameObject playerPrefab;

		public bool TransferOwnershipOnRequest = true;

		#endregion

		#region Private Variables

		private GameObject instance;

		#endregion

		#region MonoBehaviour CallBacks

		/// <summary>
		/// MonoBehaviour method called on GameObject by Unity during initialization phase.
		/// </summary>
		void Start()
		{
			Instance = this;

			// in case we started this demo with the wrong scene being active, simply load the menu scene
			if (!PhotonNetwork.connected)
			{
				SceneManager.LoadScene("Launcher");

				return;
			}
				



		}

		/// <summary>
		/// MonoBehaviour method called on GameObject by Unity on every frame.
		/// </summary>
		void Update()
		{
			// "back" button of phone equals "Escape". quit app if that's pressed
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				QuitApplication();
			}
		}

		#endregion

		#region Photon Messages

		/// <summary>
		/// Called when a Photon Player got connected. We need to then load a bigger scene.
		/// </summary>
		/// <param name="other">Other.</param>
		public void OnPhotonPlayerConnected( PhotonPlayer other  )
		{
			Debug.Log( "OnPhotonPlayerConnected() " + other.NickName); // not seen if you're the player connecting

			if ( PhotonNetwork.isMasterClient ) 
			{
				Debug.Log( "OnPhotonPlayerConnected isMasterClient " + PhotonNetwork.isMasterClient ); // called before OnPhotonPlayerDisconnected

				LoadArena();
			}
		}

		/// <summary>
		/// Called when a Photon Player got disconnected. We need to load a smaller scene.
		/// </summary>
		/// <param name="other">Other.</param>
		public void OnPhotonPlayerDisconnected( PhotonPlayer other  )
		{
			Debug.Log( "OnPhotonPlayerDisconnected() " + other.NickName ); // seen when other disconnects

			if ( PhotonNetwork.isMasterClient ) 
			{
				Debug.Log( "OnPhotonPlayerConnected isMasterClient " + PhotonNetwork.isMasterClient ); // called before OnPhotonPlayerDisconnected

				LoadArena();
			}
		}



		/// <summary>
		/// Raises the ownership request event.
		/// </summary>
		/// <param name="viewAndPlayer">View and player.</param>

		public void OnOwnershipRequest(object[] viewAndPlayer)
		{
			PhotonView view = viewAndPlayer[0] as PhotonView;
			PhotonPlayer requestingPlayer = viewAndPlayer[1] as PhotonPlayer;

			Debug.Log("OnOwnershipRequest(): Player " + requestingPlayer + " requests ownership of: " + view + ".");
			if (this.TransferOwnershipOnRequest)
			{
				view.TransferOwnership(requestingPlayer.ID);
			}
		}






		/// <summary>
		/// Called when the local player left the room. We need to load the launcher scene.
		/// </summary>
		public virtual void OnLeftRoom()
		{
			SceneManager.LoadScene("Launcher");
		}

		#endregion

		#region Public Methods

		public void LeaveRoom()
		{
			PhotonNetwork.LeaveRoom();
		}

		public void QuitApplication()
		{
			Application.Quit();
		}

		#endregion

		#region Private Methods

		void LoadArena()
		{
			if ( ! PhotonNetwork.isMasterClient ) 
			{
				Debug.LogError( "PhotonNetwork : Trying to Load a level but we are not the master Client" );
			}

			Debug.Log( "Game"); 

			PhotonNetwork.LoadLevel("Game");
		}

		#endregion

	}

}