LIBPATH := ../../lib
VPATH = $(LIBPATH)
export MONO_PATH = $(LIBPATH)
CODE = $(filter %.cs, $^)
LIBS = $(addprefix -reference:, $(filter %.dll, $^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)

Out.txt : main.exe
	mono main.exe > $@

main.exe : Main.cs QRGS.dll matrix.dll vector.dll; $(MKEXE)

QRGS.dll : QRGS.cs matrix.dll vector.dll; $(MKLIB)

clean : ; $(RM) Out* *.dll *.exe