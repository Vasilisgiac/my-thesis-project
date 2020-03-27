using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using System.Net.Http;
using System.Text;
using System.Dynamic;

namespace WebApplication2
{
    
    public partial class WebForm1 : System.Web.UI.Page
    {

        public bool Sales { get; set; }
        public bool Price { get; set; }
        public bool Days { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!Page.IsPostBack)
            {
                
                Sales = false;
                Price = false;
                Days = false;
            }
            else
            {
                if (Session["Sales"] != null )
                {
                    Sales = (bool)Session["Sales"];
                    
                }

                if (Session["Price"] != null)
                {
                    Price = (bool)Session["Price"];

                }

                if (Session["Days"] != null )
                {
                    Days = (bool)Session["Days"];

                }
            }
        }

        protected void SalesBtn_Click(object sender, EventArgs e) 
        {
            
            
            Sales = true;
            Price = false;
            Days = false;
            description1.Text = "Type the text, which will be added on the image of product";
            txt.Attributes.Add("style", "visibility:visible");
            description1.Attributes.Add("style", "visibility:visible");
            button.Attributes.Add("style", "visibility:visible");
            txt2.Attributes.Add("style", "visibility:hidden");
            description2.Attributes.Add("style", "visibility:hidden");
            txt.Value = "";
            txt2.Value = "";
            Session["Sales"] = Sales;
            Session["Price"] = Price;
            Session["Days"] = Days;
        }

        protected void PriceBtn_Click(object sender, EventArgs e)
        {
            Price = true;
            Sales = false;
            Days = false;
            description1.Text = "Type the price of product, which will be edited";
            txt.Attributes.Add("style", "visibility:visible");
            description1.Attributes.Add("style", "visibility:visible");
            button.Attributes.Add("style", "visibility:visible");
            txt2.Attributes.Add("style", "visibility:hidden");
            description2.Attributes.Add("style", "visibility:hidden");
            txt.Value = "";
            txt2.Value = "";
            Session["Sales"] = Sales;
            Session["Price"] = Price;
            Session["Days"] = Days;
        }

        protected void DaysBtn_Click(object sender, EventArgs e)
        {
            Days = true;
            Price = false;
            Sales = false;
            description1.Text = "Type the amount of days, which you desire";
            txt.Attributes.Add("style", "visibility:visible");
            description1.Attributes.Add("style", "visibility:visible");
            button.Attributes.Add("style", "visibility:visible");
            txt2.Attributes.Add("style", "visibility:hidden");
            description2.Attributes.Add("style", "visibility:hidden");
            txt.Value = "";
            txt2.Value = "";
            Session["Sales"] = Sales;
            Session["Price"] = Price;
            Session["Days"] = Days;
        }

        protected void SalesPriceBtn_Click(object sender, EventArgs e)
        {


            Sales = true;
            Price = true;
            Days = false;
            description1.Text = "Type the text, which will be added on the image of product";
            txt.Attributes.Add("style", "visibility:visible");
            description1.Attributes.Add("style", "visibility:visible");
            description2.Text = "Type the price of product, which will be edited";
            txt2.Attributes.Add("style", "visibility:visible");
            description2.Attributes.Add("style", "visibility:visible");
            button.Attributes.Add("style", "visibility:visible");
            txt.Value = "";
            txt2.Value = "";
            Session["Sales"] = Sales;
            Session["Price"] = Price;
            Session["Days"] = Days;
        }

        protected void PriceDaysBtn_Click(object sender, EventArgs e)
        {
            Price = true;
            Sales = false;
            Days = true;
            description1.Text = "Type the price of product, which will be edited";
            txt.Attributes.Add("style", "visibility:visible");
            description1.Attributes.Add("style", "visibility:visible");
            description2.Text = "Type the amount of days, which you desire";
            txt2.Attributes.Add("style", "visibility:visible");
            description2.Attributes.Add("style", "visibility:visible");
            button.Attributes.Add("style", "visibility:visible");
            txt.Value = "";
            txt2.Value = "";
            Session["Sales"] = Sales;
            Session["Price"] = Price;
            Session["Days"] = Days;
        }

        protected void DaysSalesBtn_Click(object sender, EventArgs e)
        {
            Days = true;
            Price = false;
            Sales = true;
            description1.Text = "Type the text, which will be added on the image of product";
            txt.Attributes.Add("style", "visibility:visible");
            description1.Attributes.Add("style", "visibility:visible");
            description2.Text = "Type the amount of days, which you desire";
            txt2.Attributes.Add("style", "visibility:visible");
            description2.Attributes.Add("style", "visibility:visible");
            button.Attributes.Add("style", "visibility:visible");
            txt.Value = "";
            txt2.Value = "";
            Session["Sales"] = Sales;
            Session["Price"] = Price;
            Session["Days"] = Days;
        }

        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            Uri uriResult;
            bool url = Uri.TryCreate(url2.Value, UriKind.Absolute, out uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
            if (url == false)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Your link is incorrect')", true);
            }
            else{
                if ((Sales == true) && (Price == false) && (Days == false) && (Regex.IsMatch(txt.Value, @"^[a-zA-Z\s]+$") == false)) 
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Only letters are permitted')", true);
                }
                else if ((Price == true) && (Sales == false) && (Days == false) && (Regex.IsMatch(txt.Value, @"^[0-9]+(\.[0-9]{2})$") == false))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Only numbers are permitted in *.00 form')", true);
                }
                else if ((Days == true) && (Sales == false) && (Price == false) && (Regex.IsMatch(txt.Value, @"^\d+$") == false))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Only numbers are permitted ')", true);
                }
                else if ((Sales == true) && (Price == true) && ((Regex.IsMatch(txt.Value, @"^[a-zA-Z\s]+$") == false) || (Regex.IsMatch(txt2.Value, @"^[0-9]+(\.[0-9]{2})$") == false)))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Only letters are permitted for first input and only numbers in *.00 form for the second one')", true);
                }
                else if ((Price == true) && (Days == true) && ((Regex.IsMatch(txt.Value, @"^[0-9]+(\.[0-9]{2})$") == false) || (Regex.IsMatch(txt2.Value, @"^\d+$") == false)))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Only numbers are permitted in *.00 form for first input and simple numbers for the second one')", true);
                }
                else if ((Days == true) && (Sales == true) && ((Regex.IsMatch(txt.Value, @"^[a-zA-Z\s]+$") == false) || (Regex.IsMatch(txt2.Value, @"^\d+$") == false)))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Only numbers are permitted for first input and only letters for the second one')", true);
                }
                else{
                string remoteUri = url2.Value;
                string fileName = HttpRuntime.AppDomainAppPath + "myfile2.html";
                WebClient myWebClient = new WebClient();
                myWebClient.UseDefaultCredentials = true;
                myWebClient.DownloadFile(remoteUri, fileName);
                HtmlWeb h = new HtmlWeb();
                HtmlDocument doc = new HtmlDocument();
                HtmlAgilityPack.HtmlNode.ElementsFlags["br"] = HtmlElementFlag.Empty;
                doc.OptionWriteEmptyNodes = true;
                doc.OptionCheckSyntax = false;
                doc.OptionFixNestedTags = false;
                doc.OptionAutoCloseOnEnd = false;
                if (!HtmlNode.ElementsFlags.ContainsKey("table"))
                    HtmlNode.ElementsFlags.Add("table", HtmlElementFlag.CanOverlap | HtmlElementFlag.Empty);
                else
                    HtmlNode.ElementsFlags["table"] = HtmlElementFlag.CanOverlap | HtmlElementFlag.Empty;

                if (!HtmlNode.ElementsFlags.ContainsKey("td"))
                    HtmlNode.ElementsFlags.Add("td", HtmlElementFlag.CanOverlap | HtmlElementFlag.Empty);
                else
                    HtmlNode.ElementsFlags["td"] = HtmlElementFlag.CanOverlap | HtmlElementFlag.Empty;

                if (!HtmlNode.ElementsFlags.ContainsKey("tr"))
                    HtmlNode.ElementsFlags.Add("tr", HtmlElementFlag.CanOverlap | HtmlElementFlag.Empty);
                else
                    HtmlNode.ElementsFlags["tr"] = HtmlElementFlag.CanOverlap | HtmlElementFlag.Empty;

                if (!HtmlNode.ElementsFlags.ContainsKey("li"))
                    HtmlNode.ElementsFlags.Add("li", HtmlElementFlag.CanOverlap | HtmlElementFlag.Empty);
                else
                    HtmlNode.ElementsFlags["li"] = HtmlElementFlag.CanOverlap | HtmlElementFlag.Empty;

                if (!HtmlNode.ElementsFlags.ContainsKey("ul"))
                    HtmlNode.ElementsFlags.Add("ul", HtmlElementFlag.CanOverlap | HtmlElementFlag.Empty);
                else
                    HtmlNode.ElementsFlags["ul"] = HtmlElementFlag.CanOverlap | HtmlElementFlag.Empty;

                if (!HtmlNode.ElementsFlags.ContainsKey("a"))
                    HtmlNode.ElementsFlags.Add("a", HtmlElementFlag.CanOverlap | HtmlElementFlag.Empty);
                else
                    HtmlNode.ElementsFlags["a"] = HtmlElementFlag.CanOverlap | HtmlElementFlag.Empty;

                if (!HtmlNode.ElementsFlags.ContainsKey("img"))
                    HtmlNode.ElementsFlags.Add("img", HtmlElementFlag.CanOverlap | HtmlElementFlag.Empty);
                else
                    HtmlNode.ElementsFlags["img"] = HtmlElementFlag.CanOverlap | HtmlElementFlag.Empty;

                if (!HtmlNode.ElementsFlags.ContainsKey("p"))
                    HtmlNode.ElementsFlags.Add("p", HtmlElementFlag.CanOverlap | HtmlElementFlag.Empty);
                else
                    HtmlNode.ElementsFlags["p"] = HtmlElementFlag.CanOverlap | HtmlElementFlag.Empty;

                //HtmlNode.ElementsFlags.Add("table", HtmlElementFlag.CanOverlap | HtmlElementFlag.Empty);
                //HtmlNode.ElementsFlags.Add("td", HtmlElementFlag.CanOverlap | HtmlElementFlag.Empty);
                //HtmlNode.ElementsFlags.Add("tr", HtmlElementFlag.CanOverlap | HtmlElementFlag.Empty);
                //HtmlNode.ElementsFlags.Add("li", HtmlElementFlag.CanOverlap | HtmlElementFlag.Empty);
                //HtmlNode.ElementsFlags.Add("ul", HtmlElementFlag.CanOverlap | HtmlElementFlag.Empty);
                doc = h.Load(HttpRuntime.AppDomainAppPath + "myfile2.html");

                if (Price == true && Days == false && Sales == false)
                { 
                    foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//span[@class=\"web-price-value-new\"]"))
                    {
                        node.InnerHtml = txt.Value + "&nbsp;&euro;";
                    }
                }

                if (Days == true && Sales == false && Price == false)
                {
                    foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//span[@class=\"web-price-value-new\"]"))
                    {
                        node.InnerHtml = node.InnerHtml + "&nbsp;για&nbsp;" + txt.Value + "&nbsp;μέρες";
                    }
                }

                if (Sales == true && Price == false && Days == false)
                {
                    HtmlNode node = doc.DocumentNode.SelectNodes("//img[@class=\"web-main-img\"]")[1];
                    
                        //url2.Value = "<canvas id=\"canvas\"></canvas>" + node.OuterHtml;
                        var canvas = "<canvas id=\"myCanvas\"></canvas>";
                        var script = System.Environment.NewLine + "<script>" + System.Environment.NewLine +
                            "document.getElementById(\"web-main-img\").onload = function() {" + System.Environment.NewLine +
                            "document.getElementById(\"myCanvas\").width = document.getElementById(\"web-main-img\").width;" + System.Environment.NewLine +
                            "document.getElementById(\"myCanvas\").height = document.getElementById(\"web-main-img\").height;" + System.Environment.NewLine +
                            "document.getElementById(\"web-main-img\").style.display = \" inline-block \";" + System.Environment.NewLine +
                            "var canvas = document.getElementById(\"myCanvas\");" + System.Environment.NewLine +
                            "var ctx = canvas.getContext(\"2d\");" + System.Environment.NewLine +
                            "var text = \"" + txt.Value + "\";" + System.Environment.NewLine +
                            "var width = document.getElementById(\"myCanvas\").width;" + System.Environment.NewLine +
                            "var height = document.getElementById(\"myCanvas\").height;" + System.Environment.NewLine +
                            "ctx.drawImage(document.getElementById(\"web-main-img\"), 1, 1);" + System.Environment.NewLine +
                            "ctx.font = \"bold 500pt Tahoma\";" + System.Environment.NewLine +
                            "var diagonal = Math.sqrt(2 * Math.pow((parseInt(ctx.font.match(/\\d+/), 10)), 2));" + System.Environment.NewLine +
                            "var diagonal2 = Math.sqrt(Math.pow(width, 2) + Math.pow(height, 2));" + System.Environment.NewLine +
                            "var smaller;" + System.Environment.NewLine +
                            "var dif;" + System.Environment.NewLine +
                            "if (width > height) { smaller = height }" + System.Environment.NewLine +
                            "else if (width <= height) { smaller = width; }" + System.Environment.NewLine +
                            "function isOverflown() { " + System.Environment.NewLine +
                            "dif = smaller - (diagonal / 2);" + System.Environment.NewLine +
                            "if (dif < 0) { dif = smaller / 2; }" + System.Environment.NewLine +
                            "return ctx.measureText(text).width >= Math.sqrt(2 * Math.pow(dif, 2));}" + System.Environment.NewLine +
                            "let fontSize = parseInt(ctx.font.match(/\\d+/), 10);" + System.Environment.NewLine +
                            "for (let i = fontSize; i >= 0; i--) {" + System.Environment.NewLine +
                            "let overflow = isOverflown();" + System.Environment.NewLine +
                            "if (overflow) {" + System.Environment.NewLine +
                            "fontSize--;" + System.Environment.NewLine +
                            "ctx.font = \"bold \" + fontSize + \"px Tahoma\";" + System.Environment.NewLine +
                            "diagonal = Math.sqrt(2 * Math.pow((parseInt(ctx.font.match(/\\d+/), 10)), 2));" + System.Environment.NewLine +
                            "}" + System.Environment.NewLine +
                            "}" + System.Environment.NewLine +
                            "ctx.fillStyle = 'red';" + System.Environment.NewLine +
                            "ctx.translate((document.getElementById(\"myCanvas\").width) / 2, (document.getElementById(\"myCanvas\").height) / 2 + (parseInt(ctx.font.match(/\\d+/), 10) / 2));" + System.Environment.NewLine +
                            "ctx.rotate(-45 * Math.PI / 180);" + System.Environment.NewLine +
                            "ctx.translate((parseInt(ctx.font.match(/\\d+/), 10) / 3 ), 0);" + System.Environment.NewLine +
                            "ctx.textAlign = \"center\";" + System.Environment.NewLine +
                            "ctx.fillText(text, 0, 0);" + System.Environment.NewLine +
                            //"ctx.fillRect(0, 0, 10, 10);" + System.Environment.NewLine +

                            "document.getElementById(\"web-main-img\").style.display = \" none \";" + System.Environment.NewLine +
                            "};" + System.Environment.NewLine +
                            "</script>" + System.Environment.NewLine;
                        node.Attributes.Add("id", "web-main-img");
                        node.PreviousSibling.InnerHtml = canvas + node.OuterHtml + script;
                        
                        
                        var message2 = "";
                        HtmlNode node2;
                        if (doc.DocumentNode.SelectSingleNode("//h1") != null) {
                            node2 = doc.DocumentNode.SelectSingleNode("//h1");
                            message2 = node2.InnerHtml + System.Environment.NewLine + System.Environment.NewLine;
                        }

                        if (doc.DocumentNode.SelectNodes("//p[@align=\"justify\"]") != null) {
                            node2 = doc.DocumentNode.SelectNodes("//p[@align=\"justify\"]")[0];
                            while (true)
                            {
                                if (node2.NextSibling != null)
                                {
                                    if (!node2.NextSibling.InnerHtml.Contains("<"))
                                    {
                                        message2 = message2 + node2.NextSibling.InnerHtml.ToString();
                                    }
                                    node2 = node2.NextSibling;
                                }
                                if (node2.OuterHtml.Contains("<table"))
                                {
                                    break;
                                }
                            }
                        }
                        
                        //message3 = node2.NextSibling.InnerHtml;
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + message3 + "')", true);
                        imagesource.Value = node.GetAttributeValue("src", null);
                        message.Value = message2;
                        node.Remove();
                        facebookpage.Attributes.Add("style", "visibility:visible");
                        pagename.Attributes.Add("style", "visibility:visible");
                        facebookmessage.Attributes.Add("style", "visibility:visible");
                        message.Attributes.Add("style", "visibility:visible;height:200px");

                        
                        /*doc.Save(HttpRuntime.AppDomainAppPath + "myfile2.html");
                        doc = h.Load(HttpRuntime.AppDomainAppPath + "myfile2.html");
                        HtmlNode node2 = doc.DocumentNode.SelectSingleNode("//img[@id=\"web-main-img\"]");
                        HtmlAttribute src = node2.Attributes["src"];
                        Image img = */
                    
                }
                if (Sales == true && Price == true && Days == false) 
                {
                    HtmlNode node = doc.DocumentNode.SelectNodes("//img[@class=\"web-main-img\"]")[1];

                    //url2.Value = "<canvas id=\"canvas\"></canvas>" + node.OuterHtml;
                    var canvas = "<canvas id=\"myCanvas\"></canvas>";
                    var script = System.Environment.NewLine + "<script>" + System.Environment.NewLine +
                            "document.getElementById(\"web-main-img\").onload = function() {" + System.Environment.NewLine +
                            "document.getElementById(\"myCanvas\").width = document.getElementById(\"web-main-img\").width;" + System.Environment.NewLine +
                            "document.getElementById(\"myCanvas\").height = document.getElementById(\"web-main-img\").height;" + System.Environment.NewLine +
                            "document.getElementById(\"web-main-img\").style.display = \" inline-block \";" + System.Environment.NewLine +
                            "var canvas = document.getElementById(\"myCanvas\");" + System.Environment.NewLine +
                            "var ctx = canvas.getContext(\"2d\");" + System.Environment.NewLine +
                            "var text = \"" + txt.Value + "\";" + System.Environment.NewLine +
                            "var width = document.getElementById(\"myCanvas\").width;" + System.Environment.NewLine +
                            "var height = document.getElementById(\"myCanvas\").height;" + System.Environment.NewLine +
                            "ctx.drawImage(document.getElementById(\"web-main-img\"), 1, 1);" + System.Environment.NewLine +
                            "ctx.font = \"bold 500pt Tahoma\";" + System.Environment.NewLine +
                            "var diagonal = Math.sqrt(2 * Math.pow((parseInt(ctx.font.match(/\\d+/), 10)), 2));" + System.Environment.NewLine +
                            "var diagonal2 = Math.sqrt(Math.pow(width, 2) + Math.pow(height, 2));" + System.Environment.NewLine +
                            "var smaller;" + System.Environment.NewLine +
                            "var dif;" + System.Environment.NewLine +
                            "if (width > height) { smaller = height }" + System.Environment.NewLine +
                            "else if (width <= height) { smaller = width; }" + System.Environment.NewLine +
                            "function isOverflown() { " + System.Environment.NewLine +
                            "dif = smaller - (diagonal / 2);" + System.Environment.NewLine +
                            "if (dif < 0) { dif = smaller / 2; }" + System.Environment.NewLine +
                            "return ctx.measureText(text).width >= Math.sqrt(2 * Math.pow(dif, 2));}" + System.Environment.NewLine +
                            "let fontSize = parseInt(ctx.font.match(/\\d+/), 10);" + System.Environment.NewLine +
                            "for (let i = fontSize; i >= 0; i--) {" + System.Environment.NewLine +
                            "let overflow = isOverflown();" + System.Environment.NewLine +
                            "if (overflow) {" + System.Environment.NewLine +
                            "fontSize--;" + System.Environment.NewLine +
                            "ctx.font = \"bold \" + fontSize + \"px Tahoma\";" + System.Environment.NewLine +
                            "diagonal = Math.sqrt(2 * Math.pow((parseInt(ctx.font.match(/\\d+/), 10)), 2));" + System.Environment.NewLine +
                            "}" + System.Environment.NewLine +
                            "}" + System.Environment.NewLine +
                            "ctx.fillStyle = 'red';" + System.Environment.NewLine +
                            "ctx.translate((document.getElementById(\"myCanvas\").width) / 2, (document.getElementById(\"myCanvas\").height) / 2 + (parseInt(ctx.font.match(/\\d+/), 10) / 2));" + System.Environment.NewLine +
                            "ctx.rotate(-45 * Math.PI / 180);" + System.Environment.NewLine +
                            "ctx.translate((parseInt(ctx.font.match(/\\d+/), 10) / 3 ), 0);" + System.Environment.NewLine +
                            "ctx.textAlign = \"center\";" + System.Environment.NewLine +
                            "ctx.fillText(text, 0, 0);" + System.Environment.NewLine +
                            //"ctx.fillRect(0, 0, 10, 10);" + System.Environment.NewLine +

                            "document.getElementById(\"web-main-img\").style.display = \" none \";" + System.Environment.NewLine +
                            "};" + System.Environment.NewLine +
                            "</script>" + System.Environment.NewLine;
                    node.Attributes.Add("id", "web-main-img");
                    //node.InnerHtml = node.NextSibling.OuterHtml + node.NextSibling.NextSibling.OuterHtml + canvas + node.NextSibling.NextSibling.NextSibling.OuterHtml + script + node.NextSibling.NextSibling.NextSibling.NextSibling.OuterHtml;
                    //var a = node.PreviousSibling.OuterHtml + canvas + node.OuterHtml + script + node.NextSibling.OuterHtml;

                    //url2.Value = node.PreviousSibling.OuterHtml + "||" + node.PreviousSibling.InnerHtml;
                    //url2.Value = node.NextSibling.LastChild.InnerHtml;
                    node.PreviousSibling.InnerHtml = canvas + node.OuterHtml + script;
                    var message2 = "";
                    HtmlNode node2;
                    if (doc.DocumentNode.SelectSingleNode("//h1") != null)
                    {
                        node2 = doc.DocumentNode.SelectSingleNode("//h1");
                        message2 = node2.InnerHtml + System.Environment.NewLine + System.Environment.NewLine;
                    }

                    if (doc.DocumentNode.SelectNodes("//p[@align=\"justify\"]") != null)
                    {
                        node2 = doc.DocumentNode.SelectNodes("//p[@align=\"justify\"]")[0];
                        while (true)
                        {
                            if (node2.NextSibling != null)
                            {
                                if (!node2.NextSibling.InnerHtml.Contains("<"))
                                {
                                    message2 = message2 + node2.NextSibling.InnerHtml.ToString();
                                }
                                node2 = node2.NextSibling;
                            }
                            if (node2.OuterHtml.Contains("<table"))
                            {
                                break;
                            }
                        }
                    }
                    imagesource.Value = node.GetAttributeValue("src", null);
                    message.Value = message2;
                    node.Remove();
                    facebookpage.Attributes.Add("style", "visibility:visible");
                    pagename.Attributes.Add("style", "visibility:visible");
                    facebookmessage.Attributes.Add("style", "visibility:visible");
                    message.Attributes.Add("style", "visibility:visible;height:200px");

                    foreach (HtmlNode node3 in doc.DocumentNode.SelectNodes("//span[@class=\"web-price-value-new\"]"))
                    {
                        node3.InnerHtml = txt2.Value + "&nbsp;&euro;";
                    }
                }
                if (Sales == false && Price == true && Days == true) 
                {
                    foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//span[@class=\"web-price-value-new\"]"))
                    {
                        node.InnerHtml = txt.Value + "&nbsp;&euro;" + "&nbsp;για&nbsp;" + txt2.Value + "&nbsp;μέρες";
                    }

                }
                if (Sales == true && Price == false && Days == true) 
                {
                    foreach (HtmlNode node3 in doc.DocumentNode.SelectNodes("//span[@class=\"web-price-value-new\"]"))
                    {
                        node3.InnerHtml = node3.InnerHtml + "&nbsp;για&nbsp;" + txt2.Value + "&nbsp;μέρες";
                    }

                    HtmlNode node = doc.DocumentNode.SelectNodes("//img[@class=\"web-main-img\"]")[1];

                    //url2.Value = "<canvas id=\"canvas\"></canvas>" + node.OuterHtml;
                    var canvas = "<canvas id=\"myCanvas\"></canvas>";
                    var script = System.Environment.NewLine + "<script>" + System.Environment.NewLine +
                            "document.getElementById(\"web-main-img\").onload = function() {" + System.Environment.NewLine +
                            "document.getElementById(\"myCanvas\").width = document.getElementById(\"web-main-img\").width;" + System.Environment.NewLine +
                            "document.getElementById(\"myCanvas\").height = document.getElementById(\"web-main-img\").height;" + System.Environment.NewLine +
                            "document.getElementById(\"web-main-img\").style.display = \" inline-block \";" + System.Environment.NewLine +
                            "var canvas = document.getElementById(\"myCanvas\");" + System.Environment.NewLine +
                            "var ctx = canvas.getContext(\"2d\");" + System.Environment.NewLine +
                            "var text = \"" + txt.Value + "\";" + System.Environment.NewLine +
                            "var width = document.getElementById(\"myCanvas\").width;" + System.Environment.NewLine +
                            "var height = document.getElementById(\"myCanvas\").height;" + System.Environment.NewLine +
                            "ctx.drawImage(document.getElementById(\"web-main-img\"), 1, 1);" + System.Environment.NewLine +
                            "ctx.font = \"bold 500pt Tahoma\";" + System.Environment.NewLine +
                            "var diagonal = Math.sqrt(2 * Math.pow((parseInt(ctx.font.match(/\\d+/), 10)), 2));" + System.Environment.NewLine +
                            "var diagonal2 = Math.sqrt(Math.pow(width, 2) + Math.pow(height, 2));" + System.Environment.NewLine +
                            "var smaller;" + System.Environment.NewLine +
                            "var dif;" + System.Environment.NewLine +
                            "if (width > height) { smaller = height }" + System.Environment.NewLine +
                            "else if (width <= height) { smaller = width; }" + System.Environment.NewLine +
                            "function isOverflown() { " + System.Environment.NewLine +
                            "dif = smaller - (diagonal / 2);" + System.Environment.NewLine +
                            "if (dif < 0) { dif = smaller / 2; }" + System.Environment.NewLine +
                            "return ctx.measureText(text).width >= Math.sqrt(2 * Math.pow(dif, 2));}" + System.Environment.NewLine +
                            "let fontSize = parseInt(ctx.font.match(/\\d+/), 10);" + System.Environment.NewLine +
                            "for (let i = fontSize; i >= 0; i--) {" + System.Environment.NewLine +
                            "let overflow = isOverflown();" + System.Environment.NewLine +
                            "if (overflow) {" + System.Environment.NewLine +
                            "fontSize--;" + System.Environment.NewLine +
                            "ctx.font = \"bold \" + fontSize + \"px Tahoma\";" + System.Environment.NewLine +
                            "diagonal = Math.sqrt(2 * Math.pow((parseInt(ctx.font.match(/\\d+/), 10)), 2));" + System.Environment.NewLine +
                            "}" + System.Environment.NewLine +
                            "}" + System.Environment.NewLine +
                            "ctx.fillStyle = 'red';" + System.Environment.NewLine +
                            "ctx.translate((document.getElementById(\"myCanvas\").width) / 2, (document.getElementById(\"myCanvas\").height) / 2 + (parseInt(ctx.font.match(/\\d+/), 10) / 2));" + System.Environment.NewLine +
                            "ctx.rotate(-45 * Math.PI / 180);" + System.Environment.NewLine +
                            "ctx.translate((parseInt(ctx.font.match(/\\d+/), 10) / 3 ), 0);" + System.Environment.NewLine +
                            "ctx.textAlign = \"center\";" + System.Environment.NewLine +
                            "ctx.fillText(text, 0, 0);" + System.Environment.NewLine +
                        //"ctx.fillRect(0, 0, 10, 10);" + System.Environment.NewLine +

                            "document.getElementById(\"web-main-img\").style.display = \" none \";" + System.Environment.NewLine +
                            "};" + System.Environment.NewLine +
                            "</script>" + System.Environment.NewLine;
                    node.Attributes.Add("id", "web-main-img");
                    //node.InnerHtml = node.NextSibling.OuterHtml + node.NextSibling.NextSibling.OuterHtml + canvas + node.NextSibling.NextSibling.NextSibling.OuterHtml + script + node.NextSibling.NextSibling.NextSibling.NextSibling.OuterHtml;
                    //var a = node.PreviousSibling.OuterHtml + canvas + node.OuterHtml + script + node.NextSibling.OuterHtml;

                    //url2.Value = node.PreviousSibling.OuterHtml + "||" + node.PreviousSibling.InnerHtml;
                    //url2.Value = node.NextSibling.LastChild.InnerHtml;
                    node.PreviousSibling.InnerHtml = canvas + node.OuterHtml + script;
                    var message2 = "";
                    HtmlNode node2;
                    if (doc.DocumentNode.SelectSingleNode("//h1") != null)
                    {
                        node2 = doc.DocumentNode.SelectSingleNode("//h1");
                        message2 = node2.InnerHtml + System.Environment.NewLine + System.Environment.NewLine;
                    }

                    if (doc.DocumentNode.SelectNodes("//p[@align=\"justify\"]") != null)
                    {
                        node2 = doc.DocumentNode.SelectNodes("//p[@align=\"justify\"]")[0];
                        while (true)
                        {
                            if (node2.NextSibling != null)
                            {
                                if (!node2.NextSibling.InnerHtml.Contains("<"))
                                {
                                    message2 = message2 + node2.NextSibling.InnerHtml.ToString();
                                }
                                node2 = node2.NextSibling;
                            }
                            if (node2.OuterHtml.Contains("<table"))
                            {
                                break;
                            }
                        }
                    }
                    imagesource.Value = node.GetAttributeValue("src", null);
                    message.Value = message2;
                    node.Remove();
                    facebookpage.Attributes.Add("style", "visibility:visible");
                    pagename.Attributes.Add("style", "visibility:visible");
                    facebookmessage.Attributes.Add("style", "visibility:visible");
                    message.Attributes.Add("style", "visibility:visible;height:200px");

                }
               

                
                doc.Save(HttpRuntime.AppDomainAppPath + "myfile2.html");
                //HtmlNode.ElementsFlags.Remove("table");
                //HtmlNode.ElementsFlags.Remove("td");
                //HtmlNode.ElementsFlags.Remove("tr");
                //HtmlNode.ElementsFlags.Remove("li");
                //HtmlNode.ElementsFlags.Remove("ul");
                
                //StreamWriter writer = new StreamWriter(HttpRuntime.AppDomainAppPath + "myfile.html", false, System.Text.Encoding.GetEncoding(1253));
               // writer.Write(doc.DocumentNode.OuterHtml);
                //writer.Close();
                //txt.Value = InputText;
                /*string text = File.ReadAllText("myfile.html");
                text = text.Replace("some text", "new value");
                File.WriteAllText("myfile.html", text);
                var html = new HtmlAgilityPack.HtmlDocument();
                html.LoadHtml(markup);
                var links = html.DocumentNode.SelectNodes("//link");
                foreach (var link in links)
                {
                    link.Attributes["href"].Value = StaticClass.ZipFilePath +
                      "\\OEBPS\\styles.css";
                }

                var builder = new StringBuilder();
                using (var writer = new StringWriter(builder))
                {
                    html.Save(writer);
                }*/

                }
                
                //url2.Value = Sales.ToString();
            }
            txt.Attributes.Add("style", "visibility:hidden");
            description1.Attributes.Add("style", "visibility:hidden");
            button.Attributes.Add("style", "visibility:hidden");
            txt2.Attributes.Add("style", "visibility:hidden");
            description2.Attributes.Add("style", "visibility:hidden");
            url2.Value = "";
            Sales = false;
            Price = false;
            Days = false;
        }

        

        

        
        
        
    }
}