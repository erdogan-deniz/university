@extends('layout')

@section('title')
Каталог
@endsection

@section('content')

<head>
	<link href="/CSS/catalog.css" rel="stylesheet">
</head>
<div class="goods">
	@foreach($products as $product)
	<div class="product-item">
		<a href="#popup{{$product->id}}" class="item1Link popup-link">
			<div class="itemImage">
				<img src="{{ $product->image }}" alt="">
			</div>
			<div class="itemRating">
				<div class="stars1"></div>
			</div>
			<div class="itemTitle">
				<a href="{{route('shop.good.view', $product->id)}}">{{ $product->name }}</a>
			</div>
			<div class="itemPrice">{{ $product->price }}</div>
		</a>
		<button data-ajax="{{ route('shop.cart.add', $product->id) }}">Купить</button>
	</div>
	<div id="popup1" class="popup">
		<div class="popup_body">
			<div class="popup_content">
				<a href="#invise_header" class="popup_close close-popup"></a>
				<div class="navigation_menu">
					<a href="#popup10" class="item6Link popup-link">
						<div class="left"></div>
					</a>
					<a href="#popup{{$product->id}}" class="item2Link popup-link">
					</a>
				</div>
				<div class="popup_title">{{ $product->name }}</div>
				<div class="popup_Text">
					<img
						src="https://imgcdn.befree.ru/rest/V1/images/1024/product/images/2241293553/nTzwjYm2S5MFftEV46DRbNIZiX0BnJlKrWPNLljw.webp">
					<div style="text-align: left; margin-left: 20px">Состав:
						<br>
						<div style="text-align: justify">
							{{ $product->short_description }}
						</div>
					</div>
				</div>
			</div>
		</div>
	</div>
	@endforeach
	@if(count($products) == 0)
	Категория пуста.
	@endif
</div>
<script src="/JS scripts/modalWindows.js"></script>
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.1/jquery.min.js"></script>
@endsection