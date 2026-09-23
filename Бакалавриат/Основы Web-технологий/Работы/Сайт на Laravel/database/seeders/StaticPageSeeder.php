<?php

namespace Database\Seeders;

use Illuminate\Database\Console\Seeds\WithoutModelEvents;
use Illuminate\Database\Seeder;

class StaticPageSeeder extends Seeder
{
    public function run()
    {
		\App\Models\StaticPage 	::factory()->create([
            'view' => 'simple',
			'urlname' => 'Blazer_End',
            'title' => 'Blazer',
			'content' => file_get_contents(__DIR__.'/BeFree/Source/Pages/Blazer_End.html'),
        ]);
		 
		 \App\Models\StaticPage 	::factory()->create([
            'view' => 'simple',
			'urlname' => 'Blog',
            'title' => 'Blog',
			'content' => file_get_contents(__DIR__.'/BeFree/Source/Pages/Blog.html'),
        ]);
		 
		\App\Models\StaticPage 	::factory()->create([
            'view' => 'simple',
			'urlname' => 'Catalog',
            'title' => 'Catalog',
			'content' => file_get_contents(__DIR__.'/BeFree/Source/Pages/Catalog.html'),
        ]);
		 
		 \App\Models\StaticPage 	::factory()->create([
            'view' => 'simple',
			'urlname' => 'Coat',
            'title' => 'Coat',
			'content' => file_get_contents(__DIR__.'/BeFree/Source/Pages/Coat.html'),
        ]);
	 
		\App\Models\StaticPage 	::factory()->create([
            'view' => 'simple',
			'urlname' => 'Contacts',
            'title' => 'Contacts',
			'content' => file_get_contents(__DIR__.'/BeFree/Source/Pages/Contacts.html'),
        ]);
		 
		\App\Models\StaticPage 	::factory()->create([
            'view' => 'simple',
			'urlname' => 'Feedback',
            'title' => 'Feedback',
			'content' => file_get_contents(__DIR__.'/BeFree/Source/Pages/Feedback.html'),
        ]);
		 
		\App\Models\StaticPage 	::factory()->create([
            'view' => 'simple',
			'urlname' => 'History',
            'title' => 'History',
			'content' => file_get_contents(__DIR__.'/BeFree/Source/Pages/History.html'),
        ]);
		
		\App\Models\StaticPage 	::factory()->create([
            'view' => 'simple',
			'urlname' => 'Instashop',
            'title' => 'Instashop',
			'content' => file_get_contents(__DIR__.'/BeFree/Source/Pages/Instashop.html'),
        ]);
		 
		\App\Models\StaticPage 	::factory()->create([
            'view' => 'simple',
			'urlname' => 'Jacket_End',
            'title' => 'Jacket',
			'content' => file_get_contents(__DIR__.'/BeFree/Source/Pages/Jacket_End.html'),
        ]);
		 
		\App\Models\StaticPage 	::factory()->create([
            'view' => 'simple',
			'urlname' => 'Jacket2_End2',
            'title' => 'Jacket_2',
			'content' => file_get_contents(__DIR__.'/BeFree/Source/Pages/Jacket2_End2.html'),
        ]);
		 
		\App\Models\StaticPage 	::factory()->create([
            'view' => 'simple',
			'urlname' => 'Leather_jacket_End',
            'title' => 'Leather_jacket',
			'content' => file_get_contents(__DIR__.'/BeFree/Source/Pages/Leather_jacket_End.html'),
        ]);
		 
		\App\Models\StaticPage 	::factory()->create([
            'view' => 'simple',
			'urlname' => 'Login',
            'title' => 'Login',
			'content' => file_get_contents(__DIR__.'/BeFree/Source/Pages/Login.html'),
        ]);
		 
		\App\Models\StaticPage 	::factory()->create([
            'view' => 'simple',
			'urlname' => 'Mainpage',
            'title' => 'Mainpage',
			'content' => file_get_contents(__DIR__.'/BeFree/Source/Pages/Mainpage.html'), 
        ]);
		
		\App\Models\StaticPage 	::factory()->create([
            'view' => 'simple',
			'urlname' => 'New',
            'title' => 'New',
			'content' => file_get_contents(__DIR__.'/BeFree/Source/Pages/New.html'), 
        ]);
		
		\App\Models\StaticPage 	::factory()->create([
            'view' => 'simple',
			'urlname' => 'News',
            'title' => 'News',
			'content' => file_get_contents(__DIR__.'/BeFree/Source/Pages/News.html'), 
        ]);
		
		\App\Models\StaticPage 	::factory()->create([
            'view' => 'simple',
			'urlname' => 'one-item',
            'title' => 'First_Item',
			'content' => file_get_contents(__DIR__.'/BeFree/Source/Pages/one-item.html'), 
        ]);
		
		\App\Models\StaticPage 	::factory()->create([
            'view' => 'simple',
			'urlname' => 'Registration',
            'title' => 'Registration',
			'content' => file_get_contents(__DIR__.'/BeFree/Source/Pages/Registration.html'), 
        ]);
		
		\App\Models\StaticPage 	::factory()->create([
             'view' => 'simple',
			 'urlname' => 'Sale',
             'title' => 'Sale',
			 'content' => file_get_contents(__DIR__.'/BeFree/Source/Pages/Sale.html'), 
        ]);
		
		\App\Models\StaticPage 	::factory()->create([
             'view' => 'simple',
			 'urlname' => 'Shops',
             'title' => 'Shops',
			 'content' => file_get_contents(__DIR__.'/BeFree/Source/Pages/Shops.html'), 
        ]);
		
		\App\Models\StaticPage 	::factory()->create([
             'view' => 'simple',
			 'urlname' => 'Skirt_End',
             'title' => 'SKirt',
			 'content' => file_get_contents(__DIR__.'/BeFree/Source/Pages/Skirt_End.html'), 
        ]);



    }
}
