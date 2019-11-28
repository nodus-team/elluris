
function readURL(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#fotoObra')
                .attr('src', e.target.result)
                .width(400)
                .height(350);

            $('#url')
                .attr('value', e.target.result);

        };

        reader.readAsDataURL(input.files[0]);
    }
}