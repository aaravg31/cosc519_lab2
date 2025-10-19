using UnityEngine;
using UnityEngine.UIElements;

public class customButtonEvent : MonoBehaviour
{
    public Renderer rend;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        
        Button button1 = root.Q<Button>("Button1");
        Button button2 = root.Q<Button>("Button2");
        Button button3 = root.Q<Button>("Button3");
        
        button1.clicked += () => SetColor(Color.red);
        button2.clicked += () => SetColor(Color.green);
        button3.clicked += () => SetColor(Color.blue);

    }

    public void SetColor(Color _color)
    {
        rend.material.color = _color;
    }
}
