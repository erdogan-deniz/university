<?php

use Illuminate\Support\Facades\Route;
use App\Http\Controllers\ShopController;

Route::get('/catalog/{id}', [ShopController::class, 'catalog_view'])->name('shop.category.view');
Route::get('/good/{id}', [ShopController::class, 'item_view'])->name('shop.good.view');
Route::get('/cart/', [ShopController::class, 'cart_view'])->name('shop.cart.view');

Route::get('/cart/add/{id}', [ShopController::class, 'cart_add'])->name('shop.cart.add');
Route::get('/cart/remove/{id}', [ShopController::class, 'cart_remove'])->name('shop.cart.remove');
Route::get('/cart/inc/{id}', [ShopController::class, 'cart_inc'])->name('shop.cart.inc');
Route::get('/cart/dec/{id}', [ShopController::class, 'cart_dec'])->name('shop.cart.dec');

Route::get('/cart/total_price', [ShopController::class, 'cart_total_price'])->name('shop.cart.total_price');