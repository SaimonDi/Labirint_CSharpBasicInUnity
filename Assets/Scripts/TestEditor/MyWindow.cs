using UnityEditor;
using UnityEngine;


namespace LabirintSpace
    {
    public class MyWindow : EditorWindow
        {
        public static GameObject ObjectInstantiate;
        public string _nameObject = "Game Object";
        public bool _groupEnabled;
        public bool _randomColor = true;
        public int _countObject = 1;
        public float _maxRadius = 10;
        public float _radius = 10;
        public float _stepUp = 0;

        private void OnGUI()
            {
            GUILayout.Label("������� ���������", EditorStyles.boldLabel);

            ObjectInstantiate = EditorGUILayout.ObjectField("������ ������� ����� ��������", 
                ObjectInstantiate, typeof(GameObject), true) as GameObject;

            _nameObject = EditorGUILayout.TextField("��� �������", _nameObject);

            _groupEnabled = EditorGUILayout.BeginToggleGroup("�������������� ���������", _groupEnabled);
            _randomColor = EditorGUILayout.Toggle("��������� ����", _randomColor);
            _countObject = EditorGUILayout.IntSlider("���������� ��������", _countObject, 1, 100);
            _radius = EditorGUILayout.Slider("������ ����������", _radius, 1, 100);
            _stepUp = EditorGUILayout.Slider("��� ������", _stepUp, -.5f, .5f);
            EditorGUILayout.EndToggleGroup();

            var button = GUILayout.Button("������� �������");
            if(button)
                {
                if(ObjectInstantiate)
                    {
                    GameObject root = new GameObject("Root");

                    for(int i = 0; i < _countObject; i++)
                        {
                        Vector3 pos;
                        float angle = i * Mathf.PI * 2 / _countObject;

                        if(i % 2 == 0)
                            pos = new Vector3(Mathf.Cos(angle), _stepUp * i, Mathf.Sin(angle)) * _radius;
                        else
                            pos = new Vector3(-Mathf.Cos(angle), _stepUp * i, -Mathf.Sin(angle)) * _radius;

                        GameObject temp = Instantiate(ObjectInstantiate, pos, Quaternion.identity);

                        temp.name = _nameObject + "(" + i + ")";
                        temp.transform.parent = root.transform;

                        var tempRenderer = temp.GetComponent<Renderer>();
                        if(tempRenderer && _randomColor)
                            {
                            tempRenderer.material.color = Random.ColorHSV();
                            }
                        }
                    }
                }
            }
        }
    }

