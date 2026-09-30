<?php

use Illuminate\Support\Facades\Route;
use App\Http\Controllers\StaticPageController;

Route::get('/s/{pageid}', [StaticPageController::class, 'show'])->name('static_page'); // Ссылочка внизу-слева страницы при наведении

Route::get('/', [StaticPageController::class, 'showMainpage']);

Route::redirect('/', '/s/Mainpage');

require_once(__DIR__ . '/auth.php');
require_once(__DIR__ . '/shop.php');