	var windowProxy = window.external;   
	var recentDocumentItems = new Array();
	
	function ShowOpenDialog()
	{
		windowProxy.ExecuteCommand("File.OpenDocument");
	}
	function ShowCreateDialog()
	{
		windowProxy.ExecuteCommand("File.New");
	}  
	
	function OpenFile(path)
	{
	    windowProxy.OpenRecentDocument(path);
	}
	
	function MakeListClickFunction(path)
	{
	    return function()
	    {
	        OpenFile(path);
	    }
	}
	
	function CreateRecentDocumentList()
	{
	    var fileList = document.all.FileList;
	    
	    var itemCount = windowProxy.GetRecentDocumentCount();
	    var count=0;
	    for(count=0; count < itemCount; count++)
	    {
	        var title = windowProxy.GetRecentDocumentTitle(count);
	        var path = windowProxy.GetRecentDocumentPath(count);
	        recentDocumentItems[count] = path;
	        var listItem = document.createElement("li");
	        var listItemLink = document.createElement("a");
	        listItemLink.innerText = title;	 
	        listItemLink.attachEvent('onclick', MakeListClickFunction(path));
	        var listItemHRefAttribute = document.createAttribute("href");
	        listItemHRefAttribute.value = "about:blank";
	        listItemLink.setAttributeNode(listItemHRefAttribute);
	        listItem.appendChild(listItemLink);
	        fileList.appendChild(listItem);
	    }
	    
	}
