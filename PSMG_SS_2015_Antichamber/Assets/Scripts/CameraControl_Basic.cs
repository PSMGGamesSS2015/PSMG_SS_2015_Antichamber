using UnityEngine;
using System.Collections;

public class CameraControl_Basic : MonoBehaviour {

	public	Transform		m_CameraTarget;
	
	public	float			m_Distance		=  4.0f;
	public	float			xSpeed			=  4.0f;
	public	float			ySpeed			=  4.0f;
	public	float			zoomSpeed		=  4.0f;
	
	public	int				yMinLimit		= -50;
	public	int				yMaxLimit		=  80;
	public	float			minDist			=  2.0f;
	
	public	float			m_MinElevation 	= -30.0f;
	public	float			m_MaxElevation 	=  30.0f;
	
	private	float 			m_x 			= 0.0f;
	private	float		 	m_y 			= 0.0f;
	
	
	// Use this for initialization
	void Start () 
	{
		UpdateCamera();
	}
	

	// Update is called once per frame
	void Update () 
	{	
		if (m_CameraTarget)
		{
			bool input = false;
		
				
			// Left Mouse Orbit
			if ( Input.GetMouseButton(0) )
			{		
				input = true;					
				m_x += Input.GetAxis("Mouse X") * xSpeed; 
				m_y -= Input.GetAxis("Mouse Y") * ySpeed;
				m_y = ClampAngle(m_y, yMinLimit, yMaxLimit);
				m_x = ClampAngle(m_x, -360.0f, 360.0f);
			}	
			
			// Zoom
			if ( Input.GetMouseButton(1) ) 
			{
				input = true;					
				m_Distance -= Input.GetAxis("Mouse Y") * zoomSpeed; 				
				if (m_Distance < minDist)  m_Distance = minDist;						
			}
			
			// Pan Target Position
			if ( Input.GetMouseButton(2) )
			{				
				input = true;

				Vector3	tmp = m_CameraTarget.position;		
				tmp.y = tmp.y - ( Input.GetAxis("Mouse Y") * zoomSpeed);
				tmp.x = tmp.x - ( Input.GetAxis("Mouse X") * zoomSpeed);
				
				if (tmp.y < m_MinElevation) tmp.y = m_MinElevation;
				if (tmp.y > m_MaxElevation) tmp.y = m_MaxElevation;
		
				m_CameraTarget.position = tmp;	
			}	
				
			if (input) UpdateCamera();				
		}	
	}
	
	
	public void UpdateCamera ()
	{
		Vector3 	dist = new Vector3(0.0f, 0.0f, -m_Distance);		
		Quaternion 	rotation = Quaternion.Euler(m_y, m_x, 0.0f);	
		Vector3 	position = rotation * dist + m_CameraTarget.position;

		transform.rotation = rotation;
		transform.position = position;	
	}
	
/*
	 void AdjustElevation ()
	{
		Vector3	tmp = m_CameraTarget.position;		
		tmp.y = tmp.y + ( Input.GetAxis("Mouse Y") * ySpeed);

		if (tmp.y < m_MinElevation) tmp.y = m_MinElevation;
		if (tmp.y > m_MaxElevation) tmp.y = m_MaxElevation;
		
		m_CameraTarget.position = tmp;		
	}
	
	
	 void AdjustZoom ()
	{
		m_Distance -= Input.GetAxis("Mouse Y") * ySpeed; 				
		if (m_Distance < minDist)  m_Distance = minDist;	
	}
		*/
	
	float ClampAngle ( float angle, float min, float max)
	{
		if (angle < -360) angle += 360;
		if (angle > 360)  angle -= 360;
		return Mathf.Clamp (angle, min, max);
	}
}
