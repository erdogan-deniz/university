<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration {
    public function up()
    {
        Schema::create('users', function (Blueprint $table) {
            $table->id();
            $table->string('name');
            $table->string('email');
            $table->string('sername');
            $table->date('date');
            $table->string('login')->unique();
            $table->string('password');
            $table->string('telephone')->unique();
            $table->string('number')->unique();
            $table->string('photo');
            $table->string('gender');
            $table->string('country');
            $table->string('permission')->default("user");
            $table->boolean('mark');
            $table->timestamp('email_verified_at')->nullable();
            $table->rememberToken();
            $table->timestamps();
        });
    }

    public function down()
    {
        Schema::dropIfExists('users');
    }
};