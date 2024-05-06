LIBPATH := ../../lib
VPATH = src : $(LIBPATH) : data
PROJECT_DIRS = src data plots
export MONO_PATH = $(LIBPATH)
CODE = $(filter %.cs, $^)
LIBS = $(addprefix -reference:, $(filter %.dll, $^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)

.PHONEY : all clean directories

all : data/TestData.txt plots/Plot.svg

plots/Plot.svg : Plot.gpi TestData.txt ; gnuplot $<

data/TestData.txt : TestData.exe
	mono $< > $@

TestData.exe : ANNTest.cs ANN.dll vector.dll ; $(MKEXE)

ANN.dll : ANN.cs vector.dll Minimize.dll ; $(MKLIB)

directories : $(PROJECT_DIRS)

$(PROJECT_DIRS):
	@test -d $@ || mkdir -p $@

clean : 
	$(RM) *.exe *.dll data/* plots/*