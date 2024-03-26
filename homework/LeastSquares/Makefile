LIBPATH := ../../lib
VPATH = src : $(LIBPATH) : data
PROJECT_DIRS = src data plots
export MONO_PATH = $(LIBPATH)
CODE = $(filter %.cs, $^)
LIBS = $(addprefix -reference:, $(filter %.dll, $^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)

.PHONEY : plot clean all

all : plot data/HalfLife.txt

plot : plots/Plot.svg

directories : $(PROJECT_DIRS)

$(PROJECT_DIRS):
	@test -d $@ || mkdir -p $@

plots/Plot.svg : Plot.gpi Data.txt TestData.txt
	gnuplot $<

data/Data.txt : main.exe
	mono main.exe > $@

data/HalfLife.txt : HalfLife.exe
	mono $< > $@

HalfLife.exe : HalfLife.cs LeastSquares.dll matrix.dll vector.dll ; $(MKEXE)

main.exe : Main.cs vector.dll matrix.dll LeastSquares.dll ; $(MKEXE)

LeastSquares.dll : LeastSquares.cs vector.dll matrix.dll QRGS.dll ; $(MKLIB)

clean :
	$(RM) plots/* data/* *.exe *.dll