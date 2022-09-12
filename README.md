# Kitchen

The Kitchen has a finite order list . This order list is shared across all kitchen instances. All orders which kitchen
receives have to be added to a single instance of order-list .

Main work unit of the Kitchen are cooks . Their job is to take the order and "prepare" the menu item(s) from it, and return
the orders as soon and with as little idle time as possible. Kitchen can prepare foods from different orders and it is not
mandatory that one cook have to prepare entire order. Order is considered to be prepared when all foods from order list are
prepared.

Each cook has the following characteristics:

-   rank , which defines the complexity of the food that they can prepare (one caveat is that a cook can only take orders which
    his current rank or one rank lower that his current one):
    -   Line Cook ( rank = 1 )
    -   Saucier ( rank = 2 )
    -   Executive Chef (Chef de Cuisine) ( rank = 3 )
-   proficiency : it indicates on how may dishes he can work at once. It varies between 1 and 4 (and to follow a bit of logic, the
    higher the rank of a cook the higher is the probability that he can work on more dishes at the same time).
-   name
-   catch phrase

So a cook could have the following definition:

```json
{
    "rank": 3,
    "proficiency": 3,
    "name": "Gordon Ramsay",
    "catch-phrase": "Hey, panini head, are you listening to me?"
}
```

Get creative on where and when to use this precious information about the cooks.

Another requirement not for the faint of heart is to implement the cooking apparatus rule. It comprises of the fact that a
kitchen has limited space, thus a finite number of ovens, stoves and the likes.

Your kitchen configuration have to include a limited number of cooking apparatus . For example at kitchen with 3-4
cooks, we can have no more than 2 stoves and only one oven.

As you've noticed some menu items require one of these appliance and it's up to you to define what happens when a cook runs
into the problem of no available machinery.

You will have to define the mechanism that will decide which cook takes which order.
