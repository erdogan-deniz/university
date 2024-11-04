<?php
namespace App\Providers;
use \Illuminate\Contracts\Auth\UserProvider as UserProvider;
use \Illuminate\Support\Facades\DB;
use \Illuminate\Auth\GenericUser as GenericUser;
use \Illuminate\Contracts\Auth\Authenticatable as Authenticatable;

class PDOUserProvider implements UserProvider
{

    public function conn()
    {
        return DB::connection()->getPdo();
    }

    public function retrieveById($identifier)
    {
        /*
        $row = $this-> conn()->query("SELECT * FROM users WHERE id=".$identifier)->fetch();
    if ($row)
        return $this->getGenericUser($row);
        */
        return \App\Models\User::find($identifier);
    }

    public function retrieveByToken($identifier, $token)
    {
    }


    public function updateRememberToken(Authenticatable $user, $token)
    {
    }


    public function retrieveByCredentials(array $credentials)
    {
        $row = $this -> conn()->query("SELECT * FROM users WHERE (login='". $credentials['login']."' OR email='". $credentials['login']."' OR telephone='". $credentials['login']."') AND password='". $credentials['password']."'")->fetch();
        if ($row)
            return $this->getGenericUser($row);
    }

    protected function getGenericUser($user)
    {
        if (!is_null($user)) {
            return new GenericUser((array) $user);
        }
    }

    public function validateCredentials(Authenticatable $user, array $credentials)
    {
        $row = $this -> conn()->query("SELECT * FROM users WHERE (login='" . $credentials['login']."' OR email='". $credentials['login']."' OR telephone='". $credentials['login']."') AND password='". $credentials['password']."'")
            ->fetch();
        return $row ? true : false;
    }
}