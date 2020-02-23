// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$('.js-project-category-button').on('click', () => {
    let button = $('.js-project-category-button');
    $('.js-project-category-dropdown').on('click', (evt) => {
        button.text(evt.target.textContent);
    });
});

$('.js-datepicker').datepicker({
    format: "yyyy/mm/dd",
    weekStart: 1,
    startDate: "Today",
    todayBtn: "linked",
    clearBtn: true,
    daysOfWeekHighlighted: "0,6",
    autoclose: true,
    todayHighlight: true
});

$('js-project-image').change({
    alert("aaas");
    //$('js-project-image').on(
});


$('.js-create-project').on('click', () => {
    let goal = parseFloat($('.js-project-goal').val());
    let title = $('.js-project-title').val();
    //let photo = $('.js-project-image').val();
    //let video = $('.js-project-video').val();
    //let expiration_date = Date.parse($('.js-datepicker').val());
    let description = $('.js-project-description').val();
    let category = $('.js-project-category-button').text();
    
    $('.js-create-project').prop('disabled', true);
    let data = JSON.stringify({
        //Goal: goal,
        Title: title,
        //Photo: photo,
        //Video: video,
        //Expiration_date: expiration_date,
        //Description:  description,
        Category: category
    });
    debugger;
    $.ajax({
        url: '/project/create',
        type: 'POST',
        coententType: 'application/json',
        data: data
    }).done(() => {
        alert('asdadsa');
        $('.js-create-project').prop('disabled', false);
    }).fail((xhr) => {
        debugger;
        alert('You are a failure');
        alert(xhr.responseText);
        $('.js-create-project').prop('disabled', false);
    });
    
});
        //public decimal Goal { get; set; }
        //public string Title { get; set; }
        //public string Description { get; set; }
        //public ProjectCategory Category { get; set; }
        //public DateTimeOffset ExpirationDate { get; set; }
        //public string PhotoUrl { get; set; }
        //public string  VideoUrl { get; set; }

// To get value and post it as JSON you have to :
// let jsonDate = JSON.stringify($('.js-datepicker').datepicker('getDate'));
