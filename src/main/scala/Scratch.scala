

object Scratcj {
      def square(a: Int): Int = {
        println("Biggest value of Int is " + Int.MaxValue);
        var b = 46341;
        var x = BigInt(Int.MaxValue).pow(2)
        var z : Int = Int.MaxValue;
        println(s"z was $z");
        z = z*z
        println(s"z is now $z " + (z > Int.MaxValue));
        if (x > Int.MaxValue) {
            val failText:String = "The square of [ " + a + " ] results in a value too high to be represented by an Int." +
                                    "The integer value right now is [" + x + "]";
            throw new Exception(failText);
        }
        println(s"The squared value of [ $b ] is [ " + x.intValue() + "]")
        x.intValue()
    }

}