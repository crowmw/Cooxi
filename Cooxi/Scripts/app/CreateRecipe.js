var ingredientsCounter = 0;
var access_token = '31051108.c023786.b403fdde5167439d954938defe1c08ab';
var user_id = '31051108';
var user_photos = [];
var img = '';

$(document).ready(function () {
    $("#recipe-details").hide();
    $("#add-recipe-success").hide();
    $("#add-recipe-link").click(function () {
        var url = 'https://api.instagram.com/v1/users/' + user_id + '/media/recent?access_token=' + access_token;
        $.ajax({
            method: "GET",
            url: url,
            dataType: "jsonp",
        }).done(function (data) {
            user_photos = data.data;
            $.each(user_photos, function (i, item) {
                $("#insta-photos-list").append($('<li style="display:none"><img id="photo_' + item.id + '" alt="'+i+'" class="img-thumbnail" src=' + item.images.low_resolution.url + '/></li>').children(':last').hide().fadeIn(250));
            })
        })
    })

    $("#closeModal").on("click", function () {
        resetAddRecipeModal();
    })

    $("#insta-photos-list").on("click", "img", function () {
        img = user_photos[(this).alt];
        $(".modal-header h3").fadeOut(250, function () {
            $("#selected-image").attr("src", img.images.low_resolution.url);
            $("#likes-count").text(img.likes.count);
            $("#comments-count").text(img.comments.count);
            $("#goToInstagram").attr("href", img.link);
            $.each(img.tags, function (i, tag) {
                $("#tags-list").prepend("<li><span class='badge'>" + tag + "</span></li>");
            });
            $(this).text("Dodaj przepis").fadeIn(250);
        });

        $("#insta-photos").fadeOut(250, function () {
            $("#recipe-details").fadeIn(250);
            $("#recipe-details").fadeIn(250);
        });
    })

    $("#add-ingredient").click(function () {
        ingredientsCounter++;
        var addingIngredientName = $("#adding-ingredient-name");
        var addingIngredientCount = $('#adding-ingredient-count');
        var addingMeasureUnits = $('#adding-measure-units-select');
        $("#ingredients-list").prepend('<li id="ingredient-row-' + ingredientsCounter + '"><div class="input-group"><input type="text" id="ingredient-name-' + ingredientsCounter + '" placeholder="Nazwa składnika..." class="form-control"><input type="text" id="ingredient-count-' + ingredientsCounter + '" placeholder="Ilość" class="form-control"><select id="measure-units-select-' + ingredientsCounter + '" class="form-control"><option>gram</option><option>sztuk</option><option>szczypta</option><option>łyżeczek</option><option>łyżek</option><option>kostek</option><option>filiżanek</option><option>szklanek</option><option>litrów</option></select></div><a id="remove-ingredient"><span class="glyphicon glyphicon-minus"></span></a></li>');
        $('#ingredient-name-' + ingredientsCounter + '').val(addingIngredientName.val());
        $('#ingredient-count-' + ingredientsCounter + '').val(addingIngredientCount.val());
        $('#measure-units-select-' + ingredientsCounter + '').val(addingMeasureUnits.val());
        addingIngredientName.val("");
        addingIngredientCount.val("");
    })

    $("#ingredients-list").on('click', 'a', function () {
        $(this).parent().remove();
    })

    $("#saveRecipe").on("click", function () {
        var Recipe = new Object();
        Recipe.title = $("#title-container input").val();
        Recipe.prepare = $("#prepare-container textarea").val();
        Recipe.ration = $("#ration-container input").val();
        Recipe.dificulty = $('#dificulty-select').val();
        Recipe.type = $('#type-select').val();
        Recipe.instagramId = img.id;
        Recipe.tags = img.tags;

        var ingList = $('#ingredients-list');
        var ingredient = {};
        Recipe.ingredients = [];
        $.each(ingList[0].childNodes, function (i, item) {
            var ingredient = {
                name: item.childNodes[0].childNodes[0].value,
                count: item.childNodes[0].childNodes[1].value,
                measure: item.childNodes[0].childNodes[2].value
            }
            Recipe.ingredients.push(ingredient);
        });

        sendRecipe(JSON.stringify(Recipe));
    });
});

function resetAddRecipeModal() {
    $("#addRecipeModal").modal('hide');
    $("#add-recipe-success").hide();
    $("#insta-photos-list").empty();
    $("#title-container input").val('');
    $("#ingredients-list").empty();
    $("#tags-list").empty();
    $("#adding-ingredient-name").val('');
    $("#adding-ingredient-count").val('');
    $('#prepare-container textarea').val('');
    $('#ration-container input').val('');
    $("#adding-measure-units-select").val('gram');
    $('#dificulty-select').val("Łatwe");
    $("#type-select").val("Śniadanie");
    $("#recipe-details").hide();
    $("#insta-photos").show();
    $(".modal-header").show();
}

function sendRecipe(Recipe) {
    $.ajax({
        type: "POST",
        url: "/Recipes/SaveRecipe",
        traditional: true,
        data: Recipe,
        contentType: 'application/json',
    }).success(function () {
        showSuccess();
    })
}

function showSuccess() {
    $("#recipe-details").fadeOut(250);
    $(".modal-header").fadeOut(250, function () {
        $("#add-recipe-success").fadeIn(250);
    });
    setTimeout(function () {
        resetAddRecipeModal();
    }, 2000);
}