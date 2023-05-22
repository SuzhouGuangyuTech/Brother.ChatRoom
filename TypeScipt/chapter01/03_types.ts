// 字面量
let color: 'red' | 'green' | 'blue';

color = 'red';
console.log(color);

// 多类型 | 连接(联合类型)
let age: number | string;
age = "13";
age = 13;
console.log(age);

// unknown 实际上是一个类型安全的 any
// unknown 类型的变量，不能直接赋值给其他变量，需要进行类型检测
let notSure: unknown;
notSure = "albertzhao";

let studentName: string = "zhangsan";

if (typeof notSure === "string") {
    studentName = notSure;
}

// 类型断言
studentName = notSure as string;
studentName = <string>notSure;

let student: {
    name: string,
    age: number
}

student = { name: "zhangsan", age: 13 };