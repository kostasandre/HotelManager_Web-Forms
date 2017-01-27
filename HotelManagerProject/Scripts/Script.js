$(document)
    .ready(function () {
        var hotelInfo = sessionStorage.getItem("Hotel");
        replaceCssClass(hotelInfo);
        $(".collapse")
            .on("shown.bs.collapse",
                function(e) {
                    $(".collapse").not(this).removeClass("in");
                    
                });
        $("[data-toggle=collapse]")
            .click(function(e) {
                $("[data-toggle=collapse]").parent("li").removeClass("active");
                $(this).parent("li").toggleClass("active");
            });

    });

function replaceCssClass(hotelInfo) {
    if (hotelInfo == null) {
        return;
    } else {
        $('#hotelLabel').removeClass("hidden");
        $('#hotelLabel').text("Hotel: " +hotelInfo);
        $('#a1').removeClass("hidden");
        $('#a2').removeClass("hidden");
        $('#a3').removeClass("hidden");
        $('#a4').removeClass("hidden");
        $('#a5').removeClass("hidden");
        
       
    }
}