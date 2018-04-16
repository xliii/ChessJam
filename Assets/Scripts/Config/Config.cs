using UnityEngine;

public class Config : MonoBehaviour
{
	public PrefabConfiguration prefabConfig;

	public MovementAnimation movementAnimation;

	public Campaign campaign;

	void Awake()
	{
		The.config = this;
	}
}
