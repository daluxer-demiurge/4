using UnityEditor;
using UnityEngine;

public class Window :EditorWindow
{
    public Color myColor;
    public MeshRenderer GO;
    public Material newMaterial;

    [MenuItem("Инструменты/ Окна/ Редактор кубов")]
    public static void ShowWindow()
    {
        GetWindow(typeof(Window), false, "Тестовое окно");
    }

    void OnGUI()
    {
        GO = EditorGUILayout.ObjectField("Меш объекта", GO, typeof(MeshRenderer), true) as MeshRenderer;
        newMaterial = EditorGUILayout.ObjectField("Материал объекта", newMaterial, typeof(Material), true) as Material;

        if (GO)
        {
            myColor = RGBSlider(new Rect(10, 30, 200, 20), myColor);  // Отрисовка пользовательского набора слайдеров для получения градиента цвета
            GO.sharedMaterial.color = myColor; // Покраска объекта
        }
        else
        {
            if(GUILayout.Button("Создать куб"))
            {
                GameObject main = GameObject.CreatePrimitive(PrimitiveType.Cube);
                MeshRenderer GoRenderer = main.GetComponent<MeshRenderer>();
                main.transform.position = Vector3.zero;
                GO = GoRenderer;
            }
        }
    }

    // Отрисовка пользовательского слайдера
    float LabelSlider(Rect screenRect, float sliderValue, float sliderMaxValue, string labelText)
    {
        // создаём прямоугольник с координатами в пространстве и заданой шириной и высотой 
        Rect labelRect = new Rect(screenRect.x, screenRect.y, screenRect.width / 2, screenRect.height);

        GUI.Label(labelRect, labelText);   // создаём Label на экране

        Rect sliderRect = new Rect(screenRect.x + screenRect.width / 2, screenRect.y, screenRect.width / 2, screenRect.height); // Задаём размеры слайдера
        sliderValue = GUI.HorizontalSlider(sliderRect, sliderValue, 0.0f, sliderMaxValue); // Вырисовываем слайдер и считываем его параметр
        return sliderValue; // Возвращаем значение слайдера
    }

    // Отрисовка тройной слайдер группы, каждый слайдер отвечает за свой цвет
    Color RGBSlider(Rect screenRect, Color rgb)
    {
        // Используя пользовательский слайдер, создаём его
        rgb.r = LabelSlider(screenRect, rgb.r, 1.0f, "Red");

        // делаем промежуток
        screenRect.y += 20;
        rgb.g = LabelSlider(screenRect, rgb.g, 1.0f, "Green");

        screenRect.y += 20;
        rgb.b = LabelSlider(screenRect, rgb.b, 1.0f, "Blue");

        screenRect.y += 20;
        rgb.a = LabelSlider(screenRect, rgb.a, 1.0f, "alpha");

        return rgb; // возвращаем цвет
    }
}
