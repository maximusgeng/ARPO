# Лабораторная работа №1. Автоматизация сборки 2D игры через командную строку (CLI)

Дисциплина: АРПО (Автоматизация разработки программного обеспечения)

Проект: 2D Platformer Microgame (Unity 6000.3.11f1 и выше)

## Структура репозитория

| Путь | Назначение |
|---|---|
| `Assets/Scenes/` | Игровые сцены проекта |
| `Assets/Editor/BuildManager.cs` | Скрипт автоматической сборки WebGL |
| `Builds/WebGL/` | Выходная папка сборки (в git не попадает) |
| `.gitignore` | Исключения Git для проекта Unity |
| `build_webgl.log` | Лог консольной сборки (в git не попадает) |

## Как собрать игру из командной строки

PowerShell (путь к Unity.exe подставьте под свою версию):

```powershell
& "C:\Program Files\Unity\Hub\Editor\6000.3.11f1\Editor\Unity.exe" -batchmode -nographics -projectPath . -executeMethod BuildManager.BuildWebGL -quit -logFile build_webgl.log
```

Результат: папка `Builds/WebGL/` с файлами `index.html`, `Build/`, `StreamingAssets/`.
В конце `build_webgl.log` должна быть строка `[CI/CD] УСПЕХ! WebGL билд успешно создан.`

## Как запустить собранную игру локально

Двойной клик по `index.html` не работает (ошибка CORS). Откройте папку
`Builds/WebGL/` в VS Code и запустите расширение **Live Server** (кнопка
*Go Live*) — игра откроется на `http://127.0.0.1:5500`.

## Ход работы (кратко)

1. **Шаг 1.** Создан проект на базе шаблона 2D Platformer Microgame, сцена добавлена в Build Settings. — *[ВСТАВИТЬ СКРИНШОТ: окно Build Settings со сценой]*
2. **Шаг 2.** Создана папка `Assets/Editor/` и скрипт `BuildManager.cs` с методом `BuildWebGL()`. — *[ВСТАВИТЬ СКРИНШОТ: код скрипта в IDE]*
3. **Шаг 3.** В Publishing Settings отключено сжатие WebGL (Gzip → Disabled). — *[ВСТАВИТЬ СКРИНШОТ: Project Settings → Player → Publishing Settings]*
4. **Шаг 4.** Скрипт скомпилирован без ошибок. — *[ВСТАВИТЬ СКРИНШОТ: Console без ошибок]*
5. **Шаг 5.** Сборка запущена из терминала командой `-batchmode -nographics -executeMethod BuildManager.BuildWebGL -quit -logFile build_webgl.log`. — *[ВСТАВИТЬ СКРИНШОТ: терминал с командой]*
6. **Шаг 6.** Лог сборки проанализирован: `[CI/CD] УСПЕХ! WebGL билд успешно создан.`, время и размер сборки зафиксированы. — *[ВСТАВИТЬ СКРИНШОТ: конец build_webgl.log]*
7. **Шаг 7.** Игра запущена через Live Server, загрузка и управление работают. — *[ВСТАВИТЬ СКРИНШОТ: игра в браузере]*
8. **Шаг 8.** Инициализирован Git, создан `.gitignore`, базовый коммит в `main`, скрипт сборщика закоммичен в ветке `LR1` и отправлен на GitHub. — *[ВСТАВИТЬ СКРИНШОТ: git log / страница GitHub]*
9. **Шаг 9.** Создан Pull Request `LR1 → main`, получены аппрувы двух рецензентов, PR слит. — *[ВСТАВИТЬ СКРИНШОТ: Merge pull request]*

## История коммитов

```text
[ВСТАВИТЬ ВЫВОД: git log --oneline --graph --all]
```
