@extends('layout')

@section('title')
	Регистрация завершена!
@endsection

@section('content')
Уважаемый, {!! Request::get('name') 	!!}, благодарим за регистрацию!
@endsection