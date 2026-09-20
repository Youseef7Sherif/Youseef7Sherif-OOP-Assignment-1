# Part 3 — Builder Pattern

## Task 3.1 — Questions

### 1. Why is a single 20-parameter constructor a problem in practice?

A constructor with around 20 parameters is difficult to read and use correctly. At the call site, it becomes hard to remember what each argument represents, especially when several parameters have the same type, such as multiple strings or decimal values. This increases the risk of passing values in the wrong order without getting a compile-time error.

It also becomes harder to maintain when new optional properties are added because the constructor signature keeps growing, and every call site may need to be updated.

### 2. Is this purely a "constructor is too long" problem?

No. The deeper problem is that the class contains several conceptually different responsibilities and loosely related data.

For example, billing and shipping addresses represent address information, while order date, payment method, currency, and financial amounts represent order and payment information.

Putting all of these concerns into one large class makes the class harder to understand, validate, maintain, and reuse. Grouping related data into smaller components provides better separation of responsibilities.
