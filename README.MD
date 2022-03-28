
# Features / Settings

The whole idea behind this program is to provide a convenient, script-free way to take a word embedding model (e.g., a pretrained GloVE model, a word2vec model, etc.) and explore semantic similarities.

- Interested in doing Garten et al.’s (2017) DDR method? This software can give you the average vector of user-supplied words. Then, you can use a program like TAPA to calculate a text’s similarity to your average vector.
- Looking to build a new dictionary, but not sure where to start? Using WELP, you can get lists of semantically similar words to help build your LIWC dictionary using the magic of SCIENCE rather than just your own intuition.

This software isn’t anything special — more of a convenience item, really, for people who don’t have a lot of experience with R or python, but still want to be able to check out word embeddings. There’s really nothing else to it beyond that, so… WELP.

## How to Use

First, you’ll want to load up your pre-trained word embedding model. I have some available as TAPA dictionaries, located here, but you can use any ones that you want with this software, so long as you’ve formatted them as a table. Select your “Model File” (which should be contained in a CSV, TSV, or TXT file),  and make sure that it’s loading up correctly using the preview. Tweak/change the Options for Reading Data File until your preview looks accurate.

From there, make sure that you select which column in your data file contains the words or “tokens” that you want to explore using the Token Column dropdown menu. Make sure that you specify the starting/ending columns of your vectors as well.

Lastly, make sure to type in your Seed Word List to contain any concept that you want to include. These should, in theory, be semantically similar, like a list of emotion words, or a list of business-related terms.

Note: You can also include multiple lists at once by separating them with an extra linebreak. For example:

    happy
    wonderful
    joyous

    sad
    terrible
    awful

    angry
    furious
    livid

In this example, WELP will go through the same process, but for each cluster of words separately. This is extremely useful for calculating average vectors / exploring word similarities for multiple word clusters at once.

Once you’re ready, click Start! and kick back, relax, and let WELP do the rest. Once it’s done, you should be provided with 5 output files:

1. Your original seed word list
2. A list of which Seed Words were found (or were not found) in your pre-trained model.
3. A file that contains the vectors for each of the seed words included in your list.
4. A file that contains the average vector of all found seed word clusters.
5. A CSV file containing the semantic similarity between your average vector and each token’s vector contained in your pre-trained model.

It’s as simple as that!
