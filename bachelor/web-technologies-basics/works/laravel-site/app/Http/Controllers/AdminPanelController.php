<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\Models\User;
use Illuminate\Support\Str;

class AdminPanelController extends Controller
{

    public function getAllUsers()
    {
        $users = User::all();

        return view('auth.panel', ['users' => $users]);
    }


    public function resetPassword($id)
    {
        $user = User::find($id);
        $user->forceFill([
            'password' => Str::random(10)
        ])->setRememberToken(Str::random(20));
        $user->save();
        return redirect()->back();
    }

}