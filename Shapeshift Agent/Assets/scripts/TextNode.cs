using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class TextNode {
    private Dictionary<string, string> map = new Dictionary<string, string>();
    public TextNode(string tag, string text) {
        map.Add(tag, text);
    }

    public string get(string tag) {
        string value;
        map.TryGetValue(tag, out value);
        return value;
    }
}

