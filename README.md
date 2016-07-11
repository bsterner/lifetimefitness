# Notes for test day

You are allowed to use the internet and whatever other resources you feel may help you during the test, but you are NOT allowed to plug in anything into our computers. If you bring digital media, bring your own laptop to view it on. Also, it is safer to assume you will not be able to connect to the internet through your personal devices, only our provided test machine.

# Code Test 2 study guide

This project is intended to provide guidance for candidates in preparation for taking codetest-2.  The ideas and techniques used by these exercises will be leveraged during codetest-2, so it is important to be familiar with these concepts *before* taking codetest-2.

The most crucial things to spend your time on are the Collections and Streams APIs, and understanding functional programming principles.
We recommend you spend your time on the following areas:
- General Scala Syntax
    - Scala for the Impatient: http://fileadmin.cs.lth.se/scala/scala-impatient.pdf
    - Scala By Example- http://www.scala-lang.org/docu/files/ScalaByExample.pdf
- Streams API
    - http://www.scala-lang.org/api/current/index.html#scala.collection.immutable.package
    - http://www.scala-lang.org/api/current/index.html#scala.collection.immutable.Stream
- Collections API
    - http://docs.scala-lang.org/overviews/collections/overview.html
    - http://www.scala-lang.org/api/current/index.html#scala.collection.package
- Functional Programming
    - Functional Programming in Scala (Book): https://www.manning.com/books/functional-programming-in-scala
    - Grokking Functional Programming (Book): https://www.manning.com/books/grokking-functional-programming

The following links may also provide some guidance in preparation for codetest-2:
- Overview: http://docs.scala-lang.org/overviews/
- Scala Docs: http://www.scala-lang.org/documentation/
- Functional Programming Principles in Scala: https://www.coursera.org/course/progfun

Run the tests as outlined below in a terminal window, and change the code to make the tests pass, much like codetest-1.

## Running the test
### Windows

- Clone this repository: `https://github.com/AthlinksEngineering/recruiting-codetest-2-studyguide.git`
- Or click the Download button above and unzip to a directory.
- Using Windows Explorer, browse to `codetest-2-studyguide\test`, and double click on `test.cmd`

![](http://i.imgur.com/LFlkioh.png)
- Open and edit the src/main/scala/Level1Code.scala file. Use any code editor you are comfortable with.

- Test will re-execute on any code change.

![](http://i.imgur.com/fvPU3IQ.png)
- Press Ctrl-C to exit test monitor.

### Mac/Linux
- Run Terminal ![](http://i.imgur.com/SXN3tNM.png)

- Install dependencies
    - Mac: 
        - Install git
            - Run `git` from Terminal command line, and if it's not installed, you should be prompted to install Xcode command line tools
        - Install Java (http://www.oracle.com/technetwork/java/javase/downloads/index.html)
        - Install Mono (http://www.mono-project.com/download/)
        - Install brew (http://brew.sh)
        - In Terminal, run `brew install scala node`
    - Ubuntu: `sudo apt-get install git scala mono-devel nodejs npm openjdk-7-jdk`
- Clone this repository: `https://github.com/AthlinksEngineering/recruiting-codetest-2-studyguide.git`
- Run the test script
  - `cd codetest-2-studyguide/test`
  - `sh test.sh`
- Open and edit the src/main/scala/Level1Code.scala file. Use any code editor you are comfortable with.
- Test will re-execute on any code change.
- Press Ctrl-C to exit test monitor.
