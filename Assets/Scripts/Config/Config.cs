using UnityEngine;

public class Config : MonoBehaviour
{
	public PrefabConfiguration prefabConfig;

	public MovementAnimation movementAnimation;

	public Campaign campaign;

	void Awake()
	{
		if (The.config != null)
		{
			Destroy(gameObject);
			return;
		}

		The.config = this;
		DontDestroyOnLoad(this);
	}
}
