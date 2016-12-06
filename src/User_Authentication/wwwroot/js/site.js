////listener on customerId dropdown creates an instance of active customer class based on dropdown value
$(document).ready(function () {
    console.log('ready')
    $("#CustomerId").on("change", function (e) {
        console.log('CustomerId clicked')
        $.ajax({
            url: `/Customers/Activate/${$(this).val()}`,
            method: "POST",
            dataType: "json",
            contentType: "application/json; charset=utf-8"
        }).done(() => {
            location.reload();
            console.log('hi')
        });
    });

    //listener on Add to Cart button that posts the product selected to the customer's order
    $("#AddToCart").on("click", function(e) {
        console.log('AddtoCart clicked')
        $.ajax({
            url: `/Products/AddToCart/${$(this).val()}`,
            method: "POST",
            contentType: 'application/json; charset=utf-8'
        }).done(() => {
            console.log('product added to cart');
            location.reload();
        });
    });

    $("#Confirm").on("click", function(e) {
        console.log('AddtoCart clicked')
        $.ajax({
            url: `/Order/Confirm`,
            method: "PATCH",
            dataType: "json",
            contentType: 'application/json; charset=utf-8'
        }).done(() => {
            console.log();
            window.location.replace("http://localhost:5000/Order/Confirmation"); 
        });
    });
    //listener on product type dropdown that injects corresponding subcategories into product type subcategory dropdown
    $("#Product_ProductTypeId").on("change", function (e) {
        $.ajax({
            url: `/Products/GetSubCategories/${$(this).val()}`,
            method: "POST",
            dataType: "json",
            contentType: 'application/json; charset=utf-8'
        }).done((subTypes) => {
            $("#Product_ProductTypeSubCategoryId").html("");
            $("#Product_ProductTypeSubCategoryId").append("<option value=null> Choose a Sub Category </option>");
            subTypes.forEach((option) => {
                console.log("these are the options", option);
                $("#Product_ProductTypeSubCategoryId").append(`<option value="${option.productTypeSubCategoryId}">${option.name}</option>`)
            });
        });
    });


    //conditional that checks whether Payment type dropdown menu on order view registers placeholder text prompting user to select a payment type; if so, order button is disabled
    if ($("#Payment_PaymentTypeId").val() == 0) {
        $("#checkoutButton").prop("disabled", true);
    }
    else {
        $("#checkoutButton").removeAttr("disabled");
    }
    $("#Payment_PaymentTypeId").on("change",function(){
        if ($("#Payment_PaymentTypeId").val() > 0) {
            $("#Confirm").removeAttr("disabled");
        } 
        else if ($("#Payment_PaymentTypeId").val() == 0)
        {
            $("#Confirm").prop("disabled", true);
        }
    })
}); 
