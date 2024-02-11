using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public GameObject monster; // Ссылка на игровой объект монстра

    void Start()
    {
        StartCoroutine(ShowMonster()); // Запуск корутины ShowMonster
    }

    IEnumerator ShowMonster()
    {
        while (true) // Бесконечный цикл для появления монстра
        {
            yield return new WaitForSeconds(Random.Range(1f, 2f)); // Задержка от 1 до 2 секунд

            // Генерация случайного направления движения
            Vector3 direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);
            direction.Normalize(); // Нормализация вектора направления

            // Установка скорости движения монстра
            float speed = 5f;

            // Установка позиции монстра в случайное место на экране
            monster.transform.position = new Vector3(Random.Range(0f, Screen.width), Random.Range(0f, Screen.height), 0);

            // Цикл движения монстра
            while (monster.activeSelf) // Пока монстр активен
            {
                // Движение монстра в заданном направлении с учетом скорости
                monster.transform.Translate(direction * speed * Time.deltaTime);

                // Проверка, не ушел ли монстр за границы экрана
                if (monster.transform.position.x < 0 || monster.transform.position.x > Screen.width ||
                    monster.transform.position.y < 0 || monster.transform.position.y > Screen.height)
                {
                    monster.SetActive(false); // Если монстр вышел за границы экрана, он становится неактивным и исчезает
                }

                yield return null; // Ожидание следующего кадра
            }
        }
    }
}
