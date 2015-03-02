(function()
{
 "use strict";
 /*
   hook up event handlers 
 */
 function register_event_handlers()
 {
    
    
     /* button  Button */
    $(document).on("click", ".uib_w_4", function(evt)
    {
         activate_page("#mainpage"); 
    });
    
        /* button  #save_conf */
    $(document).on("click", "#save_conf", function(evt)
    {
        /* your code goes here */ 
         Configuration["Bob"]="Hola man";
    Configuration.Save();
        
        var output = document.getElementById("output_text");
        output.innerHTML+=DataManager.Countries;
        output.innerHTML+=DataManager.Entities;
        output.innerHTML+=DataManager.Municipalities;
        output.innerHTML+=DataManager.PoliticalRoles;
    });
    
    }
 document.addEventListener("app.Ready", register_event_handlers, false);
})();
