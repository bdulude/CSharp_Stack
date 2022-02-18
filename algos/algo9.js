/* 
- Create enqueue and dequeue methods. _You can loop and index the underlying array._
- Design a new PriorityQueue class where the queue maintains an ascending order when items are added based on a queue item's provided priority integer value. A priority value of 1 is most important which means it should be at the front of the queue, the first to be dequeued.
- A priority queue item could be any data type.
*/

class ListNode {
    /**
     * Constructs a new Node instance. Executed when the 'new' keyword is used.
     * @param {any} data The data to be added into this new instance of a Node.
     *    The data can be anything, just like an array can contain strings,
     *    numbers, objects, etc.
     * @returns {ListNode} This new Node instance is returned automatically without
     *    having to be explicitly written (implicit return).
     */

    constructor(data, level = 3) {
        this.data = data;
        /**
         * This property is used to link this node to whichever node is next
         * in the list. By default, this new node is not linked to any other
         * nodes, so the setting / updating of this property will happen sometime
         * after this node is created.
         *
         * @type {ListNode|null}
         */
        this.level = level;
        this.next = null;
    }
}


class PriorityQueue {

    constructor() {
        this.head == null;
        this.tail = null;
        this.length = 0;
    }

    isEmpty() {
        return this.length === 0;
    }


    enqueue(data) {
        let newNode = new ListNode(data, 3);
        if (this.isEmpty()) {
            this.head = newNode;
            this.tail = newNode;
            return ++this.length;
        }
        this.tail.next = newNode;
        this.tail = this.tail.next;
        return ++this.length;
    }

    priorityEnqueue(data, level = 3) {
        let newNode = new ListNode(data, level);
        if (this.isEmpty()) {
            this.head = newNode;
            this.tail = newNode;
            return ++this.length;
        }
        let runner = this.head;
        let chaser = this.head;
        // console.log(runner);
        while (runner != null && runner.level < newNode.level) {
            // console.log(runner);
            // if (runner != this.head){
            //     chaser = runner;
            // }
            chaser = runner;
            runner = runner.next;
        }
        console.log('****************');
        console.log("Chaser: ");
        console.log(chaser);
        console.log("Runner: ");
        console.log(runner);
        if (chaser != this.head) {
            console.log('chaser not head');
            chaser.next = newNode;
            newNode.next = runner;
            return ++this.length;
        }
        else {
            console.log('chaser head');
            newNode.next = this.head;
            this.head = newNode;
            return ++this.length;
        }
    }

    dequeue() {
        if(!this.isEmpty()){
            let data = this.head.data;
            this.head = this.head.next;
            this.length -= 1;
            return data;
        }
        return null;
    }

    toArr() {
        const arr = [];
        let runner = this.head;

        while (runner) {
            arr.push(runner.data);
            runner = runner.next;
        }
        return arr;
    }
}

let queue = new PriorityQueue();
queue.enqueue(1);
queue.enqueue(2);
queue.enqueue(3);
queue.enqueue(4);
queue.enqueue(5);
queue.priorityEnqueue(6, 1);
queue.priorityEnqueue(7, 2);

console.log(queue.toArr());
queue.dequeue();
console.log(queue.toArr());






