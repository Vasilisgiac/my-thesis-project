<%@ Page Async="true" Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication2.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    
    <script src="fontfaceobserver.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/webfont/1.6.26/webfont.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Lora" type="text/css" />
    <link href="website.css" rel="stylesheet" type="text/css"/>
    
    
    
    
    <meta name="viewport" content="width=device-width"/>
    <title>Digital Marketing</title>
    

</head>
<body>
    <form id="form1" runat="server">
    <div id="header">
        <a>Update Your E-shop Content</a>
        <hr id="hr1" />
        <hr id="hr2" />
        <hr id="hr3" />
    </div>
    <section id="url">
        Insert your url here
        <input type="text" id="url2" runat="server"/>
    </section>
    <section id="container">
        <div>
    <section id="sectab">
        <a href="#sectab"><div class="tabs" id="sales"><div class="h1" id="sales2">Sales</div></div></a>
        <a href="#sectab"><div class="tabs" id="price"><div class="h1" id="price2">Price</div></div></a>
        <a href="#sectab"><div class="tabs" id="days"><div class="h1" id="days2">Days</div></div></a>
    </section>
    <section id="sectab2">
        <a href="#sectab2"><div class="tabs" id="salesnprice"><div class="h1" id="salesnprice2">Sales & Price</div></div></a>
        <a href="#sectab2"><div class="tabs" id="pricendays"><div class="h1" id="pricendays2">Price & Days</div></div></a>
        <a href="#sectab2"><div class="tabs" id="daysnsales"><div class="h1" id="daysnsales2">Days & Sales</div></div></a>
    </section>
        </div>
    </section>
        <a> 
            <div id="more" onclick="moreoptions()">more options</div>
            <div id="less" onclick="lessoptions()">less options</div>

        </a>
    <asp:TextBox ID="description1" CssClass="description" runat="server" ReadOnly="True"></asp:TextBox>
    <input id="txt" runat="server" class="txt" type="text"/>
     <asp:TextBox ID="description2" CssClass="description" runat="server" ReadOnly="True"></asp:TextBox>
    <input id="txt2" runat="server" class="txt" type="text"/>
    <asp:Button ID="button" CssClass="button" runat="server" Text="Save" OnClick="SaveBtn_Click" />
        <canvas id="myCanvas" width="0" height="0"></canvas><img crossorigin="anonymous" src=" " class="web-main-img" alt="image for canvas" title="image for canvas" border="0" id="web-main-img"/>
        <input type="text" class="txt imagesource" readonly="readonly" id="imagesource" runat="server"/>
        <a id="redirect" href="#redirect" runat="server" ><input id="create" type="button" onclick="createCanvas(this)" value="Create Canvas" class="button"/></a>
        <label id="facebookpage" class="description" runat="server">Facebook Page</label>
        <input type="text" class="txt" id="pagename" runat="server"/>
        <label id="facebookmessage" class="description" runat="server">Message</label>
        <textarea id="message" class="txt" runat="server"></textarea>
        <input id="upload" type="button" onclick="fileupload(this)" value="Upload file" class="button"/>
    
    
    <asp:Button ID="button2" CssClass="hidden" runat="server" OnClick="SalesBtn_Click" />
    <asp:Button ID="button1" CssClass="hidden" runat="server" OnClick="PriceBtn_Click"/>
    <asp:Button ID="button3" CssClass="hidden" runat="server" OnClick="DaysBtn_Click"/>
    <asp:Button ID="button4" CssClass="hidden" runat="server" OnClick="SalesPriceBtn_Click" />
    <asp:Button ID="button5" CssClass="hidden" runat="server" OnClick="PriceDaysBtn_Click"/>
    <asp:Button ID="button6" CssClass="hidden" runat="server" OnClick="DaysSalesBtn_Click"/>
        
<script type = "text/javascript">
    
    //function redirect() {
    //   sessionStorage.scroll = document.getElementById("redirect").offsetTop;
    //}

    function createCanvas(input) {
        //document.getElementById("web-main-img").src = document.getElementById("imagesource").value;
        
        document.getElementById("web-main-img").src = "https://i.imgur.com/mVoU6C4l.jpg";
        document.getElementById("web-main-img").onload = function () {
        document.getElementById("web-main-img").style.display = " block ";
        document.getElementById("myCanvas").width = document.getElementById("web-main-img").width;
        document.getElementById("myCanvas").height = document.getElementById("web-main-img").height;
        
        var canvas = document.getElementById("myCanvas");
        var ctx = canvas.getContext("2d");
        var text = document.getElementById("txt").value;
        var width = document.getElementById("myCanvas").width;
        var height = document.getElementById("myCanvas").height;
        ctx.drawImage(document.getElementById("web-main-img"), 1, 1);
        ctx.font = "bold 500pt Tahoma";
        var diagonal = Math.sqrt(2 * Math.pow((parseInt(ctx.font.match(/\d+/), 10)), 2));
        var diagonal2 = Math.sqrt(Math.pow(width, 2) + Math.pow(height, 2));
        var smaller;
        var dif;

        if (width > height) { smaller = height }
        else if (width <= height) { smaller = width; }

        function isOverflown() {
            dif = smaller - (diagonal / 2);
            if (dif < 0) { dif = smaller / 2; }
            return ctx.measureText(text).width >= Math.sqrt(2 * Math.pow(dif, 2));
        }
        let fontSize = parseInt(ctx.font.match(/\d+/), 10);
        for (let i = fontSize; i >= 0; i--) {

            let overflow = isOverflown();
            if (overflow) {
                fontSize--;
                ctx.font = "bold " + fontSize + "px Tahoma";
                diagonal = Math.sqrt(2 * Math.pow((parseInt(ctx.font.match(/\d+/), 10)), 2));
            }

        }
        ctx.fillStyle = 'red';
        ctx.translate((document.getElementById("myCanvas").width) / 2, (document.getElementById("myCanvas").height) / 2 + (parseInt(ctx.font.match(/\d+/), 10) / 2));
        ctx.rotate(-45 * Math.PI / 180);
        ctx.translate((parseInt(ctx.font.match(/\d+/), 10) / 3), 0);
        ctx.textAlign = "center";
        ctx.fillText(text, 0, 0);
        document.getElementById("web-main-img").style.display = " none ";
        document.getElementById("upload").style.visibility = "visible";
        document.getElementById("txt").value = "";
        document.getElementById("txt2").value = "";
        input.blur();
     }
    }

    

    

    
    
    
    
    var FBLoginScope = 'publish_pages, manage_pages, pages_show_list'; 
    

    window.fbAsyncInit = function () {
        FB.init({
            appId: '312200576041249',
            cookie: true,
            xfbml: true,
            version: 'v3.2'
        });

        FB.AppEvents.logPageView();


        //FB.getLoginStatus(function (response) {
        //  this.statusChangeCallback(response);
        //}.bind(this));
    }.bind(this);




    (function (d, s, id) {
        var js, fjs = d.getElementsByTagName(s)[0];
        if (d.getElementById(id)) { return; }
        js = d.createElement(s); js.id = id;
        js.src = "https://connect.facebook.net/en_US/sdk.js";
        fjs.parentNode.insertBefore(js, fjs);
    }(document, 'script', 'facebook-jssdk'));

    function fileupload(input) {
        
        FB.getLoginStatus(function (response) {
            console.log(response.status);
            FB.login(function (response) {
                FB.api('/me/accounts', 'get', { access_token: response.authResponse.accessToken }, function (response) {
                    console.log(response); // this is returning an object with the accounts


                    var pageName = document.getElementById("pagename").value;
                    var pageAccessToken = '';
                    var pageId = '';
                    for (i in response.data) {
                        if (response.data[i].name == pageName) {
                            pageAccessToken = response.data[i].access_token;
                            pageId = response.data[i].id;
                            //console.log(pageAccessToken);
                        }
                    }
                    if (document.getElementById("pagename").value == "") {
                        alert("Please insert the name of your facebook page and press again the button");
                    }
                    else if (pageAccessToken == '') {
                        alert("Please insert an existing facebook page of yours and press again the button");
                    }
                    else {
                        postImageToFacebook(pageAccessToken, pageId);
                        document.getElementById("create").style.visibility = "hidden";
                        document.getElementById("facebookpage").style.visibility = "hidden";
                        document.getElementById("pagename").style.visibility = "hidden";
                        document.getElementById("facebookmessage").style.visibility = "hidden";
                        document.getElementById("message").style.visibility = "hidden";
                        document.getElementById("upload").style.visibility = "hidden";
                    }
                });

            }, { scope: FBLoginScope });
        });
        input.blur();
    }



    function postImageToFacebook(token, pageid) {
        var dataURI = document.getElementById("myCanvas").toDataURL("image/jpeg", 1.0);
        var byteString = atob(dataURI.split(',')[1]);
        var ab = new ArrayBuffer(byteString.length);
        var ia = new Uint8Array(ab);
        for (var i = 0; i < byteString.length; i++) {
            ia[i] = byteString.charCodeAt(i);
        }
        var blob = new Blob([ab], { type: 'image/jpeg' });
        var messageWall = document.getElementById("message").value;
        var pageName = document.getElementById("pagename").value;
        var formdata = new FormData();
        formdata.append("access_token", token);
        formdata.append("message", messageWall);
        formdata.append("source", blob);
        
        $.ajax({
            type: 'POST',
            url: 'https://graph.facebook.com/'+ pageid +'/photos',
            data: formdata,
            processData: false,
            contentType: false,
            cache: false,
            success: function (data) {
                console.log('success');
                console.log(data);
            },
            error: function (shr, status, data) {
                console.log('error');
                console.log(data);
            },
            complete: function (data) {
                console.log('Completed');
                console.log(data);
            }
        });
    }


            document.getElementsByClassName("tabs")[0].onmouseover = function () {
                document.getElementsByClassName("h1")[0].style.transform = 'rotate(-45deg) translateY(40%) translateX(-10%)';
                document.getElementsByClassName("h1")[0].style.webkitTransform = 'rotate(-45deg) translateY(40%) translateX(-10%)';
                document.getElementsByClassName("h1")[0].style.mozTransform = 'rotate(-45deg) translateY(40%) translateX(-10%)';
                document.getElementsByClassName("h1")[0].style.msTransform = 'rotate(-45deg) translateY(40%) translateX(-10%)';
                document.getElementsByClassName("h1")[0].style.oTransform = 'rotate(-45deg) translateY(40%) translateX(-10%)';
                
                    
            };

            document.getElementsByClassName("tabs")[0].onmouseout = function () {
                document.getElementsByClassName("h1")[0].style.transform = 'rotate(0deg) translateY(50%)';
                document.getElementsByClassName("h1")[0].style.webkitTransform = 'rotate(0deg) translateY(50%)';
                document.getElementsByClassName("h1")[0].style.mozTransform = 'rotate(0deg) translateY(50%)';
                document.getElementsByClassName("h1")[0].style.msTransform = 'rotate(0deg) translateY(50%)';
                document.getElementsByClassName("h1")[0].style.oTransform = 'rotate(0deg) translateY(50%)';
                
            };

            document.getElementsByClassName("tabs")[1].onmouseover = function () {
                document.getElementsByClassName("h1")[1].style.transform = 'rotate(-45deg) translateY(40%) translateX(-10%)';
                document.getElementsByClassName("h1")[1].style.webkitTransform = 'rotate(-45deg) translateY(40%) translateX(-10%)';
                document.getElementsByClassName("h1")[1].style.mozTransform = 'rotate(-45deg) translateY(40%) translateX(-10%)';
                document.getElementsByClassName("h1")[1].style.msTransform = 'rotate(-45deg) translateY(40%) translateX(-10%)';
                document.getElementsByClassName("h1")[1].style.oTransform = 'rotate(-45deg) translateY(40%) translateX(-10%)';
                
            };

            document.getElementsByClassName("tabs")[1].onmouseout = function () {
                document.getElementsByClassName("h1")[1].style.transform = 'rotate(0deg) translateY(50%)';
                document.getElementsByClassName("h1")[1].style.webkitTransform = 'rotate(0deg) translateY(50%)';
                document.getElementsByClassName("h1")[1].style.mozTransform = 'rotate(0deg) translateY(50%)';
                document.getElementsByClassName("h1")[1].style.msTransform = 'rotate(0deg) translateY(50%)';
                document.getElementsByClassName("h1")[1].style.oTransform = 'rotate(0deg) translateY(50%)';
            };

            document.getElementsByClassName("tabs")[2].onmouseover = function () {
                document.getElementsByClassName("h1")[2].style.transform = 'rotate(-45deg) translateY(40%) translateX(-10%)';
                document.getElementsByClassName("h1")[2].style.webkitTransform = 'rotate(-45deg) translateY(40%) translateX(-10%)';
                document.getElementsByClassName("h1")[2].style.mozTransform = 'rotate(-45deg) translateY(40%) translateX(-10%)';
                document.getElementsByClassName("h1")[2].style.msTransform = 'rotate(-45deg) translateY(40%) translateX(-10%)';
                document.getElementsByClassName("h1")[2].style.oTransform = 'rotate(-45deg) translateY(40%) translateX(-10%)';
                
            };

            document.getElementsByClassName("tabs")[2].onmouseout = function () {
                document.getElementsByClassName("h1")[2].style.transform = 'rotate(0deg) translateY(50%)';
                document.getElementsByClassName("h1")[2].style.webkitTransform = 'rotate(0deg) translateY(50%)';
                document.getElementsByClassName("h1")[2].style.mozTransform = 'rotate(0deg) translateY(50%)';
                document.getElementsByClassName("h1")[2].style.msTransform = 'rotate(0deg) translateY(50%)';
                document.getElementsByClassName("h1")[2].style.oTransform = 'rotate(0deg) translateY(50%)';
            };

            document.getElementsByClassName("tabs")[3].onmouseover = function () {
                document.getElementsByClassName("h1")[3].style.transform = 'rotate(-25deg) translateY(55%) translateX(-5%)';
                document.getElementsByClassName("h1")[3].style.webkitTransform = 'rotate(-25deg) translateY(55%) translateX(-5%)';
                document.getElementsByClassName("h1")[3].style.mozTransform = 'rotate(-25deg) translateY(55%) translateX(-5%)';
                document.getElementsByClassName("h1")[3].style.msTransform = 'rotate(-25deg) translateY(55%) translateX(-5%)';
                document.getElementsByClassName("h1")[3].style.oTransform = 'rotate(-25deg) translateY(55%) translateX(-5%)';


            };

            document.getElementsByClassName("tabs")[3].onmouseout = function () {
                document.getElementsByClassName("h1")[3].style.transform = 'rotate(0deg) translateY(50%)';
                document.getElementsByClassName("h1")[3].style.webkitTransform = 'rotate(0deg) translateY(50%)';
                document.getElementsByClassName("h1")[3].style.mozTransform = 'rotate(0deg) translateY(50%)';
                document.getElementsByClassName("h1")[3].style.msTransform = 'rotate(0deg) translateY(50%)';
                document.getElementsByClassName("h1")[3].style.oTransform = 'rotate(0deg) translateY(50%)';

            };

            document.getElementsByClassName("tabs")[4].onmouseover = function () {
                document.getElementsByClassName("h1")[4].style.transform = 'rotate(-25deg) translateY(55%) translateX(-5%)';
                document.getElementsByClassName("h1")[4].style.webkitTransform = 'rotate(-25deg) translateY(55%) translateX(-5%)';
                document.getElementsByClassName("h1")[4].style.mozTransform = 'rotate(-25deg) translateY(55%) translateX(-5%)';
                document.getElementsByClassName("h1")[4].style.msTransform = 'rotate(-25deg) translateY(55%) translateX(-5%)';
                document.getElementsByClassName("h1")[4].style.oTransform = 'rotate(-25deg) translateY(55%) translateX(-5%)';


            };

            document.getElementsByClassName("tabs")[4].onmouseout = function () {
                document.getElementsByClassName("h1")[4].style.transform = 'rotate(0deg) translateY(50%)';
                document.getElementsByClassName("h1")[4].style.webkitTransform = 'rotate(0deg) translateY(50%)';
                document.getElementsByClassName("h1")[4].style.mozTransform = 'rotate(0deg) translateY(50%)';
                document.getElementsByClassName("h1")[4].style.msTransform = 'rotate(0deg) translateY(50%)';
                document.getElementsByClassName("h1")[4].style.oTransform = 'rotate(0deg) translateY(50%)';

            };

            document.getElementsByClassName("tabs")[5].onmouseover = function () {
                document.getElementsByClassName("h1")[5].style.transform = 'rotate(-25deg) translateY(55%) translateX(-5%)';
                document.getElementsByClassName("h1")[5].style.webkitTransform = 'rotate(-25deg) translateY(55%) translateX(-5%)';
                document.getElementsByClassName("h1")[5].style.mozTransform = 'rotate(-25deg) translateY(55%) translateX(-5%)';
                document.getElementsByClassName("h1")[5].style.msTransform = 'rotate(-25deg) translateY(55%) translateX(-5%)';
                document.getElementsByClassName("h1")[5].style.oTransform = 'rotate(-25deg) translateY(55%) translateX(-5%)';


            };

            document.getElementsByClassName("tabs")[5].onmouseout = function () {
                document.getElementsByClassName("h1")[5].style.transform = 'rotate(0deg) translateY(50%)';
                document.getElementsByClassName("h1")[5].style.webkitTransform = 'rotate(0deg) translateY(50%)';
                document.getElementsByClassName("h1")[5].style.mozTransform = 'rotate(0deg) translateY(50%)';
                document.getElementsByClassName("h1")[5].style.msTransform = 'rotate(0deg) translateY(50%)';
                document.getElementsByClassName("h1")[5].style.oTransform = 'rotate(0deg) translateY(50%)';

            };

            document.getElementsByClassName("tabs")[0].onclick = function () {
                var btnHidden = document.getElementById('button2');
                if (btnHidden != null) {
                    btnHidden.click();
                    
                }
            };

            document.getElementsByClassName("h1")[0].onclick = function () {
                var btnHidden = document.getElementById('button2');
                if (btnHidden != null) {
                    btnHidden.click();
                    
                }
            };

            document.getElementsByClassName("tabs")[1].onclick = function () {
                var btnHidden = document.getElementById('button1');
                if (btnHidden != null) {
                    btnHidden.click();
                }
            };

            document.getElementsByClassName("h1")[1].onclick = function () {
                var btnHidden = document.getElementById('button1');
                if (btnHidden != null) {
                    btnHidden.click();
                }
            };

            document.getElementsByClassName("tabs")[2].onclick = function () {
                var btnHidden = document.getElementById('button3');
                if (btnHidden != null) {
                    btnHidden.click();
                }
            };

            document.getElementsByClassName("h1")[2].onclick = function () {
                var btnHidden = document.getElementById('button3');
                if (btnHidden != null) {
                    btnHidden.click();
                }
            };

            document.getElementsByClassName("tabs")[3].onclick = function () {
                var btnHidden = document.getElementById('button4');
                if (btnHidden != null) {
                    btnHidden.click();
                }
            };

            document.getElementsByClassName("h1")[3].onclick = function () {
                var btnHidden = document.getElementById('button4');
                if (btnHidden != null) {
                    btnHidden.click();
                }
            };

            document.getElementsByClassName("tabs")[4].onclick = function () {
                var btnHidden = document.getElementById('button5');
                if (btnHidden != null) {
                    btnHidden.click();
                }
            };

            document.getElementsByClassName("h1")[4].onclick = function () {
                var btnHidden = document.getElementById('button5');
                if (btnHidden != null) {
                    btnHidden.click();
                }
            };

            document.getElementsByClassName("tabs")[5].onclick = function () {
                var btnHidden = document.getElementById('button6');
                if (btnHidden != null) {
                    btnHidden.click();
                }
            };

            document.getElementsByClassName("h1")[5].onclick = function () {
                var btnHidden = document.getElementById('button6');
                if (btnHidden != null) {
                    btnHidden.click();
                }
            };

            

            var scrollY;
            var fontsloaded = 0;
            var more = 0;
            if (sessionStorage.more) { more = sessionStorage.more; }
            window.onload = function () {
                document.documentElement.style.display = "block";
                if (document.getElementById("imagesource").value != "") {
                    document.getElementById("create").style.visibility = "visible";
                }
                if (sessionStorage.scroll) {
                    
                    document.documentElement.style.visibility = "hidden";
                    scrollY = sessionStorage.scroll;
                    window.scrollTo(0, scrollY);
                    document.documentElement.style.visibility = "visible";
                }

                

                var fontA = new FontFaceObserver('Lora');
                var fontB = new FontFaceObserver('Gothicb');

                Promise.all([fontA.load(), fontB.load()]).then(function () {
                    document.documentElement.style.visibility = "visible";
                    fontsloaded = 1;
            });

                
                
                
                //alert(fontsloaded);
                if (sessionStorage.more == 1) {
                    document.getElementById("sectab2").style.zIndex = "100";
                    document.getElementById("sectab").style.zIndex = "-1";
                    document.getElementById("sectab2").style.visibility = "visible";
                    document.getElementById("sectab").style.visibility = "hidden";
                    document.getElementById("less").style.visibility = "visible";
                    document.getElementById("more").style.visibility = "hidden";
                }

                
            };

            window.onscroll = function () {

                if (fontsloaded == 0) {
                    window.scrollTo(0, scrollY);
                    //alert(scrollY);
                }
                else {
                    scrollY = window.pageYOffset;
                    if (isNaN(window.pageYOffset)) { scrollY = 0; }
                    //alert("else");
                    //alert(fontsloaded);


                    if (scrollY > 0) {

                        sessionStorage.scroll = scrollY;
                        //alert(scrollY);

                    }

                }
                //alert(scrollY);
                //alert(fontsloaded);
                //alert(sessionStorage.scroll);
                
            };

            function moreoptions() {
                document.getElementById("sectab2").style.zIndex = "100";
                document.getElementById("sectab").style.zIndex = "-1";
                document.getElementById("sectab2").style.visibility = "visible";
                document.getElementById("sectab").style.visibility = "hidden";
                document.getElementById("less").style.visibility = "visible";
                document.getElementById("more").style.visibility = "hidden";
                more = 1;
                sessionStorage.more = more;
            }

            function lessoptions() {
                document.getElementById("sectab").style.zIndex = "100";
                document.getElementById("sectab2").style.zIndex = "-1";
                document.getElementById("sectab").style.visibility = "visible";
                document.getElementById("sectab2").style.visibility = "hidden";
                document.getElementById("more").style.visibility = "visible";
                document.getElementById("less").style.visibility = "hidden";
                more = 0;
                sessionStorage.more = more;
            }
            
</script>
    </form>
   
</body>
</html>

