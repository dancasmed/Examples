(function()
{
 "use strict";
 /*
   hook up event handlers 
 */
 function register_event_handlers()
 {
    
    
    
    
     /* button  #btn_Refresh */
    
    
        /* button  #btn_Refresh */
    $(document).on("click", "#btn_Refresh", function(evt)
    {
        /* your code goes here */ 
       
        var lst = document.getElementById("ui_myList");
        lst.innerHTML="";
        var i = 0;
        
        $.getJSON("http://localhost:3000/elections.json?user_email=usuario1@kratos.org.mx&user_token=ezPFX7zsYYyR4Z-nEWgE", function(data)
        {
            for(i=0; i<data.length; i++)
            {
                console.log(data[i]);
                lst.innerHTML+="<a class=\"list-group-item allow-badge widget uib_w_10\" data-uib=\"twitter%20bootstrap/list_item\" data-ver=\"1\"><p class=\"list-group-item-text\">"+data[i]["title"]+"</p><h4 class=\"+list-group-item-heading+\">"+data[i]["description"]+"</h4></a>";
            }
        });
        
        
    });
    
    }
 document.addEventListener("app.Ready", register_event_handlers, false);
})();
