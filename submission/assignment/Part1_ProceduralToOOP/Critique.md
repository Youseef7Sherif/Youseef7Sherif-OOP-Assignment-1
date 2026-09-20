# Critique of the Procedural Order System

The program works, but its design has several problems that make it harder to maintain and extend.

## 1. Global State

The program stores customers, products, and orders in global variables and arrays.

For example:

```cpp
int customerCount = 0;
int customerIds[MAX_CUSTOMERS];
string customerNames[MAX_CUSTOMERS];
```

**Problem:** Any function can directly modify this shared state.

**Risk:** Changes made in one function can accidentally affect other parts of the system.

**OOP improvement:** Move the data and related behavior into classes such as `Customer`, `Product`, and `Order`.

---

## 2. Parallel Arrays

Customer data is stored in separate arrays:

```cpp
customerIds[i]
customerNames[i]
customerEmails[i]
customerCities[i]
customerIsVip[i]
```

**Problem:** One customer is represented by several arrays that must always use the same index.

**Risk:** An indexing mistake could associate data with the wrong customer.

**OOP improvement:** Represent each customer as a `Customer` object containing all of its data.

---

## 3. Relationships Use Indexes

Orders store customer and product relationships using indexes:

```cpp
orderCustomerIndexes
lineProductIndexes
```

**Problem:** The relationship between objects is represented by integer indexes instead of actual objects.

**Risk:** The relationships are harder to understand and can become invalid if the underlying arrays change.

**OOP improvement:** Let `Order` reference a `Customer`, and let `OrderLine` reference a `Product`.

---

## 4. Lack of Encapsulation

Important state such as:

```cpp
orderIsPaid
productStock
productPrices
```

can be accessed and modified directly.

**Problem:** There is no protection around important data or business rules.

**Risk:** A function could change an order or product to an invalid state.

**OOP improvement:** Keep important fields private and expose controlled methods for valid state changes.

---

## 5. Business Rules Are Scattered

Order rules are spread across functions such as `addLineToOrder()`, `markOrderPaid()`, and `calculateOrderTotal()`.

**Problem:** The `Order` behavior is not contained in one place.

**Risk:** A new function might modify an order without applying all the required rules.

**OOP improvement:** Put order-related behavior inside the `Order` class and let it enforce its own rules.

---

## 6. Fixed-Size Arrays

The system uses fixed limits:

```cpp
MAX_CUSTOMERS = 50
MAX_PRODUCTS = 50
MAX_ORDERS = 100
```

**Problem:** The system cannot grow beyond these limits.

**Risk:** New customers, products, or orders cannot be added once the limits are reached.

**OOP improvement:** Use appropriate C# collections such as `List<T>`.

---

## 7. Functions Have Multiple Responsibilities

`addLineToOrder()` searches for objects, validates data, checks stock, updates stock, and adds an order line.

**Problem:** One function handles several responsibilities.

**Risk:** The function becomes harder to understand, test, and modify.

**OOP improvement:** Move responsibilities to the classes that own the related data.

---

## Conclusion

The main issue is that the program's data, relationships, and business rules are spread across global variables, arrays, indexes, and procedural functions.

Using classes such as `Customer`, `Product`, `Order`, and `OrderLine`, together with encapsulation and object references, would make the system easier to maintain, extend, and protect from invalid state.
