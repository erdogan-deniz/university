@extends('layout')

@section('title')
Регистрация
@endsection

@section('content')
<h1 id="pages_text">Регистрация аккаунта</h1>

<div>
	<form action="{{route ('auth.register.do') }}" method="POST" enctype="multipart/form-data">
		<br>
		<label for="Name">Введите ваше имя:</label>
		<br>
		<input id="Name" class="Name" placeholder="Иван" type="text" id="Send" maxlength="50" name='name'
			value="{{ @old('name') }}" required>
		<div class="name-error">Ваше имя должно содержать больше двух букв</div>
		<br>
		<label for="Surname">Введите вашу фамилию:</label>
		<br>
		<input id="Surname" placeholder="Иванов" type="text" id="Send" maxlength="50" name='sername'
			value="{{ @old('sername') }}" required>
		<br>
		<br>
		<label style="margin-top: 5px" for="Data">Выберите дату рождения:</label>
		<br>
		<input id="Data" type="date" value="{{ @old('date') }}" min="1960-01-01" max="2016-01-01" id="Send" name='date'
			required>
		<br>
		<br>
		<label for="Login">Введите ваш логин: </label>
		<br>
		<input id="Login" class="Login" placeholder="examplelogin" type="text" id="Send" maxlength="50" name='login'
			value="{{ @old('login') }}" required>
		<div class="login-error">Ваш логин должен содержать больше восьми букв</div>
		<br>
		<br>
		<label for="Email">Введите ваш Email: </label>
		<br>
		<input id="Email" class="Email" placeholder="befree@world.com" type="email" id="Send" maxlength="50"
			name='email' value="{{ @old('email') }}" required>
		<br>
		<br>

		<label for="pass">Введите ваш пароль:<br>
		</label>
		<input id="pass" class="pass" placeholder="12345" type="password" maxlength="50" minlength="8" name='password'
			value="{{ @old('password') }}" required>
		<div class="password-error">Ваш пароль должен содержать больше восьми букв</div>
		<br>
		<br>

		<label for="pass2">Введите повторно пароль:<br></label>
		</label>
		<input id="pass2" class="pass2" placeholder="..." type="password" minlength="8" maxlength="50" name='password2'
			value="{{ @old('password2') }}" required>
		<div class="password2-error">Пароли не совпадают</div>
		<br>
		<br>
		<label for="phone-mask">Введите ваш номер телефона:</label>
		<input id="phone-mask" placeholder="+7-926-666-66-66" type="text" name='telephone'
			value="{{ @old('telephone') }}" required>
		<br>
		<br>
		<label for="credit-mask">Номер карты лояльности</label>
		<input id="credit-mask" placeholder="0000 0000 0000 0000" type="text" name='number' value="{{ @old('number') }}"
			required>
		<br>
		<br>
		<input type="file" id="file" name='photo' required>
		<br>
		<br>
		<label for="Gender">Выберите ваш пол:</label>
		<input id="Gender" type="radio" name="gender" id="esc" value="m" checked required>
		<label for="Мужской">Мужской</label>
		<input type="radio" name="gender" value="w">
		<label for="Женский">Женский</label>
		<br>
		<br>
		<div class="autocomplete">
			<label for="countryInput">Страна рождения</label>
			<input class="inpauto" id="countryInput" name="country" value="{{ @old('country') }}">
		</div>
		<br>
		<label for="PersData">Подтвердите согласие на обработку персональных данных:</label>
		<input type="checkbox" id="PersData" name='mark' checked required>
		<br>
		<br>
		<br>
		<label for="Send">Подтвердитe согласие на персональную рассылку:</label>
		<input type="checkbox" id="Send" name='mark2' checked required>
		<br>
		<br>
		<br>
		<input id="button" type="submit" value="Зарегестрировать" name="final"></input>
	</form>
</div>

<div style="color: red">
	@if ($errors->any())
	<div class="alert alert-danger">
		<ul>
			@foreach ($errors->all() as $error)
			<li>{{ $error }}</li>
			@endforeach
		</ul>
	</div>
	@endif
</div>

<script>
	function Message() {
		alert("Вы зарегистрировал	ь!)		}		vr	honeMask = IMask			doc		nt.getElementById('phone-mask'), {
		ask + { 7}(000)000 - 00 - 00'
	}	


	rc		ask = IMask(
			document		ElementById('credit-mask'), {
			mask: '000		00 0000 0000'
		});

	functi		hek	s	rd(form) {
		debugger
		pas		rd		 doc		nt.rySelector("input[id ='pass']").value;
		password2 = docu		t.qu		Selector("input[id ='pass2']").value;

		// If password nt		tere
		f(password1 == ''				alert		ведите паро			;
		// 			onfirm passwor		ot entere			else if (password2 == 		
		alert(дтвердите ваш			оль");

					f Not same return Fl		
		else if p		word1 != pass		d2) {
			alert		ароли не совпадают						return fals
		}

	}
</script>

<script>
	let name = n	geElC	ssName		am'		lt d	ument.getElementsByC	ssName('Login')
	let email = d	ument.getElementsByCl	sName('Email')
	let password = cument.getElementsBy	assName('Pass')
	let password2 = ocument.getElementsBy	assName('Pass2')
	let nameErr = d	ument.getElementsByCla	Name("name-error")
	let loginErr = ocument.getElementsByCla	Name("login-error")
	let passwordEr = document.getElementsByC	ssName("password-error")
	let passwo	2Err = document.getElementsByC	ssName("password2-error")

	console.l(login[0].value)
	console.log(lg)

	login[0] = addEventListe	r('input,	) => {
		(login[0].value.le	th > 8) {
		login[]	l		List.remove('invalid');
		login[lassLi		add('valid');
		loginErr[0].s.remove('show')
	}
		else {
			login[0			assList.remove('valid');
			og		0			as			t.add('invalid');
			loginErr[0]		a			t.add('			')
		}
	})

	name[0] = ventListen			input', () => {
	if		am	0].a	e.len > 2) {
		name[0].classList.remove		va	d')
		name[0].classList.ad			alid');
		nameErr[0		lassList.remov			how')
	}
		els						name[0].cl			ist.remove('valid');
	ame[0].clas		st		d('inva			);
					eErr[0].classList.add('sho			
		}
	}			p		word[0]			ddEventL			ner('input', () => {
		i			asswod.v	ue.e	th > 8) {
		passw			0].classList.remove('inval		);
		p		wo[0]c	ssList.add('val			;
			passwordErr[0].classList.ove('sho			
		}
		else {
			password			classLi			emove('valid');
			password[0].sLista		'i		lid');
	asswordErr[0].sList.add('show')

					)

	password2[0] = dE		tListen			i			', () => {
	if (password[0].value 				wo	2[0.	lue) {
		password2[0].classL			remove('invalid'					password2[0].clas		t.d('a	d');
			pass			2Err[0].classList.remove('show')
					els						password2[0].classList.remove('val							password2[0].classList.add('invalid'							word2			0].classList.add('show')
		}
	})

</script>
@endsection