LIBPATH := ../../lib
VPATH = src : $(LIBPATH) : data
PROJECT_DIRS = src data plots
export MONO_PATH = $(LIBPATH)
CODE = $(filter %.cs, $^)
LIBS = $(addprefix -reference:, $(filter %.dll, $^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)

.PHONEY : all clean directories

all : data/TestData.txt plots/HiggsPlot.svg

plots/HiggsPlot.svg :  HiggsPlot.gpi HiggsFitData.txt HiggsData.txt
	gnuplot $<

data/TestData.txt : TestData.exe
	mono $< > $@

data/HiggsFitData.txt : HiggsBoson.exe;
	mono $< < HiggsData.txt 1> $@

HiggsBoson.exe : HiggsBoson.cs Minimize.dll vector.dll ; $(MKEXE)

TestData.exe : TestData.cs Minimize.dll vector.dll ; $(MKEXE)

Minimize.dll : Minimize.cs vector.dll matrix.dll QRGS.dll ; $(MKLIB)

directories : $(PROJECT_DIRS)

$(PROJECT_DIRS):
	@test -d $@ || mkdir -p $@

clean : 
	$(RM) *.exe *.dll data/* plots/*