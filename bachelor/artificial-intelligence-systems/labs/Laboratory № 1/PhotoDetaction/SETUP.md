# Сборка — PhotoDetaction

Проект .NET Framework, зависимости описаны в `packages.config` (14 пакетов, среди них
`EMGU.CV 4.1.1.3497` и `ZedGraph 5.1.7`). Папка `packages/` в репозиторий не кладётся.

## Как собрать

```
nuget restore Laboratory_number_one.sln
```

Дальше открыть решение в Visual Studio и собрать. Все пакеты из `packages.config`
доступны на nuget.org.
