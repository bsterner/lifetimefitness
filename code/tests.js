var assert = require('./assert.js');
var code = require('../code.js');
var tests = {
    helloWorldTest: function() {
        assert.areEqual("Hello World!", code.helloWorld());
    },
    monkeysAndCoconutsTest: function() {
        assert.areEqual(3121, code.monkeysAndCoconuts(5));
    },
    stream: function(text) {
        var head = {};
        var current = head;
        var chunksize = 10;
        var previous;
        for (var i = 0; i < text.length; i += 10) {
            var chunk = text.substr(i, chunksize);
            current.data = chunk;
            current.next = {};
            previous = current;
            current = current.next;
        }
        previous.next = null;
        return head;
    },
    isTextInStreamTest: function() {
        assert.isTrue(code.isTextInStream(this.stream("Whatever Whatever Whatever Whatever Whatever Whatever Whatever FINDME Whatever"), "FINDME"));
        assert.isTrue(code.isTextInStream(this.stream("Whatever FINDME1238901238901230479823798 Whatever"), "FINDME1238901238901230479823798"));
        assert.isFalse(code.isTextInStream(this.stream("Whatever FINDME Whatever"), "Hello World"));
    },
    iterateGameOfLifeTest: function() {
        var startField = [
            "               ",
            "  X            ",
            "   X           ",
            " XXX           ",
            "               ",
            "               ",
            "               ",
            "               ",
            "               ",
            "               ",
            "               ",
            "               ",
            "               ",
            "               "
        ];
        var nextField = [
            "               ",
            "               ",
            " X X           ",
            "  XX           ",
            "  X            ",
            "               ",
            "               ",
            "               ",
            "               ",
            "               ",
            "               ",
            "               ",
            "               ",
            "               "
        ];
        var endField = [
            "               ",
            "               ",
            "               ",
            "               ",
            "               ",
            "               ",
            "               ",
            "               ",
            "               ",
            "               ",
            "         X X   ",
            "          XX   ",
            "          X    ",
            "               "
        ];
        
        var decodeField = function(field) {
            return field.map(function(l) { 
                return l.split("")
                    .map(function(c) {
                        return c === "X";
                    });
            });
        };
        var stringify = function(field) {
            return "\n" + 
                field.map(function(l) {
                    return l.map(function(c) {
                        return c ? "X" : "-";
                    }).join("");
                }).join("\n") +
                "\n";
        }
        var testIteration = function(start, end, generations) {
            var startData = decodeField(start);
            var nextData = startData;
            for (var g = 0; g < generations; g++) nextData = code.iterateLife(nextData);
            assert.areEqual(stringify(decodeField(end)), stringify(nextData), null);
            assert.areEqual(stringify(decodeField(start)), stringify(startData), "Original state should not be modified.");
        }
        
        testIteration(startField, nextField, 1);
        testIteration(nextField, endField, 32);
        
    }
};
module.exports = tests;
    
