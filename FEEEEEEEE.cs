using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public GameObject monster; // ������ �� ������� ������ �������

    void Start()
    {
        StartCoroutine(ShowMonster()); // ������ �������� ShowMonster
    }

    IEnumerator ShowMonster()
    {
        while (true) // ����������� ���� ��� ��������� �������
        {
            yield return new WaitForSeconds(Random.Range(1f, 2f)); // �������� �� 1 �� 2 ������

            // ��������� ���������� ����������� ��������
            Vector3 direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);
            direction.Normalize(); // ������������ ������� �����������

            // ��������� �������� �������� �������
            float speed = 5f;

            // ��������� ������� ������� � ��������� ����� �� ������
            monster.transform.position = new Vector3(Random.Range(0f, Screen.width), Random.Range(0f, Screen.height), 0);

            // ���� �������� �������
            while (monster.activeSelf) // ���� ������ �������
            {
                // �������� ������� � �������� ����������� � ������ ��������
                monster.transform.Translate(direction * speed * Time.deltaTime);

                // ��������, �� ���� �� ������ �� ������� ������
                if (monster.transform.position.x < 0 || monster.transform.position.x > Screen.width ||
                    monster.transform.position.y < 0 || monster.transform.position.y > Screen.height)
                {
                    monster.SetActive(false); // ���� ������ ����� �� ������� ������, �� ���������� ���������� � ��������
                }

                yield return null; // �������� ���������� �����
            }
        }
    }
}
