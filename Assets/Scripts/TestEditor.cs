using System.Collections;
using UnityEngine;
using UnityEditor;  

namespace LabirintSpace
    {
    [CustomEditor(typeof(TestBeh))]
    public class TestEditor : UnityEditor.Editor
        {
        private bool _isPressButtonComponent;

        public override void OnInspectorGUI()
            {
            //DrawDefaultInspector();
            TestBeh testTarget = (TestBeh)target;

            testTarget.count = EditorGUILayout.IntSlider("Количество объектов", testTarget.count, 1, 30);
            testTarget.offset = EditorGUILayout.IntSlider("Шаг высоты", testTarget.offset, 1, 5);

            testTarget.obj = EditorGUILayout.ObjectField("Объект который хотим вставить", 
                            testTarget.obj, typeof(GameObject), false) as GameObject;

            var isPressButton1 = GUILayout.Button("Очистить",
               EditorStyles.miniButtonRight);
            var isPressButton2 = GUILayout.Button("Создание объектов по кнопке",
               EditorStyles.miniButtonLeft);

            if(isPressButton1)
                {
                testTarget.count = 1;
                testTarget.offset = 1;
                testTarget.obj = EditorGUILayout.ObjectField("Объект который хотим вставить",
                            null, typeof(GameObject), false) as GameObject;
                }

            _isPressButtonComponent = GUILayout.Toggle(_isPressButtonComponent, "Дополнительные настройки");

            if(isPressButton2)
                {
                testTarget.CreateObj();
                }

            if(_isPressButtonComponent)
                {
                EditorGUILayout.HelpBox("Вы можете добавить компоненты тела", MessageType.Warning);

                var isPressAddButton = GUILayout.Button("Добавить компоненты",
                   EditorStyles.miniButtonLeft);
                var isPressRemoveButton = GUILayout.Button("Удалить компоненты",
                   EditorStyles.miniButtonLeft);

                if(isPressAddButton)
                    {
                    testTarget.AddComponent();
                    }
                if(isPressRemoveButton)
                    {
                    testTarget.RemoveComponent();
                    }
                }
            }

        }
    }