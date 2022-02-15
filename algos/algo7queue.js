class Queue2 {
    constructor(items = []) {
        this.items = items;
    }

    enqueue(data) {
        return this.items.push(data)
    }

    isEmpty(){
        return this.items.length === 0 
    }

    dequeue(){
        return this.isEmpty()? null : this.items.shift()
    }

    size(){
        return this.items.length
    }

    front(){
        return this.isEmpty()? null : this.items[0]
    }
}



class Node {
    constructor(data) {
        this.data = data;
        this.next = null;
    }
}

class Queue {
    constructor(){
        this.head = null;
        this.tail = null;
        this.length = 0;
    }

    enqueue(data) {
        let newNode = new Node(data);
        if (this.isEmpty()) {
            this.head = newNode;
            this.tail = newNode;
            return ++this.length;
        }
        this.tail.next = newNode;
        this.tail = this.tail.next;
        return ++this.length;
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

    size() {
        return this.length;
    }

    front() {
        return this.head.data;
    }

    isEmpty() {
        return this.head === null;
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

let queue = new Queue();
queue.dequeue();
queue.enqueue(1);
queue.enqueue(2);
queue.enqueue(3);
queue.enqueue(4);
queue.enqueue(5);
queue.enqueue(6);
queue.enqueue(7);
queue.dequeue();


console.log(queue.size());
console.log(queue.front());
console.log(queue.toArr());


