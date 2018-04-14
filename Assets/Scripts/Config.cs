using UnityEngine;

public class Config : MonoBehaviour
{

	public PrefabConfiguration prefabConfig;

	public MovementAnimation movementAnimation;

	void Awake()
	{
		The.config = this;
	}
}
