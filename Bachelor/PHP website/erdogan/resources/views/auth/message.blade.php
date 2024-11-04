@extends('layout')

@section('title')
Сообщение
@endsection

@section('content')
<h1>
	@if($message == 'register_done')
	Успешная регистрация!
	@elseif($message == 'register_done_but_auth_error')
	Успешна регистрация, но войти не удалось!
	@elseif($message == 'auth_error')
	Неверный логин и/или пароль!
	@elseif($message == 'auth_required')
	Необходима авторизация!
	@elseif($message == 'access_deniend')
	Нет прав!
	@else
	???
	@endif
</h1>
@endsection