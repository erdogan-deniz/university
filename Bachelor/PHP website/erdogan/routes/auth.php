<?php

use App\Http\Controllers\AdminPanelController;
use Illuminate\Support\Facades\Route;
use App\Http\Controllers\Auth\UnauthrorizedController;
use App\Http\Controllers\Auth\AuthrorizedController;


Route::get('/login.do', [UnauthrorizedController::class, 'login_do'])->name('auth.login.do');

Route::middleware('guest')->group(function () {
    Route::view('/register', 'auth.register')->name('auth.register');
    Route::post('/register.do', [UnauthrorizedController::class, 'register_do'])->name('auth.register.do');
});

// Route::middleware('auth', 'permission:profile.actions')->group(function () {

// });
Route::view('/profile', 'auth.profile')->name('auth.profile');
Route::post('/profile.update', [AuthrorizedController::class, 'profile_update'])->name('auth.profile.update');
Route::get('/logout', [AuthrorizedController::class, 'logout'])->name('auth.logout');
Route::view('/register_done', 'auth.register_done')->name('auth.register.done');
Route::get('/panel/{id}/reset',[AdminPanelController::class,'resetPassword'])->name('auth.user.reset');
Route::get('/panel', [AdminPanelController::class, 'getAllUsers'])->name('auth.getAll');