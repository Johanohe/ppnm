LIBPATH := ../lib
VPATH = src : $(LIBPATH) : data
PROJECT_DIRS = src data plots
export MONO_PATH = $(LIBPATH)
CODE = $(filter %.cs, $^)
LIBS = $(addprefix -reference:, $(filter %.dll, $^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)
TIME = time --output=$@ --append --format "$$matrixSize %e"

.PHONEY : all clean directories

all : data/Out.txt plots/TimePlot.svg

plots/TimePlot.svg : Time.gpi data/HessenbergTime.txt data/QRGSTime.txt; gnuplot $<

data/Out.txt : HessenbergTest.exe
	mono $< > $@

data/HessenbergTime.txt : HessenbergTime.exe
	$(RM) $@
	for matrixSize in 2 10 100 200 300 400 500 600; do\
		$(TIME) mono HessenbergTime.exe -matrixSize:$$matrixSize;\
		done

data/QRGSTime.txt : QRGSTime.exe
	$(RM) $@
	for matrixSize in 2 10 100 200 300 400 500 600; do\
		$(TIME) mono QRGSTime.exe -matrixSize:$$matrixSize;\
		done

HessenbergTime.exe : HessenbergTime.cs Hessenberg.dll matrix.dll vector.dll ; $(MKEXE)

QRGSTime.exe : QRGSTime.cs Hessenberg.dll QRGS.dll matrix.dll vector.dll ; $(MKEXE)

HessenbergTest.exe : HessenbergTest.cs Hessenberg.dll matrix.dll vector.dll; $(MKEXE)

Hessenberg.dll : Hessenberg.cs matrix.dll Jacobi.dll ; $(MKLIB)

directories : $(PROJECT_DIRS)

$(PROJECT_DIRS):
	@test -d $@ || mkdir -p $@

clean : 
	$(RM) *.exe *.dll data/* plots/*