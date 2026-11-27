# Лабораторная работа № 5. Автоматическая сборка Unity WebGL и публикация на GitHub Pages

**Цель** – собрать 2D Platformer в GitHub Actions и передать один WebGL-билд в GitHub Pages и Docker-образ.

## Настройка проекта и конвейера

Использован проект из ЛР №1–4 с Unity 6000.6.0f1 и основной веткой `main`. В настройках WebGL сохранено Gzip-сжатие (`webGLCompressionFormat: 1`) и включён Decompression Fallback. В этой версии Unity с такими настройками выходные файлы получают расширение `.unityweb`.

| Задача | Действие |
|---|---|
| `sanity_check` | Проверяет структуру Unity-проекта. |
| `run_tests` | Запускает EditMode и PlayMode и сохраняет `test-results`. |
| `build_game` | Вызывает `BuildManager.BuildWebGL` после тестов. Проверяет `index.html` и целостность Gzip-файлов. Выгружает `WebGL-Build`. |
| `build_docker_image` | Скачивает `WebGL-Build` в `Builds/WebGL` и публикует образ `ghcr.io/maximusgeng/arpo` с тегами `latest` и SHA коммита. |
| `deploy_to_pages` | Передаёт содержимое `WebGL-Build` в GitHub Pages через Actions. |
| `mirror_repo` | Запускает зеркалирование после успешных тестов при push в `main`. |

Вместо выгрузки в ветку `gh-pages` настроена публикация артефакта через `actions/deploy-pages`. Коммиты, отправленные в служебную ветку с `GITHUB_TOKEN`, не запускают сборку Pages. В Settings → Pages выбран источник **GitHub Actions**. [Документация GitHub Pages](https://docs.github.com/en/pages/getting-started-with-github-pages/configuring-a-publishing-source-for-your-github-pages-site)

## Проверка

Локальный вызов `BuildManager.BuildWebGL` завершился успешно за 194,25 с. Unity сообщила размер сборки 19 449 900 байт. В выходной папке есть `index.html`, `TemplateData`, загрузчик и три сжатых ресурса.

В Chromium обычный HTTP-сервер отдал три файла `.unityweb` со статусом 200 без `Content-Encoding`. Игра загрузилась без ошибок в консоли. Игровая сцена показана на скриншоте ниже.

![Игровая сцена при локальной проверке](docs/lr5/gameplay.png)

Из той же сборки создан локальный образ `arpo-lr5:local`. Для файлов JavaScript, WebAssembly и данных Nginx вернул 200 и `Content-Encoding: gzip`. Целостность архивов проверена командой `gzip -t`. Chromium загрузил игру из контейнера без ошибок.

Для облачной проверки требуются секреты `UNITY_LICENSE`, `UNITY_EMAIL` и `UNITY_PASSWORD` в [настройках репозитория](https://github.com/maximusgeng/ARPO/settings/secrets/actions). На момент выполнения работы эти секреты отсутствуют. После их настройки прогон pull request проверит тесты и соберёт артефакт. Push в `main` после успешных тестов и сборки также опубликует игру на [GitHub Pages](https://maximusgeng.github.io/ARPO/) и образ в GHCR.

## Контрольные вопросы

1. **Почему сборка исключена из Git?** Это производные файлы. Задача `build_game` загружает их как артефакт `WebGL-Build`, обе задачи публикации скачивают его в свой рабочий каталог.
2. **Зачем нужно `needs: run_tests`?** Зависимость пропускает `build_game` при падении тестов. Обе публикации зависят от сборки и также пропускаются. Зеркалирование напрямую зависит от тестов.
3. **Какую роль играет `BuildManager.BuildWebGL`?** Метод берёт включённые сцены, вызывает `BuildPipeline.BuildPlayer` для WebGL и записывает результат в `Builds/WebGL`. В пакетном режиме код выхода Unity передаёт статус GameCI, а лог содержит длительность и размер сборки.
4. **Чем отличается распаковка на Pages и в Nginx?** GitHub Pages не позволяет задать заголовок `Content-Encoding: gzip` для архивов Unity. При включённом Fallback их распаковывает загрузчик игры. В контейнере Nginx выставляет этот заголовок для сжатых ресурсов, и распаковку выполняет браузер.
5. **Зачем Pages и GHCR?** Pages даёт ссылку для игры в браузере. GHCR хранит образ для запуска на Docker-хосте. `latest` указывает на последнюю опубликованную сборку, SHA позволяет выбрать образ конкретного коммита.
6. **Почему сайт может отдавать 404?** Успешная запись в `gh-pages` подтверждает сохранение файлов в Git. Для доступа к сайту нужно включить Pages, выбрать корректный источник и дождаться публикации. При деплое через Actions нужно выбрать GitHub Actions и проверить результат `deploy-pages` и опубликованный URL.
