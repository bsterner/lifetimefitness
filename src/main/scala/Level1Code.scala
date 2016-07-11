object Level1Code {

    private def INT_MAX: Int = Int.MaxValue;

    // Returns "Hello World!"
    def helloWorld(): String = {
        val message: String = "Hello World!"
        println(message)
        message
    }

    // Return the sum of two numbers
    def sum(a: Int, b: Int): Int = {
        Math.addExact(a, b)
        // a+b
    }

    //  // Return the product of two numbers
    def product(a: Int, b: Int): Int = {
        Math.multiplyExact(a, b)
    }

    // Return the square of a number
    def square(a: Int): Int = {
        Math.multiplyExact(a, a)
        //        var sq = BigInt(a).pow(2)
        //        if (sq > INT_MAX) {
        //            val failText: String = s"The square of [ $a ] results in a value of [ $sq ] which is too large to be represented as an Int."
        //            throw new Exception(failText)
        //        }
        //        sq.intValue()
    }

    // return the cube of a number
    def cube(a: Int): Int = {
        Math.multiplyExact(a, Math.multiplyExact(a, a))
        //        var cb = BigInt(a).pow(3)
        //        if (cb > INT_MAX) {
        //            val failText: String = s"The square of [ $a ] results in a value of [ $cb ] which is too large to be represented as an Int."
        //            throw new Exception(failText)
        //        }
        //        cb.intValue()
    }

    // return the Int quotient of a fraction
    def quotient(numerator: Int, denominator: Int): Int = {
        numerator / denominator
    }

    // return the Int remainder of a fraction
    def remainder(numerator: Int, denominator: Int): Int = {
        numerator % denominator
    }

    // return the square root of perfect squares only.
    //  def squareRootOfPerfectSquare(a: Int): Option[Int] = ???
    //
    //  // return an array containing the square of each number
    //  // in the source array in the same order
    //  def squareAll(as: Array[Int]): Array[Int] = ???
    //
    //  // return an array containing the cube of each number
    //  // in the source array in the same order
    //  def cubeAll(as: Array[Int]): Array[Int] = ???
    //
    //  // return an array containing the product of an 'a' in array 'as' with
    //  // its respective 'b' in array 'bs'
    //  def productAll(as: Array[Int], bs: Array[Int]): Array[Int] = ???
    //
    //  // sum all of the elements in the array and return the result
    //  def sumAll(as: Array[Int]): Int = ???
    //
    //  // reverse the array
    //  def reverse(as: Array[Int]): Array[Int] = ???

}