using UnityEngine;
using Photon.Pun;

public class GameManager : MonoBehaviour
{
    public GameObject PlayerPrefab;
	public GameObject GameCanvas;
	public GameObject SceneCamera;

	public GameObject pfItemWorld;
	
	/// <summary>
	/// Displays the game map when the user loads in
	/// </summary>
	private void Awake(){
		GameCanvas.SetActive(true);
		
	}

	public void SpawnPlayer(){
		float randVal = Random.Range(-1f,1f);

		PhotonNetwork.Instantiate(PlayerPrefab.name, new Vector2(this.transform.position.x * randVal, this.transform.position.y), Quaternion.identity, 0);
	
		GameCanvas.SetActive(false);
		SceneCamera.SetActive(false);

		// ItemWorld inst = ItemWorld.SpawnItemWorld(new Vector3(3, -3), new Item{itemType = Item.ItemType.LongSword, amt = 1});
		// phItemWorld(inst);
	}

	public void phItemWorld(ItemWorld i)
	{
		// float randVal = Random.Range(-1f,1f);
		// Instantiate(i, new Vector2(this.transform.position.x * randVal, this.transform.position.y), Quaternion.identity);
        // ItemWorld itemWorld = transform.GetComponent<ItemWorld>();
        // itemWorld.setItem(item);
        // return itemWorld;

	}
	*/
}
