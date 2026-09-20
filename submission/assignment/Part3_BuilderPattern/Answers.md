# Part 3 — Builder Pattern

## Task 3.1 — Questions

### 1. Why is a single 20-parameter constructor a problem in practice?

A constructor with around 20 parameters is difficult to read and use correctly. At the call site, it becomes hard to remember what each argument represents, especially when several parameters have the same type, such as multiple strings or decimal values. This increases the risk of passing values in the wrong order without getting a compile-time error.

It also becomes harder to maintain when new optional properties are added because the constructor signature keeps growing, and every call site may need to be updated.

### 2. Is this purely a "constructor is too long" problem?

No. The deeper problem is that the class contains several conceptually different responsibilities and loosely related data.

For example, billing and shipping addresses represent address information, while order date, payment method, currency, and financial amounts represent order and payment information.

Putting all of these concerns into one large class makes the class harder to understand, validate, maintain, and reuse. Grouping related data into smaller components provides better separation of responsibilities.

## Task 3.3 — Why Is the Composed Version Better?

The composed version is better than a single large builder because each builder has a clear and focused responsibility.

### 1. Single Responsibility

`AddressBuilder` is responsible only for building and validating addresses, while `OrderBuilder` is responsible for order and payment information. `InvoiceBuilder` only composes these parts into the final invoice.

This makes each builder easier to understand and maintain.

### 2. Independent Validation

Each builder can validate its own data independently.

For example, `AddressBuilder` validates that all address fields are provided, while `OrderBuilder` validates the required order and payment information.

This keeps validation rules close to the data they belong to.

### 3. Reuse

`AddressBuilder` can be reused for both the billing address and the shipping address without duplicating the address-building logic.

The same builder can also be reused in other parts of the application that need to create an `Address`.

### 4. Readability

The composed approach makes the construction process easier to read because related properties are grouped together.

Instead of one large builder containing many unrelated methods, the code clearly separates address information from order and payment information and then combines them through `InvoiceBuilder`.
