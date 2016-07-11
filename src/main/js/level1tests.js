var assert = require('./assert.js');
var code = require('./level1code.js');
var level1tests = {
    helloWorldTest: function () {
        assert.areEqual("Hello World!", code.helloWorld());
    },
    sumTest: function () {
        assert.areEqual(10, code.sum(0, 10));
        assert.areEqual(10, code.sum(2, 8));
        assert.areEqual(10, code.sum(6, 4));
        assert.areEqual(10, code.sum(5, 5));
    },
    productTest: function () {
        assert.areEqual(100, code.product(1, 100));
        assert.areEqual(100, code.product(2, 50));
        assert.areEqual(100, code.product(4, 25));
        assert.areEqual(100, code.product(5, 20));
    },
    squareTest: function () {
        assert.areEqual(1, code.square(1));
        assert.areEqual(4, code.square(2));
        assert.areEqual(16, code.square(4));
        assert.areEqual(25, code.square(5));
    },
    cubeTest: function () {
        assert.areEqual(1, code.cube(1));
        assert.areEqual(8, code.cube(2));
        assert.areEqual(27, code.cube(3));
        assert.areEqual(64, code.cube(4));
    },
    sqrtTest: function () {
        assert.areEqual(1, code.sqrt(1));
        assert.areEqual(2, code.sqrt(4));
        assert.areEqual(4, code.sqrt(16));
        assert.areEqual(5, code.sqrt(25));
    },
    quotientTest: function () {
        assert.areEqual(2, code.quotient(101, 50));
        assert.areEqual(4, code.quotient(102, 25));
        assert.areEqual(5, code.quotient(103, 20));
        assert.areEqual(10, code.quotient(104, 10));
    },
    remainderTest: function () {
        assert.areEqual(1, code.remainder(101, 50));
        assert.areEqual(2, code.remainder(102, 25));
        assert.areEqual(3, code.remainder(103, 20));
        assert.areEqual(4, code.remainder(104, 10));
    },
    assertEqualArrays: function (expected, actual) {
        for (var i = 0; i < expected.length; i++) {
            assert.areEqual(expected[i], actual[i]);
        }
        assert.areEqual(expected.length, actual.length);
    },
    squareAllTest: function () {
        var expected = [1, 4, 9, 16, 25];
        var actual = code.squareAll([1, 2, 3, 4, 5]);
        this.assertEqualArrays(expected, actual);
    },
    cubeAllTest: function () {
        var expected = [1, 8, 27, 64, 125];
        var actual = code.cubeAll([1, 2, 3, 4, 5]);
        this.assertEqualArrays(expected, actual);
    },
    productAllTest: function () {
        var expected = [2, 6, 12, 20, 30];
        var actual = code.productAll([1, 2, 3, 4, 5], [2, 3, 4, 5, 6]);
        this.assertEqualArrays(expected, actual);
    },
    sumAllTest: function () {
        var actual = code.sumAll([1, 9, 2, 8, 3, 7, 4, 6, 5, 5, 50]);
        assert.areEqual(100, actual);
    },
    reverseTest: function () {
        var expected = [1, 5, 1, 2, 1, 9, 1, 3];
        var actual = code.reverse([3, 1, 9, 1, 2, 1, 5, 1]);
        this.assertEqualArrays(expected, actual);
    }
};
module.exports = level1tests;