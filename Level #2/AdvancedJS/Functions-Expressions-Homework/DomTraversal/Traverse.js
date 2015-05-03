﻿ function traverse(node) {
    var elements = document.querySelectorAll(node);

﻿     function changeInnerHtml(innerHtml) {
          var element = document.getElementsByClassName("birds");
          element.innerHTML += innerHtml + "</br>";
      }

﻿     function traverseNode(node, spacing) {
          spacing = spacing || '  ';
          var output = spacing + node.nodeName.toLowerCase() + ":";
          var elId = node.getAttribute('id');
          var elClass = node.getAttribute('class');
        
          if (elId != null) {
              output += " id=\"" + elId + "\"";
          }
        
          if (elClass != null) {
              output += " class=\"" + elClass + "\"";
          }
        
          changeInnerHtml(output);
        
          for (var j = 0; j < node.childNodes.length; j += 1) {
              var child = node.childNodes[j];
              if (child.nodeType === document.ELEMENT_NODE) {
                  traverseNode(child, spacing + '  ');
              }
          }
      }

﻿     if (elements.nodeType === Document.ELEMENT_NODE) {
        for (var i = 0; i < elements.length; i += 1) {
            changeInnerHtml("<span style=\"color:red\"><b>Element: " + (i + 1) + "</b></span>");
            traverseNode(elements[i], '');
        }
    }
﻿ }

var selector = ".birds";
traverse(selector);