using UnityEngine;

public class SphereRenderScript : MonoBehaviour
{

	public float scale = 0.0f;
	public float speed = 0.0f;
	private bool recalculateNormals = false;

	[SerializeField] private bool red;
	public Material m_Material;
	public MilkshakeTrigger milkshakeTrigger;

   private Vector3[] baseVertices;
	private Vector3[] vertices;

    private void Start()
    {
		red = true;

	}
    // Update is called once per frame
    void Update()
	{
		CheckItems();
		CalcNoise();
		//CheckColour();
	}

	void CheckItems()
    {
		Debug.Log("The sphere is active!");
		if (milkshakeTrigger == null)
		{
			Debug.LogError("MilkshakeTrigger not found!");

		}
		else if (milkshakeTrigger.greenItems)
		{
			Debug.Log("The green item is active!");
			m_Material.color = Color.green;
		}
		else if (milkshakeTrigger.purpleItems)
		{
			Debug.Log("The purple item is active!");
			m_Material.color = Color.red;
		}
		else if (milkshakeTrigger.orangeItems)
		{
			Debug.Log("The orange item is active!");
			m_Material.color = Color.yellow;
		}
		else if (milkshakeTrigger.noItems)
		{
			Debug.Log("no item are active!");
			m_Material.color = Color.white;
		}
		else if (milkshakeTrigger.allItems)
		{
			Debug.Log("all items are active!");
			m_Material.color = Color.black;
		}
		else
		{
			Debug.LogError("MilkshakeTrigger not found at all!");
			return;
		}
	}
	void CalcNoise()
	{
		Mesh mesh = GetComponent<MeshFilter>().mesh;

		if (baseVertices == null)
			baseVertices = mesh.vertices;

		vertices = new Vector3[baseVertices.Length];

		float timex = Time.time * speed + 2.5564f;
		float timey = Time.time * speed + 1.21688f;
		float timez = Time.time * speed + 0.1365143f;

		for (int i = 0; i < vertices.Length; i++)
		{
			Vector3 vertex = baseVertices[i];
			vertex.x += Mathf.PerlinNoise(timex + vertex.x, timex + vertex.y) * scale;
			vertex.y += Mathf.PerlinNoise(timey + vertex.x, timey + vertex.y) * scale;
			vertex.z += Mathf.PerlinNoise(timez + vertex.x, timez + vertex.y) * scale;
			vertices[i] = vertex;
		}

		recalculateNormals = true;

		mesh.vertices = vertices;

		if (recalculateNormals)
		{
			mesh.RecalculateNormals();
			mesh.RecalculateBounds();
		}
	}
	void CheckColour()
	{
		if (red == true) // Use '==' for comparison
		{
			m_Material.color = Color.red;
		}
		else if (red == false) // Use '==' for comparison
		{
			m_Material.color = Color.blue;
		}
		else
		{
			Debug.Log("Nothing");
		}
	}
}
