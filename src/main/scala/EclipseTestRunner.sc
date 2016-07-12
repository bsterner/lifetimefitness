object EclipseTestRunner {
    println("Welcome to the Scala worksheet")     //> Welcome to the Scala worksheet
    Level1Tests.helloWorldTest()                  //> Hello World!

    // Patch example
    var as = Array(0, 1, 2)                       //> as  : Array[Int] = Array(0, 1, 2)
    var r1 = as patch (0, Array(45, 66), 2)
    println("Patch = " + r1.toList)
    var a1 = Array(1,2,3)
}