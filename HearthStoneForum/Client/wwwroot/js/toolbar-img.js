
//覆盖MEditor工具栏中图片的点击事件
window.ChangeToolbarImage = (quillElement) => {
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

