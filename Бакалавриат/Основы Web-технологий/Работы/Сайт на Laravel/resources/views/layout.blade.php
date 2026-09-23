<html>

<head>
    <meta charset="UTF-8">
    <link rel="stylesheet" href="/CSS/index.css">
    <link rel="stylesheet" href="../../CSS/pages.css ">
    <link rel="stylesheet" href="../../CSS/registration.css  ">
    <script src="/Source/JS scripts/jquery-3.6.1.min.js"></script>
    <script src="https://unpkg.com/imask"></script>
    <script src="/Source/JS scripts/password.js"></script>
    <script src="/Source/JS scripts/autocompletes.js"></script>
    <title>BeFree - @yield('title')</title>
</head>

<body>
    <table id="header_table">
        <th><a href="/s/Mainpage"><img src="https://befree.ru/static/images/icons/logo.svg"></a></th>

        <th id="second_column_header">Магазин одежды</th>

        <th id="third_column_header">
            @auth
            <span style="color: blue">
                Здравствуйте, {{auth()->user()->name}} ! <br />
                <a href="{{ route('auth.profile')}}"> Профиль </a> <br />
                <a href="{{ route('auth.logout')}}"> Выйти </a> <br />
            </span>
            @else
            <form method="GET" action="{{route('auth.login.do')}}">
                <label>Логин:</label>
                <input id="h_login" placeholder="Введите ваш логин или почту или телефон" type="text" name="login"
                    required>

                <div class="high_password" style="margin-top: 10px">
                    <label>Пароль:</label>
                    <input id="h_password" placeholder="Введите ваш пароль" type="password" name="password" required>
                </div id="pages_text">
                <a href="{{ route('auth.register') }}">
                    Регистрация</a>
                <button type="submit" id="button2">Войти</button>
            </form>
            @endauth
        </th>
    </table>

    <table id="under_header_table">
        <td><a href="{{ route('shop.category.view', 1)}}">Новинки</a></td>
        <td><a href="{{ route('shop.category.view', 2)}}">Каталог</a></td>
        <td><a href="{{ route('shop.category.view', 3)}}">Распродажа</a></td>
        <td><a href="{{ route('shop.cart.view')}}">Корзина</a></td>
    </table>

    <table id="left_table">
        <td id="left_column">
            <br>
            <a href="{{ route('static_page', 'Blog')}}">Блог</a>
            <br>
            <a href="{{ route('static_page', 'News')}}">Новости</a>
            <br>
            <a href="{{ route('static_page', 'History')}}">История</a>
            <br>
            <a href="{{ route('static_page', 'Instashop')}}">Инсташоп</a>
            <br>
            <a href="{{ route('static_page', 'Contacts')}}">Контакты</a>
            <br>
            <a href="{{ route('static_page', 'Feedback')}}">Обратная связь</a>
            @auth
            @if (auth()->guard()->user()->permission == "admin")
            <br>
            <a href="{{ route('auth.getAll')}}">Панель администратора</a>
            </br>
            @endif
            @endauth
        </td>

        <td valign="top ">
            @yield('content')
            <br>
        </td>
        <td id="right_column">
            <br>
            <br>
            <input placeholder="Товар" type="text" style="width: 150px;">
            <br>
            <button style="width: 55px; margin-top: 10px">Поиск</button>
            <br>

            <h3 style="margin-top: 40px">Топ сезона</h3>
            <a href="{{ route('static_page', 'Item-3')}}"><img id="photo" src="/Photos/Jacket_End.webp"></a>
            </br>

            <br><a href="{{ route('static_page', 'Item-4')}}">
                <img id="photo" src="/Photos/Jacket2_End.webp">
            </a>
            </br>

            <br>
            <a href="{{ route('static_page', 'Item-1')}}">
                <img id="photo" src="/Photos/Blazer.webp">
            </a>
            </br>
        </td>
    </table>

    <table id="low_table">
        <th style="color: rgb(210, 210, 221); margin-left: 0px">
            <p>Все права защищены ©</p>
        </th>
    </table>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.1/jquery.min.js"></script>
    <script src="/JS scripts/snow.js"></script>
    <script src="/JS scripts/notify.js"></script>
    <script>
        $(() => {
            $('[data-ajax]').click(() => {
                var el = $(event.target);
                var after = el.data('ajax-after') != undefined ? el.data('ajax-after') : false;
                console.log(after);
                $.ajax(el.data('ajax'))
                    .done((text) => {
                        $.notify(text, 'success');
                        if (after) {
                            eval(after)
                        }
                    })
                    .fail((xmlHttpRequest) => {
                        $.notify(xmlHttpRequest.statusText + ' ' + xmlHttpRequest.status, 'error');
                    })

            });
        })
    </script>

</body>

</html>