var DataManager = {
    host: "http://kratos.no-ip.org",
    Countries: [],
    Entities: [],
    Municipalities: [],
    PoliticalRoles: [],
    ExercisedPoliticalRoles: [],
    LoadData: function()
    {
        console.log("Loading data...");
        $.getJSON(DataManager.host + "/countries.json", function(data)
        {
            DataManager.Countries = data;
            console.log(DataManager.Countries.length+ " countries loaded.");
        });
        $.getJSON(DataManager.host + "/entities.json", function(data)
        {
            DataManager.Entities = data;
            console.log(DataManager.Entities.length+ " entities loaded.");
        });
        $.getJSON(DataManager.host + "/municipalities.json", function(data)
        {
            DataManager.Municipalities = data;
            console.log(DataManager.Municipalities.length+ " municipalities loaded.");
        });
        $.getJSON(DataManager.host + "/political_roles.json", function(data)
        {
            DataManager.PoliticalRoles = data;
            console.log(DataManager.PoliticalRoles.length+ " political roles loaded.");
        });
        $.getJSON(DataManager.host + "/exercised_political_roles.json", function(data)
        {
            DataManager.ExercisedPoliticalRoles = data;
            console.log(DataManager.ExercisedPoliticalRoles.length+ " exercised political roles loaded.");
        });
    }
};
