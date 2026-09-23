<?php

namespace App\Http\Controllers\Auth;

use Illuminate\Http\Request;
use App\Models\User;
use Illuminate\Support\Facades\Auth;

class AuthrorizedController extends \App\Http\Controllers\Controller
{

	public function profile_update(Request $request)
	{
		$validated = $request->validate([
			'name' => 'required',
			/*	'sername' => 'required',
			'date' => 'required|date',
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
			'country' => 'required',*/
		]);

		$photo = $request->hasFile('photo') ? $request->file('photo') : false;
		$photo_path_tmp = $photo ? $photo->getPathName() : '';
		$validated['photo'] = $photo ? 'avatars/' . $request->login : '';

		$user = Auth::user(); //::findOrFail(Auth::guard()->user()->id);
		$user->name = $validated['name'];
		$user->save();

		if ($photo) {
			@mkdir('avatars');
			copy($photo_path_tmp, $validated['photo']);
		}


		return view('auth.message', ['message' => 'profile_updated']);
	}

	public function logout(Request $request)
	{
		Auth::logout();
		$request->session()->invalidate();
		$request->session()->regenerateToken();
		return redirect('');
	}
}