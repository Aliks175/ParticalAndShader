using UnityEditor;

[CustomEditor(typeof(Interacteble), true)]
public class InteractebleEditor : Editor// наследуемс€ от Editor , мы замен€ем стандартный редактор дл€ скрипта Interacteble
                                        //на тот что напишем сами [CustomEditor(typeof(Interacteble),true)] - True означает что 
                                        // изменению так же будут подвержены все дочерние классы отнаследованные от него 
{


    public override void OnInspectorGUI()// ¬ызываетс€ каждый раз когда юнити обновл€ет интерфейс редактора 
    {
        Interacteble interacteble = (Interacteble)target;// тот самый скрипт который выбран в редакторе  

        if (target.GetType() == typeof(InteractebleOnlyEvents))// мы провер€ем €вл€етс€ ли наш экземпл€р Interacteble = InteractebleOnlyEvents
        {

            interacteble.Prompt = EditorGUILayout.TextField("Prompt", interacteble.Prompt);// мы создаем поле в редакторе с названием Prompt
                                                                                           // , оно будет присваивать значение дл€ interacteble.Prompt


            EditorGUILayout.HelpBox("InteractebleOnlyEvents Can only Use UnityEvents", MessageType.Info);// мы создаем информационную плашку
                                                                                                         // с введеным текстом 

            if (interacteble.GetComponent<InteractebleEvents>() == null)// провер€ем есть ли на объекте InteractebleEvents
            {
                interacteble.UseEvents = true;
                interacteble.gameObject.AddComponent<InteractebleEvents>();
            }
        }
        else// если нет то мы используем редактор по умолчанию
        {
            base.OnInspectorGUI();// это реализует наш Editor по умолчанию 

            if (interacteble.UseEvents)//проверка будем ли мы добавл€ть ивенты в редакторе 
            {
                if (interacteble.GetComponent<InteractebleEvents>() == null) // мы провер€ем весит ли уже класс с ивентом ? 
                {
                    interacteble.gameObject.AddComponent<InteractebleEvents>();// если нет то добавл€ем его 
                }
            }
            else// если после проверки решили что мы не используем ивенты
            {
                if (interacteble.GetComponent<InteractebleEvents>() != null)// если они вес€т на объекте 
                {
                    DestroyImmediate(interacteble.GetComponent<InteractebleEvents>());// то мы их удал€ем 
                }
            }

        }

    }


}
