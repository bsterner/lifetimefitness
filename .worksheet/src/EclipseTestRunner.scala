object EclipseTestRunner {;import org.scalaide.worksheet.runtime.library.WorksheetSupport._; def main(args: Array[String])=$execute{;$skip(72); 
    println("Welcome to the Scala worksheet");$skip(33); 
    Level1Tests.helloWorldTest();$skip(51); 

    // Patch example
    var as = Array(0, 1, 2);System.out.println("""as  : Array[Int] = """ + $show(as ));$skip(44); 
    var r1 = as patch (0, Array(45, 66), 2);System.out.println("""r1  : Array[Int] = """ + $show(r1 ));$skip(36); 
    println("Patch = " + r1.toList);$skip(26); 
    var a1 = Array(1,2,3);System.out.println("""a1  : Array[Int] = """ + $show(a1 ))}
}
