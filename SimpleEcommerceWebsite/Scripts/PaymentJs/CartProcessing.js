$(document).ready(function () {
    GetAllItemInCart();
    GetTotalAmount();
});

function AddToCart(productId, quantity) {

    $.ajax({
        url: '/Home/AddToCartProduct/',
        type: 'POST',
        data: {
            productId: productId,
            numberOfProduct: quantity
        },
        async: false, cache: false, traditional: true,
        success: function (data) {
            console.log(data);
            if (data == true) {
                alert("Add success");
            } else {
                alert("Add success");
            }
        }
    });

    GetAllItemInCart();
    GetTotalAmount();
}

function GetAllItemInCart() {
    $.ajax({
        url: '/Home/GetDraftCarts/',
        type: 'POST',
        async: false, cache: false, traditional: true,
        success: function (data) {
            console.log(data);
            if (data > 0) {
                $(".number_product_on_cart").text(data);
            } else {
                $(".number_product_on_cart").text(0);
            }
        }
    });
}

function GetTotalAmount(){
    $.ajax({
        url: '/Home/GetTotalAmount/',
        type: 'POST',
        async: false, cache: false, traditional: true,
        success: function (data) {
            console.log(data);
            if (data > 0) {
                $(".totalAmount").text('$'+data);
            } else {
                $(".totalAmount").text(0);
            }
        }
    });
}
//function