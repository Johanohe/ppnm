LIBPATH := ../../lib
VPATH = src : $(LIBPATH) : data
PROJECT_DIRS = src data plots
export MONO_PATH = $(LIBPATH)
CODE = $(filter %.cs, $^)
LIBS = $(addprefix -reference:, $(filter %.dll, $^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)

.PHONEY : all clean directories

all : plots/Plot.svg data/DataTry.txt

plots/Plot.svg : Plot.gpi Data.txt ; gnuplot $<

data/Data.txt : Data.exe
	mono $< > $@

data/DataTry.txt : DataTry.exe
	mono $< > $@

Data.exe : Data.cs MonteCarlo.dll vector.dll ; $(MKEXE)

DataTry.exe : DataTry.cs MonteCarlo.dll vector.dll ; $(MKEXE)

MonteCarlo.dll : MonteCarlo.cs vector.dll ; $(MKLIB)

directories : $(PROJECT_DIRS)

$(PROJECT_DIRS):
	@test -d $@ || mkdir -p $@

clean : 
	$(RM) *.exe *.dll data/* plots/*