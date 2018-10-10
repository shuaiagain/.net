//1.问aa.name是什么（考的是构造函数有返回值且返回值是对象）
function Test() {

    this.name = 'one';
    return {
        name: 'two'
    };
}

var aa = new Test();
aa.name;

//2.a.name是什么（考察js对象实例和原型的关系，原型的重写）;
function Man() {

}

Man.prototype = {
    info: function (name) {
        this.name = name;
    }
}

var a = new Man('jack');
a.name;

// 3.简述什么是闭包

