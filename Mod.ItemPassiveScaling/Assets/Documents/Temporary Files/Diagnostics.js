function getElementsByClass(searchClass, node, tag) {
	var classElements = new Array();
	
	if (node == null) {
		node = document;
	}
	
	if (tag == null) {
		tag = '*';
	}
	
	var elements = node.getElementsByTagName(tag);
	var elementsSize = elements.length;
	var pattern = new RegExp("(^|\\s)" + searchClass + "(\\s|$)");
	
	for (i = 0, j = 0; i < elementsSize; i++) {
		if (pattern.test(elements[i].className)) {
			classElements[j] = elements[i];
			j++;
		}
	}
	
	return classElements;
}

function hide(id) 
{
	var element_style = document.getElementById(id).style;
	var status = element_style.display;
	
	if (status != 'block') {
		element_style.display = 'block';
	}
	else {
		element_style.display = 'none';
	}
}

function hide_class(className)
{
	var elements = getElementsByClass(className);
	var pattern = new RegExp("(^|\\s)Button(\\s|$)");
	
	for (i = 0; i < elements.length; i++)
	{		
		if (!pattern.test(elements[i].className)) {
			if(elements[i].style.display != 'none') {
			    elements[i].style.display = 'none';
			}
			else {
			    elements[i].style.display = 'block';
			}
		}
	}
}