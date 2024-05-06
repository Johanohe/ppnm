CODE = $(filter %.cs, $^)
LIBS = $(addprefix -reference:, $(filter %.dll, $^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)

matrix.dll : vector.dll matrix.cs matrix.extended.cs ; $(MKLIB)

vector.dll : vector.cs ; $(MKLIB)

QRGS.dll : QRGS.cs matrix.dll vector.dll; $(MKLIB)

Minimize.dll : Minimize.cs vector.dll matrix.dll QRGS.dll ; $(MKLIB)