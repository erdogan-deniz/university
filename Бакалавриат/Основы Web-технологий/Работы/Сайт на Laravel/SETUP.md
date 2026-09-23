# Запуск — сайт на Laravel

PHP-проект, зависимости описаны в `composer.json` и `package.json`. Папки `vendor/`
и `node_modules/` в репозиторий не кладутся.

## Как запустить

```
composer install
npm install
cp .env.example .env
php artisan key:generate
php artisan migrate
php artisan serve
```

Настройки подключения к базе — в `.env`, он создаётся из `.env.example` и в git не
попадает. В самом `.env.example` реальных значений нет, только имена переменных.
