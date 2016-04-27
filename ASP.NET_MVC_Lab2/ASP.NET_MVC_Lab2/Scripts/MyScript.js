
$(document).ready(function () {
    function viewModel() {
        this.notepadName = ko.observable("");
        var items = [];

        this.createNotepad = function () {
            $.post("/Home/CreateNotepad", { notepad: this.notepadName() });
            addItem(this.notepadName());
        };
        function addItem(item) {
            if (item) {
                items.push(item);
                var list = document.getElementById('list');
                var li = document.createElement('li');
                li.innerHTML = item;
                list.appendChild(li)
            }
            else
                alert('Не введено имя блокнота!');
        };
        this.clearNotepads = function () {
            items.length = 0;
            $('#list').text('');
            $('img').removeAttr('src');
            $('#notepadContent').val('');
        };
        this.deleteNotepads = function () {
            this.clearNotepads();
            $.post("/Home/DeleteNotepads", {});
        };
        this.loadNotepads = function () {
            $('#list').text('');
            $.get("/Home/LoadNotepads").success(function (data) {
                for (var i = 0; i < data.length; i++) {
                    addItem(data[i]);
                }
            })
        };
    };
    ko.applyBindings(new viewModel());

    var curNotepad = "";
    save.onclick = function () {
        var curContent = $('#notepadContent').val();
        $.post("/Home/ChangeContentNotepad", { notepad: curNotepad, content: curContent });
    };
    $('#list').click(function (event) {
        $('#list > li').removeAttr('style');
        curNotepad = event.target.innerHTML;
        createImage(curNotepad);
        loadNotepad(curNotepad);
        // filter для точного поиска элемента из выборки
        $('li:contains("' + curNotepad + '")').filter(function () {
            return $(this).text() === curNotepad;
        }).css({
            'border-bottom': '2px solid green'
        });
    });
    function loadNotepad(Notepad) {
        $.post("/Home/LoadNotepad", { notepad: Notepad }).success(function (data) {
            $('#notepadContent').val(data);
        });
    };
    function createImage(str) {
        $.post("/Home/CreateImage", { notepad: str });
        $('img').attr('src', '/Content/NotepadImage.jpg?' + Math.random());
    };
    //function func1(str) {
    //    alert("Сработало! " + str);
    //};
});

function loadNotepad1(Notepad) {
    $.post("/Home/LoadNotepad", { notepad: Notepad }).success(function (data) {
        $('#notepadContent').val(data);
    });
};