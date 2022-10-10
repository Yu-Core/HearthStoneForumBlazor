var postimage = postimage || {};
postimage.output = function (i, res, co) {
    var w;
    if (co && opener != null) {
        w = opener;
    } else {
        w = window;
    }
    //var area = w.document.querySelector('[data-postimg="' + i + '"]');
    var url = "";
    if (res.indexOf("[img]") != -1 && res.indexOf("[/img]") != -1)  {
        url = res.split("[img]")[1].split("[/img]")[0];
    }
    
    //调用insertEmbed 将图片插入到编辑器
    if (url.length > 0) {
        w.quillobj.insertEmbed(w.quillselection.index, "image", url);
    }
    /*area.value = area.value + res;*/
    if (co && opener != null) {
        opener.focus();
        window.close();
    }
}
    ;
postimage.insert = function (area, container) {
    if (area.nextSibling) {
        area.parentNode.insertBefore(container, area.nextSibling);
    } else {
        area.parentNode.appendChild(container);
    }
}
    ;
var postimage = postimage || {};
function rand_string(length) {
    var str = "";
    var possibles = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
    for (var i = 0; i < length; i++)
        str += possibles.charAt(Math.floor(Math.random() * possibles.length));
    return str;
}
if (typeof postimage.ready === "undefined") {
    postimage.opt = postimage.opt || {};
    postimage.opt.mode = postimage.opt.mode || "zetaboards";
    postimage.opt.host = postimage.opt.host || "postimages.org";
    postimage.opt.skip = postimage.opt.skip || "recaptcha|username_list|search|recipients|coppa";
    postimage.opt.tarClass = postimage.opt.tarClass || "ql-editor";
    postimage.opt.lang = "english";
    postimage.opt.code = "thumb";
    postimage.opt.content = "";
    postimage.opt.hash = postimage.opt.hash || "1";
    postimage.opt.customtext = postimage.opt.customtext || "";
    postimage.dz = [];
    postimage.windows = {};
    postimage.session = "";
    postimage.gallery = "";
    postimage.previous = 0;
    postimage.resp = null;
    postimage.dzcheck = null;
    postimage.dzimported = false;
    postimage.dragcounter = 0;
    postimage.style = postimage.style || {};
    postimage.style.link = postimage.style.link || {
        "color": "#3a80ea",
        "vertical-align": "middle",
        "font-size": "1em"
    };
    postimage.style.icon = postimage.style.icon || {
        "vertical-align": "middle",
        "margin-right": "0.5em",
        "margin-left": "0.5em"
    };
    postimage.style.container = postimage.style.container || {
        "margin-bottom": "0.5em",
        "margin-top": "0.5em"
    };
    postimage.text = {
        "afrikaans": "Add image to post",
        "arabic": "أضف الصورة للموضوع",
        "armenian": "Add image to post",
        "azerbaijani": "Add image to post",
        "bangla": "Add image to post",
        "bosnian": "Dodaj sliku u objavu",
        "burmese": "Add image to post",
        "bulgarian": "Добавете изображение",
        "catalan": "Afegeix una imatge a la publicació",
        "welsh": "Ychwanegu llun i sylw",
        "chinese_traditional": "添加圖片上傳",
        "chinese_simplified": "添加图片以上传",
        "croatian": "Dodaj sliku u objavu",
        "czech": "Přidej obrázek do článku",
        "danish": "Tilføj billede for at sende",
        "dutch": "Afbeelding aan bericht toevoegen",
        "english": "Add image to post",
        "estonian": "Lisa pilt postitusse",
        "basque": "Gehitu Irudiak",
        "finnish": "Lisää viestiin kuva",
        "french": "Ajouter une image au message",
        "georgian": "ფოტოს დამატება პოსტისთვის",
        "german": "Bild hinzufügen",
        "greek": "Προσθήκη εικόνας προς δημοσίευση",
        "gujarati": "Add image to post",
        "hebrew": "Add image to post",
        "hindi": "Add image to post",
        "hungarian": "Add image to post",
        "indonesia": "Menambahkan gambar ke posting",
        "icelandic": "Add image to post",
        "italian": "Aggiungi immagine al messaggio",
        "japanese": "포스트에 이미지 추가",
        "kazakh": "Add image to post",
        "khmer": "Add image to post",
        "korean": "Add image to post",
        "kurdish": "‎باركردنی وێنه‌",
        "kyrgyz": "Add image to post",
        "lao": "Add image to post",
        "latvian": "Pievienot attēlu Post",
        "lithuanian": "Add image to post",
        "macedonian": "Add image to post",
        "malay": "Add image to post",
        "marathi": "Add image to post",
        "mongolian": "Add image to post",
        "nepali": "Add image to post",
        "norwegian": "Add image to post",
        "panjabi": "Add image to post",
        "persian": "افزودن عکس به نوشته",
        "polish": "Dodaj zdjęcie do wiadomości",
        "portuguese_brazil": "Adicionar imagem à mensagem",
        "portuguese": "Adicionar imagem à mensagem",
        "romanian": "Adaugă imagine pentru postare",
        "russian": "Добавить картинку в сообщение",
        "serbian": "Додај слику у поруку",
        "serbian_lat": "Dodaj sliku u poruku",
        "slovak": "Pridať obrázok do príspevku",
        "slovenian": "Dodaj sliko v sporočilo",
        "spanish_america": "Insertar una imagen",
        "spanish": "Insertar una imagen",
        "swahili": "Add image to post",
        "swedish": "Lägg till bild på inlägg",
        "tagalog": "Magdagdag o idagdagin ang larawan o imahe sa post",
        "tajik": "Add image to post",
        "thai": "ใส่ภาพเข้าไปในโพส",
        "tamil": "Add image to post",
        "telugu": "Add image to post",
        "tibetan": "Add image to post",
        "turkish": "Temel Resim Yükleme Modu",
        "turkmen": "Add image to post",
        "ukrainian": "Додати картинку в повідомлення",
        "uyghur": "Add image to post",
        "uzbek": "Add image to post",
        "urdu": "Add image to post",
        "vietnam": "Add image to post",
        "zulu": "Add image to post"
    };
    if (typeof postimage_customize == "function") {
        postimage_customize();
    }
    postimage.ts = new Date();
    postimage.ui = "";
    postimage.ui += typeof screen.colorDepth != "undefined" ? screen.colorDepth : "?";
    postimage.ui += typeof screen.width != "undefined" ? screen.width : "?";
    postimage.ui += typeof screen.height != "undefined" ? screen.height : "?";
    postimage.ui += typeof navigator.cookieEnabled != "undefined" ? "true" : "?";
    postimage.ui += typeof navigator.systemLanguage != "undefined" ? navigator.systemLanguage : "?";
    postimage.ui += typeof navigator.userLanguage != "undefined" ? navigator.userLanguage : "?";
    postimage.ui += typeof postimage.ts.toLocaleString == "function" ? postimage.ts.toLocaleString() : "?";
    postimage.ui += typeof navigator.userAgent != navigator.userAgent ? navigator.userAgent : "?";
    postimage.skip = new RegExp(postimage.opt.skip, "i");
    var scripts = document.getElementsByTagName("script");
    for (var i = 0; i < scripts.length; i++) {
        var script = scripts[i];
        if (script.src && script.src.indexOf("postimage") !== -1) {
            var options = script.getAttribute("src").split("/")[3].replace(".js", "").split("-");
            for (var j = 0; j < options.length; j++) {
                if (options[j] === "hotlink") {
                    postimage.opt.code = "hotlink";
                } else if (options[j] === "adult") {
                    postimage.opt.content = "adult";
                } else if (options[j] === "family") {
                    postimage.opt.content = "family";
                } else if (postimage.text.hasOwnProperty(options[j])) {
                    postimage.opt.lang = options[j];
                }
            }
        }
    }
    if (postimage.text.hasOwnProperty(postimage.opt.lang)) {
        postimage.text = postimage.text[postimage.opt.lang];
    } else {
        postimage.text = postimage.text["default"];
    }
    if (postimage.opt.customtext != "") {
        postimage.text = postimage.opt.customtext;
    }
    (function () {
        var match, plus = /\+/g, search = /([^&=]+)=?([^&]*)/g, decode = function (s) {
            return decodeURIComponent(s.replace(plus, " "));
        }, query = postimage.opt.hash == "1" ? window.location.hash.substring(1) : window.location.search.substring(1);
        postimage.params = {};
        while (match = search.exec(query)) {
            postimage.params[decode(match[1])] = decode(match[2]);
        }
    }
    )();
    window.addEventListener('message', function (e) {
        var regex = new RegExp('^' + ('https://' + postimage.opt.host).replace(/\./g, '\\.').replace(/\//g, '\\/') + '$', 'i');
        if (!regex.test(e.origin) && (typeof e.data.id == typeof undefined || typeof e.data.message == typeof undefined)) {
            return;
        }
        ; var id = e.data.id;
        if (!id || e.source !== postimage.windows[id].window) {
            return;
        }
        postimage.output(id, decodeURIComponent(e.data.message), false);
        var area = document.querySelector('[data-postimg="' + id + '"]');
        if (area) {
            var events = ['blur', 'focus', 'input', 'change', 'paste'];
            for (var i = 0; i < events.length; i++) {
                var event = new Event(events[i]);
                area.dispatchEvent(event);
            }
        }
    }, false);
}
postimage.style.apply = function (obj, style) {
    for (var s in style) {
        if (!style.hasOwnProperty(s)) {
            continue;
        }
        obj.style[s] = style[s];
    }
}
    ;
postimage.serialize = function (obj, prefix) {
    var q = [];
    for (var p in obj) {
        if (!obj.hasOwnProperty(p)) {
            continue;
        }
        var k = prefix ? prefix + "[" + p + "]" : p
            , v = obj[p];
        q.push(typeof v == "object" ? serialize(v, k) : encodeURIComponent(k) + "=" + encodeURIComponent(v));
    }
    return q.join("&");
}
    ;
postimage.upload = function (areaid) {
    console.log("");
    var params = {
        "mode": postimage.opt.mode,
        "areaid": areaid,
        "hash": postimage.opt.hash,
        "pm": "1",
        "lang": postimage.opt.lang,
        "code": postimage.opt.code,
        "content": postimage.opt.content,
        "forumurl": encodeURIComponent(document.location.href)
    };
    if (typeof SECURITYTOKEN != "undefined") {
        params["securitytoken"] = SECURITYTOKEN;
    }
    var self = postimage;
    params = postimage.serialize(params);
    if (typeof postimage.windows[areaid] !== typeof undefined) {
        window.clearInterval(postimage.windows[areaid].timer);
        if (postimage.windows[areaid].window !== typeof undefined && postimage.windows[areaid].window) {
            postimage.windows[areaid].window.close();
        }
    }
    postimage.windows[areaid] = {};
    postimage.windows[areaid].window = window.open("https://" + postimage.opt.host + "/upload?" + params, areaid, "scrollbars=1,resizable=0,width=690,height=620");
    var self = postimage;
    postimage.windows[areaid].timer = window.setInterval(function () {
        if (self.windows[areaid] === typeof undefined || !self.windows[areaid].window || self.windows[areaid].window.closed !== false) {
            window.clearInterval(self.windows[areaid].timer);
            self.windows[areaid] = undefined;
        }
    }, 200);
}
    ;
postimage.render = function (i) {
    var link = document.createElement('a');
    link.innerHTML = postimage.text;
    console.log(i);
    link.href = "javascript:" + "postimage.upload(" + i + ");";
    postimage.style.apply(link, postimage.style.link);
    var icon = document.createElement('img');
    icon.src = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAHgAAAB4CAMAAAAOusbgAAAAGXRFWHRTb2Z0d2FyZQBBZG9iZSBJbWFnZVJlYWR5ccllPAAAADBQTFRFjLXzydz5d6fx1uX7SYns4Ov8+vz/pcX1VpLt6vL9uNL4ZZvvPoLq8vf+////OoDqiMZ5LgAAAmRJREFUeNrs2dlu3DAMBVCK2lf//982kxRFRpIX2vQYBXifkxxEpiiZhuWhgMACCyywwAILLLDAAvcxIWcEwJyD+Rhs0CcdXfuOizp5NPfDBlVtQ2LCciscfGwrsT7cBofk2kYqhSbAxte2kwqGH0bbDkQjM2xUO5hkOOFs2+HowAfn2AixgQsOtpGiDQ9sdCNGFRY4NXI8Bwzzv/3VpJX617L74HU41Gl/xFBeMQHTrPKiuQxPFlq/NygDlr7YuzAe6YvGDyvu8jV4rOh5fxgb6k5lA7Wy1vrSuNfxClz6Fh1Xu1LuizBdgbM7/uT6aqjhAuwptdrXP5yH+5Xe3p39jk/lNBwiaXMmwim1DefuCQdSRTg8DQPt0Cn2+EMGSm3tnjmEnwfKQ0Nif02n4fd+6XYvFt1DPg9b2lHXbyjFBNvdC023/bjg+BRcn1pqt3tfzu2W4vrgdiJ0It4G0sFqD9ZcLdNSjnbOQ8K2h45FS7rN9PckX9jgzTodLoa48MFb9QKktxgqXFevmehIBUGFW1yRsdLeYcjwigzDO6VamOEWx98pwPzStjL7UO/1WnAyq0jLDfDrDTn/1Gwx2c9GJHtN7iz8WnGt1GsWMZ9TXBxFEMdMhHPsJjgtz8AHxly3wOrIGJV05+Ic31Jg5XmGenR4gd1/2vIMynt4we35sfNMnwbsUKxhY1LvUub6GGInuwTntFPA+PnHTrfn2J2rpqkn4a+jIUPSMdYao9UJkKqehv8eTCEEU5ZzuQBfi8ACCyywwAL/d7D7nQ/CCL+Dy8fgGyOwwAILLLDAAgv8+fwRYADFLTINcMpJIgAAAABJRU5ErkJggg==";
    icon.width = "16";
    icon.height = "16";
    postimage.style.apply(icon, postimage.style.icon);
    var container = document.createElement('div');
    postimage.style.apply(container, postimage.style.container);
    container.appendChild(icon);
    container.appendChild(link);
    var params = {
        "mode": postimage.opt.mode,
        "lang": postimage.opt.lang,
        "code": postimage.opt.code,
        "content": postimage.opt.content,
        "forumurl": encodeURIComponent(document.location.href)
    };
    return container;
}
    ;
postimage.output = postimage.output || function (i, res, co) {
    opener.focus();
    window.close();
}
    ;
postimage.insert = postimage.insert || function (area, container) { }
    ;
postimage.activate = function (e) {
    if (typeof e != "undefined") {
        e.preventDefault();
    }
    postimage.dragcounter += 1;
    for (var i in postimage.dz) {
        if (!postimage.dz.hasOwnProperty(i)) {
            continue;
        }
        postimage.dz[i].activate();
    }
}
    ;
postimage.deactivate = function () {
    postimage.dragcounter -= 1;
    if (postimage.dragcounter <= 0) {
        for (var i in postimage.dz) {
            if (!postimage.dz.hasOwnProperty(i)) {
                continue;
            }
            postimage.dz[i].deactivate();
        }
    }
}
    ;
postimage.dropzone = function () {
    Dropzone.autoDiscover = false;
    var areas = document.getElementsByClassName(postimage.opt.tarClass);
    for (var i = 0; i < areas.length; i++) {
        var area = areas[i];
        if ((area.getAttribute("data-postimg") === null) || (area.getAttribute("contenteditable") == null)) {
            continue;
        }
        try {
            var dz = new Dropzone(area, {
                url: "https://" + postimage.opt.host + "/json" + window.location.search,
                parallelUploads: 1,
                clickable: false,
                acceptedFiles: "image/*",
                maxFiles: 100,
                maxFilesize: 10,
                autoProcessQueue: true
            });
        } catch (e) {
            continue;
        }
        (function (i, dz) {
            dz.activate = function () {
                var area = document.querySelector('[data-postimg="' + i + '"]');
                area.style["backgroundColor"] = "rgba(58, 128, 234, 0.3)";
                area.style["backgroundImage"] = "url('https://postimgs.org/img/logo.png')";
                area.style["backgroundRepeat"] = "no-repeat";
                area.style["backgroundAttachment"] = "scroll";
                area.style["backgroundPosition"] = "center";
            }
                ;
            dz.deactivate = function () {
                var area = document.querySelector('[data-postimg="' + i + '"]');
                area.style["backgroundColor"] = "";
                area.style["backgroundImage"] = "";
                area.style["backgroundRepeat"] = "";
                area.style["backgroundAttachment"] = "";
                area.style["backgroundPosition"] = "";
            }
                ;
            dz.on("dragenter", function (e) {
                var area = document.querySelector('[data-postimg="' + i + '"]');
                area.style["box-shadow"] = "inset 0px 0px 3px 3px #3a80ea";
                postimage.activate();
            });
            dz.on("dragleave", function (e) {
                var area = document.querySelector('[data-postimg="' + i + '"]');
                area.style["box-shadow"] = "";
            });
            dz.on("drop", function (e) {
                var area = document.querySelector('[data-postimg="' + i + '"]');
                postimage.session = rand_string(32);
                area.style["box-shadow"] = "";
                area.style["backgroundImage"] = "";
                area.style["backgroundRepeat"] = "";
                area.style["backgroundAttachment"] = "";
                area.style["backgroundPosition"] = "";
                area.style["backgroundColor"] = "";
                postimage.deactivate();
            });
            dz.on("sending", function (file, xhr, formData) {
                formData.append("token", "61aa06d6116f7331ad7b2ba9c7fb707ec9b182e8");
                formData.append("upload_session", postimage.session);
                formData.append("numfiles", this.files.length - postimage.previous);
                formData.append("gallery", postimage.gallery);
                formData.append("adult", postimage.opt.content);
                formData.append("ui", postimage.ui);
                formData.append("optsize", 0);
                formData.append("upload_referer", String(window.location));
                formData.append("mode", postimage.opt.mode);
                formData.append("lang", postimage.opt.lang);
                formData.append("content", postimage.opt.content);
                formData.append("forumurl", postimage.opt.forumurl);
            });
            dz.on("success", function (e, data) {
                if (data.gallery) {
                    postimage.gallery = data.gallery;
                }
                postimage.resp = data;
            });
            dz.on("queuecomplete", function (e) {
                postimage.gallery = "";
                postimage.previous = this.files.length;
                var params = {
                    "to": postimage.resp.url,
                    "mode": postimage.opt.mode,
                    "hash": postimage.opt.hash,
                    "lang": postimage.opt.lang,
                    "code": postimage.opt.code,
                    "content": postimage.opt.content,
                    "forumurl": encodeURIComponent(document.location.href),
                    "areaid": i,
                    "errors": 0,
                    "dz": 1
                };
                params = postimage.serialize(params);
                xhr = new XMLHttpRequest();
                xhr.open("GET", "https://" + postimage.opt.host + "/mod?dz=1&" + params);
                xhr.onload = function () {
                    if (xhr.status === 200) {
                        postimage.output(i, xhr.responseText, true);
                    } else if (xhr.status !== 200) {
                        console.log('Request failed.  Returned status of ' + xhr.status);
                    }
                }
                    ;
                xhr.send();
            });
        }(area.getAttribute('data-postimg'), dz));
        postimage.dz.push(dz);
    }
    clearInterval(postimage.dzcheck);
    postimage.dzcheck = null;
}
    ;
postimage.init = function () {
    if (!postimage.dzimported && !/Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent)) {
        var dzjs = document.createElement('script');
        dzjs.src = "https://postimgs.org/dropzone.js";
        var dzcss = document.createElement('link');
        dzcss.rel = "stylesheet";
        dzcss.href = "https://postimgs.org/dropzone.css";
        var body = document.getElementsByTagName('body')[0];
        body.appendChild(dzjs);
        body.appendChild(dzcss);
        postimage.dzimported = false;
    }
    var areas = document.getElementsByClassName(postimage.opt.tarClass);
    for (var i = 0; i < areas.length; i++) {
        var area = areas[i];
        if ((area.getAttribute("data-postimg") !== null) || (area.getAttribute("contenteditable") == null)) {
            continue;
        }
        area.setAttribute('data-postimg', 'pi_' + Math.floor(Math.random() * 1e9));
    }
    if (postimage.dzimported) {
        if (postimage.dzcheck == null) {
            postimage.dzcheck = setInterval(function () {
                if (typeof Dropzone == "function") {
                    postimage.dropzone();
                }
            }, 200);
        }
        if (typeof (window.addEventListener) == 'function') {
            document.addEventListener('dragenter', postimage.activate, false);
            document.addEventListener('dragleave', postimage.deactivate, false);
        } else {
            document.attachEvent('dragenter', postimage.activate);
            document.attachEvent('dragleave', postimage.deactivate);
        }
    }
    if (typeof (postimage.custom_init) == 'function') {
        postimage.custom_init();
    }
}
    ;
if (opener && !opener.closed && postimage.params.hasOwnProperty("postimage_id") && postimage.params.hasOwnProperty("postimage_text")) {
    postimage.output(postimage.params["postimage_id"], postimage.params["postimage_text"], true);
} else {
    if (typeof (window.addEventListener) == 'function') {
        window.addEventListener('DOMContentLoaded', postimage.init, false);
        window.addEventListener('load', postimage.init, false);
    } else if (typeof (window.attachEvent) == 'function') {
        window.attachEvent('onload', postimage.init);
    } else {
        if (window.onload != null) {
            var onload = window.onload;
            window.onload = function (e) {
                onload(e);
                postimage.init();
            }
                ;
        } else {
            window.onload = postimage.init;
        }
    }
}
window.openPostImage = function () {
    postimage.init();
    var areas = document.getElementsByClassName(postimage.opt.tarClass);
    for (var i = 0; i < areas.length; i++) {
        var area = areas[i];
        if ((area.getAttribute("data-postimg") == null) || (area.getAttribute("contenteditable") == null)) {
            continue;
        }
        postimage.upload(area.getAttribute("data-postimg"));
    }

}