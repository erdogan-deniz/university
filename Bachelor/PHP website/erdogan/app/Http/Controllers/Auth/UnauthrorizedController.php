<?php

namespace App\Http\Controllers\Auth;

use Illuminate\Http\Request;
use App\Models\User;
use Illuminate\Support\Facades\Auth;
use Illuminate\Support\Facades\Mail;
class UnauthrorizedController extends \App\Http\Controllers\Controller
{

	public function register_do(Request $request)
	{
		$validated = $request->validate([	
			'name' => 'required',
			'sername' => 'required',
			'date' => 'required|date',
			'login' => 'required|unique:users,login',
			'email' => 'required|email|unique:users,email',
			'password' => 'required|min:8',
			'password2' => [
				'required',
				'min:8',
				function ($attribute, $value, $fail) {
			        global $request;
			        if ($request->get('password') !== $request->get('password2'))
				        $fail('The password != password2');
		        }
			],
			'telephone' => 'required|unique:users,telephone',
			'number' => 'required',
			'photo' => 'file',
			'gender' => 'required',
			'country' => 'required',
			'mark' => 'required',
		]);

		$validated['mark'] = $request->has('mark') ? 1 : 0;

		$user = \App\Models\User::create($validated);

		$photo = $request->hasFile('photo') ? $request->file('photo') : false;
		$photo_path_tmp = $photo ? $photo->getPathName() : '';
		$validated['photo'] = $photo ? 'avatars/' . $request->login : '';

		if ($photo) {
			@mkdir('avatars');
			copy($photo_path_tmp, $validated['photo']);
		}

		if (!Auth::guard()->attempt($validated))
			return view('auth.message', ['message' => 'register_done_but_auth_error']);
		return view('auth.message', ['message' => 'register_done']);


		$to_name = $user->login;
		$to_email = $user->email;
		Mail::send('auth.register_done_mail', ['name' => $user->name], function ($message) use ($to_name, $to_email) {
			$message->to($to_email, $to_name)->subject('Успешная регистрация!');
		});
	}
	public function login_do(Request $request)
	{
		$validated = $request->validate([
			'login' => 'required',
			'password' => 'required',
		]);

		if (!Auth::guard()->attempt($validated))
			return view('auth.message', ['message' => 'auth_error']);
		return view('auth.profile');
	}
}