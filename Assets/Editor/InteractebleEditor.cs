using UnityEditor;

[CustomEditor(typeof(Interacteble), true)]
public class InteractebleEditor : Editor// ����������� �� Editor , �� �������� ����������� �������� ��� ������� Interacteble
                                        //�� ��� ��� ������� ���� [CustomEditor(typeof(Interacteble),true)] - True �������� ��� 
                                        // ��������� ��� �� ����� ���������� ��� �������� ������ ��������������� �� ���� 
{


    public override void OnInspectorGUI()// ���������� ������ ��� ����� ����� ��������� ��������� ��������� 
    {
        Interacteble interacteble = (Interacteble)target;// ��� ����� ������ ������� ������ � ���������  

        if (target.GetType() == typeof(InteractebleOnlyEvents))// �� ��������� �������� �� ��� ��������� Interacteble = InteractebleOnlyEvents
        {

            interacteble.Prompt = EditorGUILayout.TextField("Prompt", interacteble.Prompt);// �� ������� ���� � ��������� � ��������� Prompt
                                                                                           // , ��� ����� ����������� �������� ��� interacteble.Prompt


            EditorGUILayout.HelpBox("InteractebleOnlyEvents Can only Use UnityEvents", MessageType.Info);// �� ������� �������������� ������
                                                                                                         // � �������� ������� 

            if (interacteble.GetComponent<InteractebleEvents>() == null)// ��������� ���� �� �� ������� InteractebleEvents
            {
                interacteble.UseEvents = true;
                interacteble.gameObject.AddComponent<InteractebleEvents>();
            }
        }
        else// ���� ��� �� �� ���������� �������� �� ���������
        {
            base.OnInspectorGUI();// ��� ��������� ��� Editor �� ��������� 

            if (interacteble.UseEvents)//�������� ����� �� �� ��������� ������ � ��������� 
            {
                if (interacteble.GetComponent<InteractebleEvents>() == null) // �� ��������� ����� �� ��� ����� � ������� ? 
                {
                    interacteble.gameObject.AddComponent<InteractebleEvents>();// ���� ��� �� ��������� ��� 
                }
            }
            else// ���� ����� �������� ������ ��� �� �� ���������� ������
            {
                if (interacteble.GetComponent<InteractebleEvents>() != null)// ���� ��� ����� �� ������� 
                {
                    DestroyImmediate(interacteble.GetComponent<InteractebleEvents>());// �� �� �� ������� 
                }
            }

        }

    }


}
