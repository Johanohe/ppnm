LIBPATH := ../../lib
VPATH = src : $(LIBPATH) : data
PROJECT_DIRS = src data plots
export MONO_PATH = $(LIBPATH)
CODE = $(filter %.cs, $^)
LIBS = $(addprefix -reference:, $(filter %.dll, $^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)

.PHONEY : all clean

all : plots/Plot.svg data/Test.txt

plots/Plot.svg : Plot.gpi Data.txt ; gnuplot $<

data/Data.txt : Data.exe ; mono $< > $@

data/Test.txt : Test.exe ; mono $< > $@

Data.exe : Data.cs Integral.dll vector.dll ; $(MKEXE)

Test.exe : Test.cs Integral.dll ; $(MKEXE)

Integral.dll : Integral.cs ; $(MKLIB)

directories : $(PROJECT_DIRS)

$(PROJECT_DIRS):
	@test -d $@ || mkdir -p $@

clean : 
	$(RM) *.exe *.dll data/* plots/*