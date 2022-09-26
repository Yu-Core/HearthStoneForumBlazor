export function CarouselStart() {

    var wrap = $("#carousel-wrap"),
        listwrap = $("#carousel-list"),
        pic = document.getElementById('carousel-pic').getElementsByTagName('li'),
        list = document.getElementById('carousel-list').getElementsByTagName('li'),
        index = 0,
        timer = null;

    // 定义并调用自动播放函数
    timer = setInterval(autoPlay, 2000);

    // 鼠标划过整个容器时停止自动播放
    wrap.on("mouseover",'div', function () {
        clearInterval(timer);
    })

    // 鼠标离开整个容器时继续播放至下一张
    wrap.on("mouseout",'div', function () {
        timer = setInterval(autoPlay, 2000);
    })

     // 实现划过切换至对应的图片
    listwrap.on("mouseover",'li', function () {
        clearInterval(timer);
                index = this.innerText - 1;
                changePic(index);
    })

    function autoPlay() {
        if (++index >= pic.length) index = 0;
        changePic(index);
    }

    // 定义图片切换函数
    function changePic(curIndex) {
        if (pic.length == 0 && list.length == 0) return;
        for (var i = 0; i < pic.length; ++i) {
            pic[i].style.display = "none";
            list[i].className = "";
        }
        pic[curIndex].style.display = "block";
        list[curIndex].className = "on";
    }

};