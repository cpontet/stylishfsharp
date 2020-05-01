# British Railway

## Context

The British Railway distances are measured in *miles*, *chains* and *yards*.

* 1 mile = 1760 yards
* 1 chain = 22 yards
* 1 yard = 0.9144 meter

When representing distances in *miles* and *yards*, the British Railway system uses a dotted notation `wholemiles.yards` where
* `wholemiles` is an `integrer` representing the number of whole miles
* `yards` is an `integer` representing the fraction of a *mile* in expressed in *yards*, comprised betwee `0` and  `1759`.

## Exercice

Create some code that easily allow to 
1. Represent the *miles and yards* distance from the `wholemiles.yards` notation making sure that the value boundaries are respected.
2. Convert *miles and yards* to a decimal metric distance
3. Add *miles and yards* distances together
```
   wholemiles.yards + wholemiles.yards + wholemiles.yards -> wholemiles.yards
```
4. Represent the *miles and chains* distance from two `integer` values `miles` and `chains` making sure that the value boundaries are respected.
5. Convert *miles and chains* to a decimal metric distance
6. Convert *miles and yards* to *miles and chains* and vice versa
7. Add *miles and yards* and *miles and chains* together

Make the code as clean as possible and don't forget to test it.