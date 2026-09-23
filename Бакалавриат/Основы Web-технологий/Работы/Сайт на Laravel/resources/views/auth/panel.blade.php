@extends('layout')

@section('title')
@endsection
<?php $count= 0; ?>
@section('content')
@foreach($users as $user)
@if ($user->permission == "user")
<?php $count = 1; ?>
@endif
@endforeach

@if ($count == 1)
<h2>Панель администратора</h2>
<br>
<h1>
    </h2>
    <div>
        <table>
            <tr style="margin-left: 25px">
                <th>
                    <h4 style="margin-left: 20px"> Логин пользователя </h4>
                </th>
                <th>
                    <h4 style="margin-left: 20px">Пароль пользователя</h4>
                </th>
                <th></th>
            </tr>
            <br>
            @foreach($users as $user)
            @if ($user->permission != "admin")
            <tr>
                <td><span style="margin-left: 20px">{{$user->login}}</span></td>
                <td><span style="margin-left: 20px">{{$user->password}}</span></td>
                <td><a style="margin-left: 10px" href="{{route('auth.user.reset', $user->id)}}"><button>Сбросить пароль
                            пользователю</button> </a>
                    <br>
                </td>
            </tr>
            <tr>
            </tr>
            @endif
            @endforeach
        </table>
    </div>
    @else
    <h1>У вас нет пользователей!</h1>
    @endif
    @endsection