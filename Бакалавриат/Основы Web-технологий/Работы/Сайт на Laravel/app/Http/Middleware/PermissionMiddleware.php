<?php

namespace App\Http\Middleware;

use Closure;
use Illuminate\Http\Request;
use Auth;

class PermissionMiddleware
{
    public function handle(Request $request, Closure $next, $required_permission)
    {
        if (Auth::check()) {
            if (Auth::user()->havePermission($required_permission))
                return $next($request);
        }
        return response()->view('auth.message', ['message'=>'access_deniend']);
    }
}
