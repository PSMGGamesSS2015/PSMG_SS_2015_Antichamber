// StencilViewer
// Simple script that renders the four different stencils at the end of each frame, over-drawing anything on screen.
// Providing visualisation of the actual stencil portals.

using UnityEngine;

[ExecuteInEditMode]
public class StencilViewer : MonoBehaviour 
{
	public	Shader[]		_stencilViewers;
	public	Color[]			_colours;

	void Start()
	{
	}
	
	
	void OnPostRender() 
	{				
		Material tmpMat = new Material(_stencilViewers[0]);
		tmpMat.SetColor("_Color", _colours[0]);
	
		GL.PushMatrix();
		GL.LoadOrtho();	
		
		for (int i = 0; i < _stencilViewers.Length; i++)
		{
			tmpMat.shader = _stencilViewers[i];
			tmpMat.SetColor("_Color", _colours[i]);
			tmpMat.SetPass( 0 );
			
											 
			GL.Begin(GL.QUADS);
			GL.TexCoord2(0, 0);
			GL.Vertex3(0.0F, 0.0F, 0);
			GL.TexCoord2(0, 1);
			GL.Vertex3(0.0F, 1.0F, 0);
			GL.TexCoord2(1, 1);
			GL.Vertex3(1.0F, 1.0F, 0);
			GL.TexCoord2(1, 0);
			GL.Vertex3(1.0F, 0.0F, 0);
			GL.End();
		}
		GL.PopMatrix();
    }
	
}
