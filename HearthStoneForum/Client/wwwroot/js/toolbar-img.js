
//覆盖MEditor工具栏中图片的点击事件
window.ChangeToolbarImage = (quillElement) => {
    //实在没办法了，只能用setTimeout延迟了
    setTimeout(() => {
        window.quillobj = quillElement.__quill;

        var toolbar = window.quillobj.getModule('toolbar');
        toolbar.addHandler('image', onClickImage);

        function onClickImage() {
            window.quillselection = window.quillobj.getSelection(true);
            window.openPostImage();
        }
    }, 200);
    
}

