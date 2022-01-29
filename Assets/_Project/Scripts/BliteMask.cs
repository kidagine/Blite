using UnityEngine;
using UnityEngine.Tilemaps;


[ExecuteInEditMode]
public class BliteMask : MonoBehaviour
{
	private SpriteRenderer _spriteRenderer;
	private TilemapRenderer _tileRenderer;
	public GameObject target;

	private void Start()
	{
		_spriteRenderer = GetComponent<SpriteRenderer>();
		if (_spriteRenderer == null) _tileRenderer = GetComponent<TilemapRenderer>();
	}

	private void Update()
	{
		if (target == null) target = GameObject.FindGameObjectWithTag("MainCamera");
		UpdateShader();
	}

	private void UpdateShader()
	{
		if (_spriteRenderer == null && _tileRenderer == null || target == null) return;
		MaterialPropertyBlock mpb = new MaterialPropertyBlock();
		if (_spriteRenderer != null) _spriteRenderer.GetPropertyBlock(mpb);
		if (_tileRenderer != null) _tileRenderer.GetPropertyBlock(mpb);

		mpb.SetFloat("_RenderDistance", BliteManager.Instance.BliteDistance);
		mpb.SetFloat("_MaskTargetX", target.transform.position.x);
		mpb.SetFloat("_MaskTargetY", target.transform.position.y);

		if (_spriteRenderer != null) _spriteRenderer.SetPropertyBlock(mpb);
		if (_tileRenderer != null) _tileRenderer.SetPropertyBlock(mpb);
	}
}
