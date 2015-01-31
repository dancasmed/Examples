(function()
{
 "use strict";
 /*
   hook up event handlers 
 */
 function register_event_handlers()
 {
    
    
     /* button  #btn_Refresh */
    $(document).on("click", "#btn_Refresh", function(evt)
    {
        /* your code goes here */ 
        
    });
    
    }
 document.addEventListener("app.Ready", register_event_handlers, false);
})();
