# Cryptography Core

## WARNING!

**If you are thinking about using any of this directly, you are (more likely than not) doing something wrong.**



### Don't Do These Things

On a scale of "don't do this" to "***DEFINITELY*** don't do this":

- Don't use anything in this library directly without a really good reason.
- Definitely don't use anything in it without the Cryptographic Tracking Service.
- *Definitely* don't use (symmetric/asymmetric) primitives directly without a box construction.
- ***Definitely*** don't use primitives without an in-depth understanding of the problems with them.
- ***DEFINITELY*** don't use fragile or broken primitives like RSA, DSA, MD5 or SHA-1 for anything whatsoever.
  - Implementations are included mostly to test migrations in case future cipher suites are broken.
  - We can truthfully say a construction is broken for the purpose of testing moving away from it.



### Do These Instead

Here's what you should do instead:

- Use a behavioural primitive for what you are trying to achieve.
- If you are building a new behavioural primitive, you can use the box constructions in this library, as well as some of the KDFs and hashes, however:
  - You should stick to the ones in SafeCryptoFactory (right now those are almost all libsodium); and
  - You will have to integrate it into the Cryptographic Tracking Service to allow oversight of the strength of the construction.



