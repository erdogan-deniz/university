@extends('layout')

@section('title')
Корзина
@endsection

@section('content')
<link href="/CSS/cart.css" rel="stylesheet">
<div>
	@foreach($cart as $id => $item)
	<div class="goods2" id="cart_item_{{$id}}">
		<div class="item1">
			<a href="#popup1" class="item1Link popup-link">
				<div class="itemImage">
					<img src="{{$item['image']}}">
				</div>
				<div class="itemRating">
					<div class="stars1"></div>
				</div>
				<div class="itemTitle">
					<a href="{{ route('shop.good.view', $id)}}">{{$item['name']}}</a>
				</div>
				<div class="itemPrice">{{$item['price']}} ₽</div>
				<div class="goods">
					<button data-ajax="{{route('shop.cart.remove', $id)}}"
						data-ajax-after="hide('cart_item_{{$id}}')">Удалить</button>
					<span id="cart_item_count{{$id}}">{{$item['count']}} </span>
				</div>
		</div>
		<button class="goods2" data-ajax="{{route('shop.cart.inc', $id)}}"
			data-ajax-after="inc('cart_item_count{{$id}}')">+
		</button>
		<button data-ajax="{{route('shop.cart.dec', $id)}}"
			data-ajax-after="dec('cart_item_count{{$id}}', 'cart_item{{$id}}')">-</button>
		</a>
	</div>
</div>
@endforeach

@if(count($cart) == 0)
Корзина пуста.

@else
<h1>Сумма: <span id="total_price"></span></h1>
@endif
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.1/jquery.min.js"></script>
<script>
		update_total();
		
	function hide(id) {
		$('#' + id).hide()
		update_total();
	}

	function inc(id) {
		$('#' + id).text(parseInt($('#' + id).text()) + 1)
		update_total();
	}

	function dec(id, card_id) {
		update_total();
		var val = parseInt($('#' + id).text()) - 1
		$('#' + id).text(val);
		if (val < 1)
			hide(card_id);
		update_total();

	}

	function update_total() {
		$.ajax("{{ route('shop.cart.total_price') }}")
			.done((text) => {
				$('#total_price').text(text);
			})
			.fail((xmlHttpRequest) => {
				$.notify(xmlHttpRequest.statusText + ' ' + xmlHttpRequest.status, 'error');
			});
	}
	update_total();
</script>
@endsection