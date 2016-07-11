#!/bin/sh

# Find Java Executer
if [ -z "$JAVAEXE" ]; then JAVAEXE=$(which java); fi

# Find Scala Executer
if [ -z "$SCALAEXE" ]; then SCALAEXE=$(which scala); fi

# Find JavaScript Executer
if [ -z "$JSEXE" ]; then JSEXE=$(which js); fi
if [ -z "$JSEXE" ]; then JSEXE=$(which node); fi

# Find Mono Executer
if [ -z "$MONOEXE" ]; then MONOEXE=$(which mono); fi

# Find Java Compiler
if [ -z "$JAVAC" ]; then JAVAC=$(which javac); fi

# Find Scala Compiler
if [ -z "$SCALAC" ]; then SCALAC=$(which scalac); fi

# Find C# Compiler
if [ -z "$CSC" ]; then CSC=$(which mcs); fi

# Find SBT
if [ -z "$SBT" ]; then SBT=$(which sbt); fi

echo JAVAEXE=$JAVAEXE
echo SCALAEXE=$SCALAEXE
echo JSEXE=$JSEXE
echo MONOEXE=$MONOEXE
echo JAVAC=$JAVAC
echo SCALAC=$SCALAC
echo CSC=$CSC
echo SBT=$SBT

export JAVAEXE=$JAVAEXE
export SCALAEXE=$SCALAEXE
export JSEXE=$JSEXE
export MONOEXE=$MONOEXE
export JAVAC=$JAVAC
export SCALAC=$SCALAC
export CSC=$CSC
export SBT=$SBT


ERRS=0

if [ -z "$JAVAEXE" ]; then ERRS=$(expr $ERRS + 1) && echo Unable to find Java. Please make sure Java is installed.; fi
if [ -z "$SCALAEXE" ]; then ERRS=$(expr $ERRS + 1) && echo Unable to find Scala. Please make sure Scala is installed.; fi
if [ -z "$JSEXE" ]; then ERRS=$(expr $ERRS + 1) && echo Unable to find JavaScript. Please make sure Node is installed.; fi
if [ -z "$MONOEXE" ]; then ERRS=$(expr $ERRS + 1) && echo Unable to find Mono. Please make sure Mono is installed.; fi
if [ -z "$JAVAC" ]; then ERRS=$(expr $ERRS + 1) && echo Unable to find Java Compiler. Please make sure JDK is installed.; fi
if [ -z "$SCALAC" ]; then ERRS=$(expr $ERRS + 1) && echo Unable to find Scala Compiler. Please make sure Scala is installed.; fi
if [ -z "$CSC" ]; then ERRS=$(expr $ERRS + 1) && echo Unable to find C# Compiler. Please make sure Mono is installed.; fi
if [ -z "$SBT" ]; then ERRS=$(expr $ERRS + 1) && echo Unable to find SBT. Please make sure SBT is installed.; fi
if [ "$(expr $ERRS)" -gt "0" ]; then
    bash -c "read -n 1 -r -p \"Press any key to continue...\""
    echo;
fi

# Compile Test App
if [ ! -e bin ]; then mkdir bin; fi
if [ -e bin/test.exe ]; then rm bin/test.exe; fi
$CSC /nologo /out:bin/test.exe test.cs
mono bin/test.exe
