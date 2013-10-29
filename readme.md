TF*IDF in C# .NET
=========

Tutorial
http://www.primaryobjects.com/CMS/Article157.aspx

## Motivation

During a recent machine learning competition, I struggled to find an example of working code in C# .NET that performed a TF*IDF transformation on a set of documents. For such a relatively simple mathematical formula, I had hoped there would be a library available for easy importing into a project. After a bit of searching, I decided to create my own TF*IDF transformation class, modeled after the Python scikit-learn library's method, TfidfVectorizer(). This class is based upon the formula described on Wikipedia and through the sources listed below.

## Description

TF*IDF = Term Frequency * Inverse Document Frequency

TFIDF is a way of representing a document, based upon its keywords holding values that represent their importance within the document. For a complete description of TFIDF, see http://en.wikipedia.org/wiki/Tf%E2%80%93idf

This example project includes the class TFIDF.cs for performing TF*IDF transformations on a set of documents in C# .NET, and returning the resulting list of vectors as a multi-dimensional array of doubles. Upon providing the class with a list of documents as strings, the class builds a vocabulary (skipping over stop words and stemming terms), and calculates the inverse document frequency (IDF) for each vocabulary term, against the total number of documents. The class then takes each word in the vocabulary and calculates the term frequency against each document. Finally, each term frequency is multiplied by the term's inverse document frequency to provide the TF*IDF score.

The class returns a matrix of doubles. Each row in the matrix represents a vectorized document (converted from string to TF*IDF values for each vocabulary term). Each column in the matrix represents a feature/term from the list of vocabulary words.

For example:

```
The sun in the sky is bright.
-0.405465108108164, 0, -0.405465108108164, 0, 0,

We can see the shining sun, the bright sun.
-0.810930216216329, 0, -0.405465108108164, 0, 0,
```

In the example above, the vocabulary consists of 5 terms (resulting in 2 rows and 5 columns in the matrix).

The class includes an optional method for normalizing the resulting vectors, using L2-norm: Xi = Xi / Sqrt(X0^2 + X1^2 + .. + Xn^2). Applying normalization to the above example produces the following result:

```
The sun in the sky is bright.
-0.707106781186547, 0, -0.707106781186547, 0, 0

We can see the shining sun, the bright sun.
-0.894427190999916, 0, -0.447213595499958, 0, 0
```

## Usage

```
string[] documents = LoadYourDocumentsHere();

double[][] inputs = TFIDF.Transform(documents);
inputs = TFIDF.Normalize(inputs);
```

## Sources

Overall TF*IDF description
http://en.wikipedia.org/wiki/Tf%E2%80%93idf

Simple description of TF and IDF math formulas with examples
http://r3dux.org/2012/10/how-to-count-word-occurences-in-a-string-or-file-using-csharp/

TF*IDF normalization via L2-Norm
http://pyevolve.sourceforge.net/wordpress/?tag=inverse-document-frequency

## License
Copyright (c) 2013 Kory Becker http://www.primaryobjects.com/kory-becker.aspx

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

## Author

Kory Becker
http://www.primaryobjects.com/kory-becker.aspx
