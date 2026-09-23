# Сборка — SecurityInformation

Проект .NET Framework, зависимости в `packages.config` (10 пакетов, среди них
`CsvHelper 30.0.1` и `Portable.BouncyCastle 1.9.0`). Папка `packages/` в репозиторий
не кладётся.

## Как собрать

```
nuget restore SecurityInformation.sln
```

Дальше сборка из Visual Studio.
