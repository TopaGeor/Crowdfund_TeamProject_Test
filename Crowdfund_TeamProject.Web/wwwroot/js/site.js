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

$("document").ready(function () {
    $(".js-project-image").change(function () {
        let label = $(".js-picture-label").val();
        alert($(".js-picture-label").val());
        //$(".js-picture-label").val() = $(".js-project-image").val();
        $(".js-picture-label").text($(".js-project-image").val());
        alert($(".js-picture-label").val());
    });
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
        url: '/project/Create',
        type: 'POST',
        coententType: 'application/json',
        data: data
    }).done((project) => {
        alert('asdadsa');
        $('.js-create-project').prop('disabled', false);
    }).fail((xhr) => {
        debugger;
        alert('You are a failure');
        alert(xhr.responseText);
        $('.js-create-project').prop('disabled', false);
    });
    
});

function validateEmail(email) {

    if (!email || email.trim().length === 0) {
        return false;
    }

    if (!email.includes('@')) {
        return false;
    }

    if (!email.includes('.')) {
        return false;
    }

    return true;
}
let emailOk = false;

let $emailInput = $('.js-email');
$emailInput.on('input', (evt) => {
    let $email = $(evt.currentTarget).val();
    let result = validateEmail($email);
    let $validationMessage = $('.js-validation-email');

    if (!result) {
        $validationMessage.show();
    } else {
        $validationMessage.hide();
        emailOk = true;
    }
    button();
});

function button() {
    if (emailOk) {
        let $button = $('.js-submit-creator');
        $button.attr('disabled', false);
    }
}

$('.js-submit-creator').on('click', () => {
    $('.js-submit-creator').attr('disabled', true);
    let name = $('.js-name').val();
    let email = $('.js-email').val();

    let data = JSON.stringify({
        name: name,
        email: email
    });

    $.ajax({
        url: '/creator/CreateCreator',
        type: 'POST',
        contentType: 'application/json',
        data: data
    }).done((creator) => {
        $('.alert').hide();
        let $alertArea = $('.js-create-creator-alert');
        $alertArea.attr("class", "alert alert-success");
        $alertArea.html(`Successfully added Creatot Account  ${creator.name}`);
        $alertArea.show();
        $('form.js-create-creator').hide();
    }).fail((xhr) => {
        $('.alert').hide();
        let $alertArea = $('.js-create-creator-alert');
        $alertArea.attr("class", "alert alert-danger");
        $alertArea.html(xhr.responseText);
        $alertArea.fadeIn();

        setTimeout(function () {
            $('.js-submit-creator').attr('disabled', false);
        }, 300);
    });
});

let $emailBacker = $('.js-email');
$emailBacker.on('input', (evt) => {
    let $email = $(evt.currentTarget).val();
    let result = validateEmail($email);
    let $validationMessage = $('.js-validation-email');

    if (!result) {
        $validationMessage.show();
    } else {
        $validationMessage.hide();
        emailOk = true;
    }
    buttonBacker();
});

function buttonBacker() {
    if (emailOk) {
        let $button = $('.js-submit-backer');
        $button.attr('disabled', false);
    }
}

$('.js-submit-backer').on('click', () => {
    $('.js-submit-backer').attr('disabled', true);
    let name = $('.js-name').val();
    let email = $('.js-email').val();

    let data = JSON.stringify({
        name: name,
        email: email
    });

    $.ajax({
        url: '/backer/Create',
        type: 'POST',
        contentType: 'application/json',
        data: data
    }).done((backer) => {
        $('.alert').hide();
        let $alertArea = $('.js-create-backer-alert');
        $alertArea.attr("class", "alert alert-success");
        $alertArea.html(`Successfully added Backer Account  ${backer.name}`);
        $alertArea.show();
        $('form.js-create-backer').hide();
    }).fail((xhr) => {
        $('.alert').hide();
        let $alertArea = $('.js-create-backer-alert');
        $alertArea.attr("class", "alert alert-danger");
        $alertArea.html(xhr.responseText);
        $alertArea.fadeIn();

        setTimeout(function () {
            $('.js-submit-backer').attr('disabled', false);
        }, 300);
    });
});

$('.js-add-tier').on('click', () => {
    $('.js-add-backer').attr('disabled', true);
    let amount = $('.js-amount').val();
    let description = $('.js-description').val();

    let data = JSON.stringify({
        amount: amount,
        description: description
    });

    $.ajax({
        url: '/tier/Create',
        type: 'POST',
        contentType: 'application/json',
        data: data
    }).done((tier) => {
        $('.alert').hide();
        let $alertArea = $('.js-create-tier-alert');
        $alertArea.attr("class", "alert alert-success");
        $alertArea.html(`Successfully added Reward  ${tier}`);
        $alertArea.show();
        $('form.js-create-tier').hide();
    }).fail((xhr) => {
        $('.alert').hide();
        let $alertArea = $('.js-create-tier-alert');
        $alertArea.attr("class", "alert alert-danger");
        $alertArea.html(xhr.responseText);
        $alertArea.fadeIn();

        setTimeout(function () {
            $('.js-add-backer').attr('disabled', false);
        }, 300);
    });
});

$('.js-btn-search').on('click', function () {
    let title = $('.js-search-title').val();
    let category = parseInt($('.js-project-category').val());

    let data = JSON.stringify({
        title: title,
        category: category
    });

    $.ajax({
        url: '/project/search',
        type: 'POST',
        contentType: 'application/json',
        data: data
    }).done(function (projects) {
        debugger;
        $('.js-project-list').html('');

        projects.forEach(p => {
            debugger;
            let row =
                `<tr>
                    <td>${p.category}</td>
                    <td>${p.creator.name}</td>
                    <td>${p.title}</td>
                    <td>${p.goal}</td>
                    <td>${p.expirationDate}</td> 
                </tr>`;

            $('.js-project-list').append(row);
        });
    }).fail(function (xhr) {
        debugger;
    });
});

let posts = [];

$('.js-btn-add-update').on('click', function () {
    let $updatetext = $('.js-post-text');
    
    let updatetext = $updatetext.val();
    
    if (updatetext.length === 0) {
        return;
    }

    posts.push({
        updatetext: updatetext,
    });

    $updatetext.val('');

    console.log(posts);

});
