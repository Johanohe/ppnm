# Exam project 14 - Hessenberg factorization

## Main exercise

> Implement Hessenberg factorization of a square matrix using Jacobi transformations. 
Remember to accumulate the total transformation matrix. When multiplying with the J-matrices you should use your Jtimes and timesJ routines from Jacobi-eigenvalue homework that take O(n) operations.

Hessenberg factorization of a square matrix was implemented using Jacobi rotations in the file [Hessenberg.cs](src/Hessenberg.cs).
The implementation was tested on random 5x5 and 10x10 matrices, and random symmetric 5x5 matrices. One of the tests can be found in [Out.txt](data/Out.txt).

The implementation of the Jacobi rotations can be found in in [Jacobi.cs](../lib/Jacobi.cs).



## Extra exercises

### Which factorization is faster, Hessenberg or QR.

> Find out (by time measurements) which factorization is faster, Hessenberg or QR.

The time taken to do Hessenberg factorization and QR factorization was investigated by plotting the real time for the factorizations for different matrix sizes in [TimePlot.svg](plots/TimePlot.svg).
Using my implementations of Gram-Schmidt orthoginalization and Hessenberg factorization the scaling is worse for the Hessenberg method.

![image](plots/TimePlot.svg)

### QR-factorization of Hessenberg matrix

> Check if QR-factorization of an upper Hessenberg matrix using Givens rotations can be done in O(n²) operations.

- Using givens rotations on a matrix that is already in the Hessenberg form allows us to only target the elements below the sup-diagonal.
- A givens rotation only operates on at most 2 rows (of size n), and the cost of each rotation will be O(n).
- We can apply n-1 Givens rotations to transform the Hessenberg matrix to a triangular form.
- This leads to an overall O(n²) operations.

### Clever application of Jacobi eigenvalue algorithm

> Check if Jacobi eigenvalue algorithm applied cleverly (eigenvalue-by-eigenvalue, and don't zero the elements that are already zero) to a tridiagonal matrix takes O(n) operations.

 - By having the initial matrix in a tridiagonal form one can reduce the number of operations for a sweep. The normal cyclic Jacobi eigenvalue algorithm needs O(n³) operations for a sweep and converges after a small number of sweeps.
 - The algorithm works by applying Jacobi rotations that zeros pairs of off-diagonal elements. By applying the roations along the diagonal of the tridiagonal matrix, and since after a Jacobi rotation the sums of squares of all the off-diagonal elements are reduced, this alows us to find all eigenvalues in O(n²) operations. However, in practice, convergence for a small number of dominant eigenvalues can happen much faster, which effectively reduces the complexity to O(n) for finding the most important eigenvalues.