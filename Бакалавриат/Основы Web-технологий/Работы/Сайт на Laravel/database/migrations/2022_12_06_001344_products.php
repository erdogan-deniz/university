<?php

use Illuminate\Database\Migrations\Migration;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Support\Facades\Schema;

return new class extends Migration {
    public function up()
    {
        Schema::create('products', function (Blueprint $table) {
            $table->id()->autoIncrement();
            $table->smallInteger('catalog');
            $table->smallInteger('manufacturer_id');
            $table->string('name', 255);
            $table->string('alias', 255);
            $table->text('short_description');
            $table->text('description');
            $table->decimal('price');
            $table->string('image', 255);
            $table->boolean('available')->default(true);
            $table->string("meta_keywords", 255)->nullable();
            $table->string("meta_description", 255)->nullable();
            $table->string("meta_title", 255)->nullable();
            $table->timestamps();
        });
    }

    public function down()
    {
        Schema::dropIfExists('products');
    }
};