using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboSystem : MonoBehaviour
{
    public ComboAction comboAction;                             // ��ũ���ͺ� ������Ʈ �޺� ������
    public int currentActionIndex = 0;                          // �׼� �ε��� ����
    public float lastActionTime;                                // �׼� �ð�

    public ActionData PreformAction(Animator animator)
    {
        if(comboAction != null && currentActionIndex < comboAction.actions.Count)
        {
            if(Time.time - lastActionTime > 2.0f)               // 2�� �̻� �ð��� �������� �˻�
            {
                Debug.Log("�޺� �ð��� �ʰ��Ǽ� ���µǾ����ϴ�.");
                currentActionIndex = 0;
            }

            ActionData currentAction = comboAction.actions[currentActionIndex];

            lastActionTime = Time.time;                         // �׼� ���� �ð� ����
            currentActionIndex++;                               // ���� �׼����� �̵�

            if(currentActionIndex >= comboAction.actions.Count)  // ������ �׼� ���� �� üũ�Ͽ� �ε��� �ʱ�ȭ
            {
                Debug.Log("�޺� �Ϸ�");
                currentActionIndex = 0;
            }

            return currentAction;
        }

        return null;
    }
}
