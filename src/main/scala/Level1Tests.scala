object Level1Tests {

    @Rank(1)
    def helloWorldTest() {
        Assert.areEqual("Hello World!", Level1Code.helloWorld());
    }
    @Rank(2)
    def sumTest(): Unit = {
        Assert.areEqual(10, Level1Code.sum(0, 10))
        Assert.areEqual(10, Level1Code.sum(2, 8))
        Assert.areEqual(10, Level1Code.sum(6, 4))
        Assert.areEqual(10, Level1Code.sum(5, 5))
    }
    @Rank(3)
    def productTest(): Unit = {
        Assert.areEqual(100, Level1Code.product(1, 100))
        Assert.areEqual(100, Level1Code.product(2, 50))
        Assert.areEqual(100, Level1Code.product(4, 25))
        Assert.areEqual(100, Level1Code.product(5, 20))
    }
    @Rank(4)
    def squareTest(): Unit = {
        Assert.areEqual(1, Level1Code.square(1))
        Assert.areEqual(4, Level1Code.square(2))
        Assert.areEqual(16, Level1Code.square(4))
        Assert.areEqual(25, Level1Code.square(5))
    }
    @Rank(5)
    def cubeTest(): Unit = {
        Assert.areEqual(1, Level1Code.cube(1))
        Assert.areEqual(8, Level1Code.cube(2))
        Assert.areEqual(27, Level1Code.cube(3))
        Assert.areEqual(64, Level1Code.cube(4))
    }
    @Rank(6)
    def squareRootOfPerfectSquareTest(): Unit = {
        Assert.areEqual(Some(1), Level1Code.squareRootOfPerfectSquare(1))
        Assert.areEqual(Some(2), Level1Code.squareRootOfPerfectSquare(4))
        Assert.areEqual(Some(4), Level1Code.squareRootOfPerfectSquare(16))
        Assert.areEqual(Some(5), Level1Code.squareRootOfPerfectSquare(25))
        Assert.areEqual(None, Level1Code.squareRootOfPerfectSquare(2))
        Assert.areEqual(None, Level1Code.squareRootOfPerfectSquare(-25))
    }
    @Rank(7)
    def quotientTest(): Unit = {
        Assert.areEqual(2, Level1Code.quotient(101, 50))
        Assert.areEqual(4, Level1Code.quotient(102, 25))
        Assert.areEqual(5, Level1Code.quotient(103, 20))
        Assert.areEqual(10, Level1Code.quotient(104, 10))
    }
    @Rank(8)
    def remainderTest(): Unit = {
        Assert.areEqual(1, Level1Code.remainder(101, 50))
        Assert.areEqual(2, Level1Code.remainder(102, 25))
        Assert.areEqual(3, Level1Code.remainder(103, 20))
        Assert.areEqual(4, Level1Code.remainder(104, 10))
    }
    @Rank(9)
    def squareAllTest(): Unit = {
        Assert.areEqual(Array[Int](1, 4, 9, 16, 25).toSeq, Level1Code.squareAll(Array[Int](1, 2, 3, 4, 5)).toSeq)
    }
    @Rank(10)
    def cubeAllTest(): Unit = {
        Assert.areEqual(Array[Int](1, 8, 27, 64, 125).toSeq, Level1Code.cubeAll(Array[Int](1, 2, 3, 4, 5)).toSeq)
    }
    @Rank(11)
    def productAllTest(): Unit = {
        Assert.areEqual(Array[Int](2, 6, 12, 20, 30).toSeq, Level1Code.productAll(Array[Int](1, 2, 3, 4, 5), Array[Int](2, 3, 4, 5, 6)).toSeq)
    }
    @Rank(12)
    def sumAllTest(): Unit = {
        Assert.areEqual(100, Level1Code.sumAll(Array[Int](1, 9, 2, 8, 3, 7, 4, 6, 5, 5, 50)))
    }
    @Rank(13)
    def reverseTest(): Unit = {
        Assert.areEqual(Array[Int](1, 5, 1, 2, 1, 9, 1, 3).toSeq, Level1Code.reverse(Array[Int](3, 1, 9, 1, 2, 1, 5, 1)).toSeq)
    }

}
