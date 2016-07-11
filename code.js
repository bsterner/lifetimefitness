var code = {
    // Returns "Hello World!"
    helloWorld: function() {
        return "Hello World!";
    },
        
    //Monkeys and Coconuts https://youtu.be/U9qU20VmvaU?t=43s
    //
    //<n> sailors are stranded on a desert island with one monkey.
    //The sailors gather coconuts into a pile and go to sleep.
    //
    //That night (without the knowledge of the others) each sailor in turn
    //separates out equal shares of coconuts with one left over (which they throw to the monkey)
    //then they hide their own share and throw the rest back on the pile.
    //
    //The next morning, they all separate the remaining pile and there are no coconuts left for the monkey. 
    //How many coconuts did they have in the pile the night before?
    monkeysAndCoconuts: function(sailors) {
        throw new Error("Not Implemented");
    },
    isTextInStream: function(stream, text) {
        throw new Error("Not Implemented");
    },
    // For a space that is 'populated':
    //   Each cell with one or no neighbors dies, as if by loneliness.
    //   Each cell with four or more neighbors dies, as if by overpopulation.
    //   Each cell with two or three neighbors survives.
    // For a space that is 'empty' or 'unpopulated'
    //   Each cell with three neighbors becomes populated.
    iterateLife: function(field) {
        throw new Error("Not Implemented");
        
    }
};
module.exports = code;