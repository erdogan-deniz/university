<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration {
    /**
     * Run the migrations.
     *
     * @return void
     */

    public function up()
    {
        Schema::create('permissions', function (Blueprint $table) {
            $table->id()->autoIncrement();
            $table->foreignId('user');
            $table->string('permission');
            $table->unique(['user', 'permission']);
            $table->foreign('user')->references('id')->on('users')->onDelete('cascade');
        });
    }

    public function down()
    {
        Schema::dropIfExists('permissions');
    }
};