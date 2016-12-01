$(document).ready(function () {
    LOS.init();
});

var LOS = LOS || function () {
    var init = function () {
        LOS.util.init();
        LOS.setHeadElement.init();
        LOS.calculateGodwinAge.init();
        //LOS.changeMe.init();
    };
    return {
        init: init
    };
}();


LOS.util = function(){

    function init() {
        ie10ViewportFix();
        fastClick();
    }

    function ie10ViewportFix() {
        if (navigator.userAgent.match(/IEMobile\/10\.0/)) {
            var msViewportStyle = document.createElement('style');
            msViewportStyle.appendChild(
                document.createTextNode(
                    '@-ms-viewport{width:auto!important}'
                )
            );
            document.querySelector('head').appendChild(msViewportStyle)
        }
    }

    function fastClick(){
        FastClick.attach(document.body);
    }

    return {
        init: init
    }
}();

LOS.setHeadElement = function () {

    var h1Ele;

    function init() {
        h1Ele = $('h1');

        //don't go further if there is no container
        if (!h1Ele.length) { return }

        privateFunc();

        var GodwinInput = $("#GodwinInput");
        var result = LOS.calculateGodwinAge.calculator(GodwinInput.val());
        $(".result").html(result);

        GodwinInput.on('blur', function () {
            var newAge = $(this).val();
            var result2 = LOS.calculateGodwinAge.calculator(newAge);
            $(".result").html(result2);
        });
    }

    function privateFunc() {
        h1Ele.html("Today!");
    }

    // public function to be called like LOS.changeMe.publicFunc();
    function publicFunc() {
        console.log('public');
    }

    return {
        init: init,
        publicFunc: publicFunc
    }
}();

LOS.calculateGodwinAge = function () {

    var GodwinInput, result;

    function initialize() {
        GodwinInput = $("#GodwinInput");
        result = $(".result");
    }
    function init() {


        initialize();

        //don't go further if there is no container
        if (!GodwinInput.length && !result.length) { return }


        var age = GodwinInput.val();
        //
        var res = calculator(age);

        GodwinInput.on('blur', function () {
            var newAge = $(this).val();
            var res = calculator(newAge);
        });
    }

    function calculator(age) {

        if (age > 25) {
            return "Okuzze!";
        } else {
            return "Okadiye!";
        }
    }

    // public function to be called like LOS.changeMe.publicFunc();
    function publicFunc(age) {
       
        calculator(age);

    }

    return {
        init: init,
        calculator: calculator
    }
}();

/***************************
* Template for new modules
****************************
LOS.changeMe = function(){

    var elem1;

    function init() {
        elem1 = $('#elem1');

        //don't go further if there is no container
        if(!elem1.length){return}

        privateFunc();
    }

    function privateFunc() {
        console.log('private')
    }

    // public function to be called like LOS.changeMe.publicFunc();
    function publicFunc() {
        console.log('public')
    }

    return {
        init: init,
        publicFunc: publicFunc
    }
}();
 */





