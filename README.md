# АРПО — лабораторные работы

Дисциплина: АРПО (Автоматизация разработки программного обеспечения)

Проект: 2D Platformer Microgame (Unity 6, 6000.6.0f1)

## Лабораторные работы

| Работа | Тема | Отчёт |
|---|---|---|
| ЛР№1 | Автоматизация сборки 2D-игры через командную строку (CLI) | [LR1.md](LR1.md) |
| ЛР№2 | Настройка репозиториев на GitHub и Sanity Check в GitHub Actions | [LR2.md](LR2.md) |
| ЛР№3 | Контейнеризация веб-сервера в Docker и раздача сжатых файлов со стороны Nginx | [LR3.md](LR3.md) |

## Структура репозитория

| Путь | Назначение |
|---|---|
| `Assets/Scenes/` | Игровые сцены проекта |
| `Assets/Editor/BuildManager.cs` | Скрипт автоматической сборки WebGL |
| `nginx.conf` | Кастомная конфигурация Nginx (заголовки `Content-Encoding: gzip`) |
| `Dockerfile` | Образ `nginx:alpine` со сжатой WebGL-сборкой |
| `.github/workflows/main.yml` | Пайплайн CI/CD (Sanity Check + зеркалирование + сборка образа в GHCR) |
| `docs/lr2/` | Скриншоты выполнения ЛР№2 |
| `docs/lr3/` | Скриншоты выполнения ЛР№3 |
| `Builds/WebGL/` | Выходная папка сборки (в git не попадает) |
| `.gitignore` | Исключения Git для проекта Unity |
| `build_webgl.log` | Лог консольной сборки (в git не попадает) |

## Курсы GitHub Skills

| ЛР | Курсы |
|---|---|
| ЛР№2 | Communicate using Markdown, Resolve merge conflicts, GitHub Pages |
| ЛР№3 | Hello GitHub Actions, Test with Actions, Write JavaScript Actions |

Подробности — в соответствующих файлах [LR2.md](LR2.md) и [LR3.md](LR3.md).