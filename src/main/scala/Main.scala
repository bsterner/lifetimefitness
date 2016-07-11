object Main {

  def test(m: java.lang.reflect.Method, o: java.lang.Object) {

    try {
      m.invoke(o);
      println("[" + Console.GREEN + "PASS" + Console.RESET + "] " + m.getName)
    } catch {
      case e: Exception =>
        println("[" + Console.RED + "FAIL" + Console.RESET + "] " + m.getName + ": " + e.getCause.getMessage)
    }
  }

  def main(args: Array[String]) {

    println("\nScala Tests:");

    val tests = Array(Level1Tests)

    tests.foreach { o =>
      o
        .getClass
        .getMethods
        .sortWith((m1, m2) => {
          val r1 = m1.getAnnotation(classOf[Rank])
          val r2 = m2.getAnnotation(classOf[Rank])
          if (r1 != null && r2 != null)
            r1.value < r2.value
          else false
        })
        .filter(m => m.getName.endsWith("Test"))
        .map(m => {
          test(m, o);
          0
        });
    }

    println("Done!");
  }
}
