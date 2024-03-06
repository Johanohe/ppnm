CODE = $(filter %.cs, $^)
LIBS = $(addprefix -reference:, $(filter %.dll, $^))
MKEXE = mcs -target:exe -out:$@ $(LIBS) $(CODE)
MKLIB = mcs -target:library -out:$@ $(LIBS) $(CODE)
TIME = time --output=$@ --append --format "$$nthreads %e %U"

Exercise : Out.times.svg out.timesParallelfor.txt out.timesPart3.txt

Out.times.svg : out.times.txt Makefile
	echo  '\
		set terminal svg background "white" ;\
		set out "$@" ;\
		set xlabel "number of threads" ;\
		set ylabel "real time" ;\
		set title "Running time as function of number of threads" ;\
		plot "$<" with lp ;\
		' | tee log.gpi | gnuplot

N = 1e9
out.times.txt : main.exe
	$(RM) $@
	for nthreads in 1 2 3 4 5 6 7 8 9 10; do\
		$(TIME) mono main.exe -nthreads:$$nthreads -nterms:$(N);\
		done

out.timesParallelfor.txt : mainParallelfor.exe Makefile
	$(RM) $@
	$(TIME) mono mainParallelfor.exe >> $@ -nterms:$(N)

out.timesPart3.txt : mainPart3.exe Makefile
	$(RM) $@
	$(TIME) mono mainPart3.exe >> $@ -nterms:$(N)

main.exe : main.cs ; $(MKEXE)

mainParallelfor.exe : mainParallelfor.cs ; $(MKEXE)

mainPart3.exe : mainPart3.cs ; $(MKEXE)

clean: 
	$(RM) *.txt *.svg *.exe
