# Cryptography Core

The Cryptography Core is a simple, modular system for accessing encryption primitives and constructions.



This module is designed around the idea that any cryptographic function will either return the correct data, or null. It should not throw exceptions or give any other detail that something is wrong.

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



## Safe Usage

### Simplest Way To Create Instances

1. Import the Cryptography DLL and any plugins you want (Cryptography.LibSodium is probably a good idea).
2. Use Cryptography.SafeCryptoFactory methods to create whatever construction you need. Each construction works differently. These ones are misuse-resistant and meet the industry standard of security.

### Hashes

These algorithms generate a short fingerprint of the provided piece of data.

Create your instance, then:

`byte[] output = instance.hash(input);`

That's all there is to it.

The hash algorithms in the safe list are resistant to length extension attacks.

### MACs

Exactly the same as hashes, except they have a secret key as well. Small changes to the secret key completely change the output, and it is difficult to guess the secret key from the output.

`byte[] output = instance.generate(input, key);`

In every other way these work like hashes.

### KDFs

These are used to turn small amounts of data into encryption keys, like for passwords.

These functions are usually deliberately slow to make bruteforcing a difficult proposition.

First you generate a salt:

`byte[] salt = instance.generateSalt();`

Now it just works like a MAC except slower:

`byte[] output = instance.generate(password, salt);`

Do not create your own salt. Use generateSalt().

### Asymmetric Boxes

Asymmetric boxes allow two parties to send each other messages securely while knowing only the other party's public keys.

First, you generate a nonce:

`byte[] nonce = instance.generateNonce();`

This is non-secret and must be shared with both parties.

Each party then generates a key pair:

`var myKeys = instance.generateKeyPair();`

They then send each other their public keys.

We can then encrypt data:

`byte[] encrypted = instance.encrypt(theData, myKeys.privateKey, theirPublicKey, nonce);`

We send it to the other party.

They can then decrypt it:

`byte[] decrypted = instance.decrypt(encrypted, theirKeys.privateKey, myPublicKey, nonce);`

### Symmetric Boxes

Symmetric boxes allow two parties to send each other authenticated messages securely based on a shared secret key.

We first generate the secret key:

`byte[] key = instance.generateKey();`

We can encrypt data:
`byte[] encrypted = instance.encrypt(data, key);`

And decrypt it:

`byte[] decrypted = instance.decrypt(encrypted, key);`

## Unsafe Usage

This library does other things, but I am not encouraging this behaviour. Stick to what's in this README.

