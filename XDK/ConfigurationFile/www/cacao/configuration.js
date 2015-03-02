var Configuration = {
    file: "configuration.txt",
    last_update: "2012-09-01T00:00:00.000-06:00",
    email: "none",
    country: "1",
    entity: "1",
    municipality: "1",
    section: "1",
    filter_badwords: "false",
    filter_negative: "false",
    Init : function()
    {
        console.log("Inicializando configuración...");
        requestFileSystem(LocalFileSystem.PERSISTENT, 0, this.onFileSystemAccessSuccess, this.onFileSystemAccessError);
    },
    onFileSystemAccessSuccess : function(fileSystem) 
    {   
        var directoryEntry = fileSystem.root;

       
        directoryEntry.getFile(Configuration.file, {create: true, exclusive: false},           function(fileEntry)
        {
            fileEntry.file(function(file)
            {
                var reader = new FileReader();
                reader.onloadend = function (evt)
                {
                    console.log(evt.target.result);
                    if(evt.target.result==="")
                    {
                        console.log("Configuration file does not exist.");
                        fileEntry.createWriter(function(writer)
                        {                               
                            console.log("Setting default configuration.");
                            writer.write(Configuration.GetConfigString());
                            
                        }, this.onFileSystemAccessError);
                    }
                    else
                    {
                        var pairs = evt.target.result.split(";");
                        console.log("Reading configuration.");
                        for(var i=0; i<pairs.length-1; i++)
                        {
                            var pair = pairs[i].split(",");                            
                            Configuration[pair[0]]=pair[1];
                        }
                    }
                };
                reader.readAsText(file);
            }, this.onFileSystemAccessError);

        }, this.onFileSystemAccessError);
    },
    GetConfigString : function()
    {
       
        var res = "";
        var keys = Object.keys(Configuration); 
        for(var j=0; j<keys.length;j++)
        {
            var str = ""+Configuration[keys[j]];
            if(str.indexOf("function")==-1)
            res+=keys[j]+","+str+";";
        }
        return res;
    },
    onFileSystemAccessError : function(evt)
    {    
        console.log("Error occurred while working with the configuration file. Error code is: " + evt.code);
    },
    Save : function()
    {        
        requestFileSystem(LocalFileSystem.PERSISTENT, 0, function(fileSystem) 
        {
            var directoryEntry = fileSystem.root;
            directoryEntry.getFile(Configuration.file, {create: true, exclusive: false},
            function(fileEntry)
            {
                fileEntry.file(function(file)
                {
                    fileEntry.createWriter(function(writer)
                    {
                        console.log("Saving configuration.");
                        writer.seek(0);
                        writer.write(Configuration.GetConfigString());
                    }, this.onFileSystemAccessError);

                }, this.onFileSystemAccessError);

            }, this.onFileSystemAccessError);
        }, this.onFileSystemAccessError);
    }
};

        
