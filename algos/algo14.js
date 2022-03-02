/* 
Make double linked list classes and create these methods:

double linked list should allow traversing forwards and backwards starting
from either side.

isEmpty
insertAtFront
insertAtBack
insertAfter - given a target value and new value, inserts new node after target value
insertBefore - given a target value and new value, inserts new node before target value
*/


class Node {
    constructor(data) {
        this.data = data;
        this.next = null;
        this.previous = null;
    }
}

class DoubleLinkedList {
    constructor() {
        this.head = null;
        this.tail = null;
        this.length = 0;
    }
    // constructor(data) {
    //     let newNode = Node(data);
    //     this.head = newNode;
    //     this.tail = newNode;
    //     this.length = 1;
    // }

    IsEmpty() {
        return this.head === null;
    }

    Print() {
        let runner = this.head;
        while (runner != null) {
            console.log(runner.data);
            runner = runner.next;
        }
    }

    InsertEmpty(data) {
        let newNode = new Node(data);
        this.head = newNode;
        this.tail = newNode;
        this.length++;
    }

    insertAtFront(data) {
        if (this.IsEmpty()) {
            this.InsertEmpty(data);
        }
        else {
            let newNode = new Node(data);
            newNode.next = this.head;
            this.head = newNode;
            if (this.length == 1) {
                this.tail = this.head.next;
            }
            this.length++;
        }
    }

    insertAtBack(data) {
        if (this.IsEmpty()) {
            this.InsertEmpty(data);
        }
        else {
            let newNode = new Node(data);
            this.tail.next = newNode;
            newNode.previous = this.tail;
            this.tail = newNode;
            this.length++;
        }
    }


    // insertAfter - given a target value and new value, inserts new node after target value
    insertAfter(target, data) {

    }
}

let double = new DoubleLinkedList();
double.insertAtFront(1);
double.insertAtFront(1);
double.insertAtFront(1);
double.insertAtBack(2);
double.insertAtBack(2);
double.insertAtBack(2);
double.Print();