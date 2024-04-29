using UnityEngine;

public class SC_MouseHover : MonoBehaviour
{
    [SerializeField] private Texture2D m_mouseZoomIcon;
    [SerializeField] private Texture2D m_mouseDeZoomIcon;
    [SerializeField] private Texture2D m_baseMouseTexture;

    private void OnMouseOver()
    {
        //Insérer condition zoom ou dezoom ici
        Cursor.SetCursor(m_mouseZoomIcon, Vector2.zero, CursorMode.Auto);
    }

    private void OnMouseExit()
    {
        Cursor.SetCursor(m_baseMouseTexture, Vector2.zero, CursorMode.Auto);
    }
}
