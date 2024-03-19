LIBPATH := ../../lib
VPATH = $(LIBPATH)
export MONO_PATH = $(LIBPATH)
CODE = $(filter %.cs, $^)
LIBS = $(addprefix -reference:, $(filter %.dll, $^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)

Out.txt : main.exe
	mono main.exe > Out.txt

main.exe : Main.cs matrix.dll vector.dll Jacobi.dll ; $(MKEXE)

Jacobi.dll : Jacobi.cs matrix.dll vector.dll ; $(MKLIB)

clean :
	$(RM) *.dll *.exe *.txt