Проект с тестами - YoutubeTests.

Тест-кейс #1

1. Заходим на https://www.youtube.com/
2. Переходим в меню Trending
3. Открываем третье видео по счету
4. Нажимаем Like
5. Проверка: Like не проставлен

Тест-кейс #2

1. Заходим на https://www.youtube.com/
2. Переходим в меню Trending
3. Открываем седьмое видео по счету
4. Нажимаем "Add a public comment..."
5. Проверка: Произошел редирект на страницу https://accounts.google.com/signin/

Тест-кейс #3

1. Заходим на https://www.youtube.com/
2. Выполняем поиск по слову "kaspersky"
3. Проверяем, что в выдаче есть аккаунт пользователя Kaspersky (https://www.youtube.com/user/Kaspersky)

Все основные настройки находятся в appsettings.json