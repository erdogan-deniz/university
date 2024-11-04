@extends('layout')

@section('title')
{{ $product->name }}
@endsection

@section('content')
<link href="/CSS/one-item.css" rel="stylesheet">
<table>
    <tr>
        <div class="image">
            <img src={!! $product->image !!}>
            </img>
    </tr>
    <br>
    <br>
    </div>
    <!--h3> Куртка из экомеха с воротником-стойкой: </h3-->
    <P> Цена:
    <h4> {!! $product->price !!} ₽ </h4>
    </p>
    <p style="text-align: center"> {!! $product->description !!}
    </p>
    </br>
</table>
@endsection